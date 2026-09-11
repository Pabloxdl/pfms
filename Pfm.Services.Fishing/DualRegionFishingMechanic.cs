using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;
using Pfm.Core.Fishing;
using Pfm.Core.Input;
using Pfm.Core.Macros;
using Pfm.Core.Vision;
using Pfm.Services.Vision;

namespace Pfm.Services.Fishing;

public sealed class DualRegionFishingMechanic : IFishingMechanic
{
	private enum FishingState
	{
		Casting,
		Shaking,
		Minigame
	}

	private const int TrackingLossHoldMs = 150;

	private const int CompleteTrackingLossRecastMs = 1500;

	private readonly IScreenCaptureFactory _captureFactory;

	private readonly IPriorityInputManager _inputManager;

	private readonly Func<IRhythmDetector> _rhythmDetectorFactory;

	private readonly YoloSliderDetector _yoloDetector;

	public Action<FishingProfile, SliderObservation, int, int>? LiveObservationReported { get; set; }

	public string Id => "dual-region";

	public string DisplayName => "YOLO fishing engine";

	public DualRegionFishingMechanic(IScreenCaptureFactory captureFactory, IPriorityInputManager inputManager, Func<IRhythmDetector> rhythmDetectorFactory, YoloSliderDetector yoloDetector)
	{
		_captureFactory = captureFactory;
		_inputManager = inputManager;
		_rhythmDetectorFactory = rhythmDetectorFactory;
		_yoloDetector = yoloDetector;
	}

	public async Task<FishingProcessResult> ExecuteAsync(FishingProcessContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		RuntimeDiagnostics.Write($"Fishing start model='{context.Profile.ModelFilePath}' confidence={context.Profile.ConfidenceThreshold:F2} region={context.Profile.Rod.PrimaryRegion.X},{context.Profile.Rod.PrimaryRegion.Y},{context.Profile.Rod.PrimaryRegion.Width}x{context.Profile.Rod.PrimaryRegion.Height}");
		if (!OperatingSystem.IsWindows())
		{
			return new FishingProcessResult(Succeeded: false, "The dual-region mechanic requires Windows.", "WINDOWS_REQUIRED");
		}
		try
		{
			context.Profile.Validate();
		}
		catch (InvalidOperationException ex)
		{
			return new FishingProcessResult(Succeeded: false, ex.Message, "INVALID_ROI");
		}
		CancellationTokenSource linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
		try
		{
			Task task = StartDedicatedLoop(delegate
			{
				RunProfileLoop(context.Profile, linkedCancellation);
			}, linkedCancellation.Token);
			try
			{
				await task.ConfigureAwait(continueOnCapturedContext: false);
				return new FishingProcessResult(Succeeded: true, "Profile fishing engine completed.");
			}
			catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
			{
				return new FishingProcessResult(Succeeded: true, "Profile fishing engine stopped.");
			}
			catch (Exception ex3)
			{
				RuntimeDiagnostics.Write($"Fishing worker failed: {ex3}");
				linkedCancellation.Cancel();
				return new FishingProcessResult(Succeeded: false, ex3.Message, "OBSERVER_FAILURE");
			}
			finally
			{
				RuntimeDiagnostics.Write("Fishing cleanup started");
				linkedCancellation.Cancel();
				try
				{
					_inputManager.ReleaseAll();
				}
				catch
				{
				}
				try
				{
					_yoloDetector.ResetModelSession(context.Profile);
				}
				catch
				{
				}
				RuntimeDiagnostics.Write("Fishing cleanup completed; model session unloaded");
			}
		}
		finally
		{
			if (linkedCancellation != null)
			{
				((IDisposable)linkedCancellation).Dispose();
			}
		}
	}

	private void RunProfileLoop(FishingProfile profile, CancellationTokenSource cancellation)
	{
		try
		{
			Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
			RodConfig rod = profile.Rod;
			using IScreenCaptureSession screenCaptureSession = _captureFactory.Create(rod.PrimaryRegion);
			using IScreenCaptureSession screenCaptureSession2 = (rod.HasRhythmTracker ? _captureFactory.Create(rod.SecondaryRegion) : null);
			using IScreenCaptureSession screenCaptureSession3 = (rod.HasProgressTracker ? _captureFactory.Create(rod.ProgressRegion) : null);
			if (rod.HasRhythmTracker)
			{
				_rhythmDetectorFactory();
			}
			PixelProgressDetector pixelProgressDetector = (rod.HasProgressTracker ? new PixelProgressDetector() : null);
			HighResolutionFramePacer highResolutionFramePacer = new HighResolutionFramePacer(rod.TargetFramesPerSecond);
			FishingState fishingState = FishingState.Casting;
			double num = 0.0;
			long startingTimestamp = Stopwatch.GetTimestamp();
			long num2 = 0L;
			long startingTimestamp2 = 0L;
			HashSet<(int, int, int, int)> hashSet = new HashSet<(int, int, int, int)>();
			int? qteClassId = null;
			long startingTimestamp3 = 0L;
			bool flag = false;
			PixelFrame frame = screenCaptureSession.Capture();
			SliderObservation arg = _yoloDetector.Evaluate(in frame, profile);
			LiveObservationReported?.Invoke(profile, arg, frame.Width, frame.Height);
			if (arg.IsDetected)
			{
				num = arg.ErrorPixels;
				startingTimestamp = Stopwatch.GetTimestamp();
				fishingState = FishingState.Minigame;
				RuntimeDiagnostics.Write("Initial probe found active minigame; resumed tracking");
			}
			else
			{
				RuntimeDiagnostics.Write($"Initial probe incomplete; boxes={arg.DetectionBoxes.Count}; starting cast");
			}
			while (!cancellation.IsCancellationRequested)
			{
				switch (fishingState)
				{
				case FishingState.Casting:
				{
					_inputManager.ReleaseAll();
					hashSet.Clear();
					qteClassId = null;
					int value4 = profile.Rod.PrimaryRegion.X + profile.Rod.PrimaryRegion.Width / 2;
					int value5 = profile.Rod.PrimaryRegion.Y + profile.Rod.PrimaryRegion.Height / 2;
					_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: true, value4, value5);
					Wait(profile.CastHoldTimeMs, cancellation.Token);
					_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: false);
					fishingState = FishingState.Shaking;
					break;
				}
				case FishingState.Shaking:
				{
					long timestamp2 = Stopwatch.GetTimestamp();
					while (!cancellation.IsCancellationRequested)
					{
						PixelFrame frame3 = screenCaptureSession.Capture();
						SliderObservation arg3 = _yoloDetector.Evaluate(in frame3, profile);
						LiveObservationReported?.Invoke(profile, arg3, frame3.Width, frame3.Height);
						if (arg3.IsDetected)
						{
							num = arg3.ErrorPixels;
							startingTimestamp = Stopwatch.GetTimestamp();
							num2 = 0L;
							fishingState = FishingState.Minigame;
							break;
						}
						if (screenCaptureSession2 != null || rod.Rhythm.IsEnabled)
						{
							_inputManager.PulseAsync(rod.Rhythm.VirtualKey, 0, rod.Rhythm.KeyHoldMs, cancellation.Token).GetAwaiter().GetResult();
						}
						if (Stopwatch.GetElapsedTime(timestamp2).TotalMilliseconds >= (double)profile.BiteTimeoutMs)
						{
							_inputManager.ReleaseAll();
							Wait(profile.RecastDelayMs, cancellation.Token);
							fishingState = FishingState.Casting;
							break;
						}
						highResolutionFramePacer.WaitForNextFrame(cancellation.Token);
					}
					break;
				}
				case FishingState.Minigame:
				{
					long timestamp = Stopwatch.GetTimestamp();
					PixelFrame frame2 = screenCaptureSession.Capture();
					SliderObservation arg2 = _yoloDetector.Evaluate(in frame2, profile);
					LiveObservationReported?.Invoke(profile, arg2, frame2.Width, frame2.Height);
					if (!arg2.IsDetected)
					{
						ProgressObservation progressObservation = ((screenCaptureSession3 != null && pixelProgressDetector != null) ? pixelProgressDetector.Evaluate(screenCaptureSession3.Capture(), rod.Progress) : default(ProgressObservation));
						long num3 = ((arg2.TargetDetected || arg2.ProgressBar.HasValue || progressObservation.IsDetected) ? 5000 : 1500);
						num2 = ((num2 == 0L) ? timestamp : num2);
						if (num2 == timestamp)
						{
							RuntimeDiagnostics.Write($"Tracking lost; target={arg2.TargetDetected}; boxes={arg2.DetectionBoxes.Count}; timeout={num3}ms");
						}
						if (Stopwatch.GetElapsedTime(num2, timestamp).TotalMilliseconds >= 150.0)
						{
							_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: false);
						}
						if (Stopwatch.GetElapsedTime(num2, timestamp).TotalMilliseconds >= (double)num3)
						{
							RuntimeDiagnostics.Write("Tracking timeout reached; returning to casting");
							_inputManager.ReleaseAll();
							Wait(profile.RecastDelayMs, cancellation.Token);
							fishingState = FishingState.Casting;
						}
						highResolutionFramePacer.WaitForNextFrame(cancellation.Token);
						break;
					}
					num2 = 0L;
					int playerCenterX = arg2.PlayerCenterX;
					int num4 = arg2.ErrorPixels;
					QuickEventConfig qte = profile.QuickEvent;
					if (qte != null && qte.Enabled)
					{
						if (!qteClassId.HasValue)
						{
							ScreenRegion signRegion = qte.SignRegion;
							if (signRegion != null && signRegion.IsEnabled)
							{
								int relX = signRegion.X - rod.PrimaryRegion.X;
								int relY = signRegion.Y - rod.PrimaryRegion.Y;
								AiDetectionBox? aiDetectionBox = ((IEnumerable<AiDetectionBox>)arg2.DetectionBoxes).Select((Func<AiDetectionBox, AiDetectionBox?>)((AiDetectionBox b) => b)).FirstOrDefault((AiDetectionBox? b) => b.HasValue && qte.SignClassIds.Contains(b.Value.ClassId) && b.Value.X >= relX && b.Value.Y >= relY && b.Value.X + b.Value.Width <= relX + signRegion.Width && b.Value.Y + b.Value.Height <= relY + signRegion.Height);
								if (aiDetectionBox.HasValue)
								{
									qteClassId = aiDetectionBox.Value.ClassId;
									startingTimestamp3 = timestamp;
									flag = false;
									RuntimeDiagnostics.Write($"QTE: Sign detected class={qteClassId}");
								}
							}
						}
						if (qteClassId.HasValue)
						{
							double totalMilliseconds = Stopwatch.GetElapsedTime(startingTimestamp3, timestamp).TotalMilliseconds;
							if (totalMilliseconds >= (double)qte.MemoHoldMs && totalMilliseconds < (double)(qte.MemoHoldMs + qte.SelectionTimeoutMs))
							{
								AiDetectionBox? aiDetectionBox2 = ((IEnumerable<AiDetectionBox>)arg2.DetectionBoxes).Select((Func<AiDetectionBox, AiDetectionBox?>)((AiDetectionBox b) => b)).FirstOrDefault((AiDetectionBox? b) => b.HasValue && b.Value.ClassId == qteClassId.Value);
								if (aiDetectionBox2.HasValue)
								{
									if (!flag)
									{
										flag = true;
										num = num4;
										RuntimeDiagnostics.Write($"QTE: Activating sign bar pursuit class={qteClassId}");
									}
									AiDetectionBox value = aiDetectionBox2.Value;
									num4 = (int)Math.Round((double)value.X + (double)value.Width / 2.0 - (double)playerCenterX);
									if ((double)Math.Abs(num4) <= qte.SuccessThresholdPixels)
									{
										RuntimeDiagnostics.Write($"QTE: Success class={qteClassId}");
										qteClassId = null;
									}
								}
							}
							else if (totalMilliseconds >= (double)(qte.MemoHoldMs + qte.SelectionTimeoutMs))
							{
								RuntimeDiagnostics.Write($"QTE: Timeout class={qteClassId}");
								qteClassId = null;
							}
						}
					}
					double num5 = Math.Max(Stopwatch.GetElapsedTime(startingTimestamp, timestamp).TotalSeconds, 1.0 / (double)Stopwatch.Frequency);
					double num6 = ((double)num4 - num) / num5;
					if (profile.FishingMode == FishingMode.BarControl)
					{
						double num7 = rod.Slider.Kp * (double)num4 + rod.Slider.Kd * num6;
						if (Math.Abs(num4) > rod.Slider.DeadZonePixels)
						{
							_inputManager.SetMouseButton(MacroMouseButton.Left, num7 > 0.0);
						}
						else
						{
							_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: false);
						}
					}
					else
					{
						_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: false);
					}
					num = num4;
					startingTimestamp = timestamp;
					if (profile.FishingMode == FishingMode.TimingClick)
					{
						HashSet<int> controlIds = (from detectionClassDefinition in profile.CustomClasses
							where detectionClassDefinition.Behavior == DetectionBehavior.Control
							select detectionClassDefinition.Id).ToHashSet();
						HashSet<int> pursueIds = (from detectionClassDefinition in profile.CustomClasses
							where detectionClassDefinition.Behavior == DetectionBehavior.Pursue
							select detectionClassDefinition.Id).ToHashSet();
						AiDetectionBox[] array = arg2.DetectionBoxes.Where((AiDetectionBox box) => controlIds.Contains(box.ClassId)).ToArray();
						AiDetectionBox[] array2 = arg2.DetectionBoxes.Where((AiDetectionBox box) => pursueIds.Contains(box.ClassId)).ToArray();
						HashSet<(int, int, int, int)> hashSet2 = new HashSet<(int, int, int, int)>();
						AiDetectionBox[] array3 = array2;
						for (int num8 = 0; num8 < array3.Length; num8++)
						{
							AiDetectionBox aiDetectionBox3 = array3[num8];
							int x = aiDetectionBox3.X;
							int val = aiDetectionBox3.X + aiDetectionBox3.Width;
							AiDetectionBox[] array4 = array;
							for (int num9 = 0; num9 < array4.Length; num9++)
							{
								AiDetectionBox aiDetectionBox4 = array4[num9];
								int x2 = aiDetectionBox4.X;
								int val2 = aiDetectionBox4.X + aiDetectionBox4.Width;
								int num10 = Math.Max(x, x2);
								int num11 = Math.Min(val, val2);
								if ((double)Math.Max(0, num11 - num10) / (double)Math.Max(1, Math.Min(aiDetectionBox3.Width, aiDetectionBox4.Width)) >= 0.3)
								{
									(int, int, int, int) item = (aiDetectionBox4.X, aiDetectionBox4.Y, aiDetectionBox4.Width, aiDetectionBox4.Height);
									hashSet2.Add(item);
								}
							}
						}
						double totalMilliseconds2 = Stopwatch.GetElapsedTime(startingTimestamp2, timestamp).TotalMilliseconds;
						foreach (var item2 in hashSet2)
						{
							if (!hashSet.Contains(item2) && totalMilliseconds2 >= (double)profile.ClickCooldownMs)
							{
								_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: false);
								Wait(1, cancellation.Token);
								int value2 = profile.Rod.PrimaryRegion.X + profile.Rod.PrimaryRegion.Width / 2;
								int value3 = profile.Rod.PrimaryRegion.Y + profile.Rod.PrimaryRegion.Height / 2;
								_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: true, value2, value3);
								Wait(profile.ClickHoldDurationMs, cancellation.Token);
								_inputManager.SetMouseButton(MacroMouseButton.Left, isDown: false);
								startingTimestamp2 = timestamp;
								break;
							}
						}
						hashSet.IntersectWith(hashSet2);
						hashSet.UnionWith(hashSet2);
					}
					highResolutionFramePacer.WaitForNextFrame(cancellation.Token);
					break;
				}
				}
			}
		}
		catch
		{
			cancellation.Cancel();
			throw;
		}
	}

	private static Task StartDedicatedLoop(Action loop, CancellationToken cancellationToken)
	{
		return Task.Factory.StartNew(loop, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
	}

	private static void Wait(int milliseconds, CancellationToken cancellationToken)
	{
		if (milliseconds > 0 && cancellationToken.WaitHandle.WaitOne(milliseconds))
		{
			cancellationToken.ThrowIfCancellationRequested();
		}
	}
}

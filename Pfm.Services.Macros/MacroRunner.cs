using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Input;
using Pfm.Core.Macros;
using Pfm.Core.Vision;
using Pfm.Services.Fishing;

namespace Pfm.Services.Macros;

public sealed class MacroRunner : IMacroRunner, IAsyncDisposable
{
	private readonly object _stateLock = new object();

	private readonly IScreenCaptureFactory _captureFactory;

	private readonly IPriorityInputManager _inputManager;

	private readonly int _targetFramesPerSecond;

	private readonly TemplateImageMatcher _templateImageMatcher = new TemplateImageMatcher();

	private CancellationTokenSource? _runCancellation;

	private Task<MacroRunResult>? _runTask;

	private bool _disposed;

	public bool IsRunning
	{
		get
		{
			lock (_stateLock)
			{
				Task<MacroRunResult> runTask = _runTask;
				return runTask != null && !runTask.IsCompleted;
			}
		}
	}

	public MacroRunResult? LastResult { get; private set; }

	public event EventHandler<MacroRunnerStateChangedEventArgs>? StateChanged;

	public MacroRunner(IScreenCaptureFactory captureFactory, IPriorityInputManager inputManager, int targetFramesPerSecond = 120)
	{
		_captureFactory = captureFactory;
		_inputManager = inputManager;
		_targetFramesPerSecond = Math.Clamp(targetFramesPerSecond, 60, 240);
	}

	public Task StartAsync(IReadOnlyList<MacroAction> actions, CancellationToken cancellationToken = default(CancellationToken))
	{
		MacroAction[] pipeline = MacroPipelineValidator.ValidateAndSnapshot(actions);
		Task<MacroRunResult> runTask2;
		lock (_stateLock)
		{
			ObjectDisposedException.ThrowIf(_disposed, this);
			Task<MacroRunResult> runTask = _runTask;
			if (runTask != null && !runTask.IsCompleted)
			{
				throw new InvalidOperationException("A macro is already running.");
			}
			_runCancellation?.Dispose();
			_runCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
			runTask2 = (_runTask = Task.Factory.StartNew(() => ExecutePipeline(pipeline, _runCancellation.Token), CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default));
			LastResult = null;
		}
		ObserveCompletionAsync(runTask2);
		PublishStateChanged(new MacroRunnerStateChangedEventArgs(isRunning: true, null));
		return Task.CompletedTask;
	}

	public async Task<MacroRunResult> StopAsync()
	{
		Task<MacroRunResult> runTask;
		lock (_stateLock)
		{
			runTask = _runTask;
			_runCancellation?.Cancel();
		}
		if (runTask == null)
		{
			return LastResult ?? MacroRunResult.Stopped(0L);
		}
		return await runTask.ConfigureAwait(continueOnCapturedContext: false);
	}

	public async ValueTask DisposeAsync()
	{
		lock (_stateLock)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
		}
		await StopAsync().ConfigureAwait(continueOnCapturedContext: false);
		lock (_stateLock)
		{
			_runCancellation?.Dispose();
			_runCancellation = null;
		}
	}

	private MacroRunResult ExecutePipeline(MacroAction[] pipeline, CancellationToken cancellationToken)
	{
		Dictionary<int, IScreenCaptureSession> dictionary = new Dictionary<int, IScreenCaptureSession>();
		long executedActions = 0L;
		MacroRunResult macroRunResult;
		try
		{
			macroRunResult = RunActions(pipeline, dictionary, ref executedActions, cancellationToken);
		}
		catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
		{
			macroRunResult = MacroRunResult.Stopped(executedActions);
		}
		catch (Exception ex2)
		{
			macroRunResult = MacroRunResult.Failed(ex2.Message, executedActions);
		}
		Exception ex3 = null;
		foreach (IScreenCaptureSession value in dictionary.Values)
		{
			try
			{
				value.Dispose();
			}
			catch (Exception ex4)
			{
				if (ex3 == null)
				{
					ex3 = ex4;
				}
			}
		}
		try
		{
			_inputManager.ReleaseAll();
		}
		catch (Exception ex5)
		{
			if (ex3 == null)
			{
				ex3 = ex5;
			}
		}
		if (ex3 != null)
		{
			return MacroRunResult.Failed(macroRunResult.Message + " Cleanup failed: " + ex3.Message, executedActions);
		}
		return macroRunResult;
	}

	private async Task ObserveCompletionAsync(Task<MacroRunResult> runTask)
	{
		MacroRunResult macroRunResult;
		try
		{
			macroRunResult = await runTask.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			macroRunResult = MacroRunResult.Failed(ex.Message, 0L);
		}
		bool flag = false;
		lock (_stateLock)
		{
			if (_runTask == runTask)
			{
				LastResult = macroRunResult;
				flag = true;
			}
		}
		if (flag)
		{
			PublishStateChanged(new MacroRunnerStateChangedEventArgs(isRunning: false, macroRunResult));
		}
	}

	private MacroRunResult RunActions(MacroAction[] pipeline, Dictionary<int, IScreenCaptureSession> captures, ref long executedActions, CancellationToken cancellationToken)
	{
		HighResolutionFramePacer highResolutionFramePacer = new HighResolutionFramePacer(_targetFramesPerSecond);
		int num = 0;
		while (num >= 0 && num < pipeline.Length)
		{
			cancellationToken.ThrowIfCancellationRequested();
			MacroAction macroAction = pipeline[num];
			executedActions++;
			if (!(macroAction is TemplateImageMatchAction templateImageMatchAction))
			{
				if (!(macroAction is PixelColorCheckAction pixelColorCheckAction))
				{
					if (!(macroAction is KeyPressAction keyPressAction))
					{
						if (!(macroAction is MouseButtonAction mouseButtonAction))
						{
							if (!(macroAction is DelayAction delayAction))
							{
								if (macroAction is EndAction)
								{
									return MacroRunResult.Completed(executedActions);
								}
							}
							else
							{
								Wait(delayAction.DurationMs, cancellationToken);
								num = ResolveTarget(delayAction.OnSuccessTarget, num, pipeline.Length);
							}
						}
						else
						{
							int? x = (mouseButtonAction.MoveCursor ? new int?(mouseButtonAction.X) : ((int?)null));
							int? y = (mouseButtonAction.MoveCursor ? new int?(mouseButtonAction.Y) : ((int?)null));
							if (mouseButtonAction.ActionKind == MacroMouseActionKind.Click)
							{
								_inputManager.ClickAsync(mouseButtonAction.Button, x, y, mouseButtonAction.DelayMs, mouseButtonAction.HoldMs, cancellationToken).GetAwaiter().GetResult();
							}
							else
							{
								Wait(mouseButtonAction.DelayMs, cancellationToken);
								_inputManager.SetMouseButton(mouseButtonAction.Button, mouseButtonAction.ActionKind == MacroMouseActionKind.Down, x, y);
							}
							num = ResolveTarget(mouseButtonAction.OnSuccessTarget, num, pipeline.Length);
						}
					}
					else
					{
						_inputManager.PulseAsync(keyPressAction.VirtualKey, keyPressAction.DelayMs, keyPressAction.HoldMs, cancellationToken).GetAwaiter().GetResult();
						num = ResolveTarget(keyPressAction.OnSuccessTarget, num, pipeline.Length);
					}
				}
				else
				{
					if (!captures.TryGetValue(num, out IScreenCaptureSession value))
					{
						value = _captureFactory.Create(pixelColorCheckAction.Region);
						captures.Add(num, value);
					}
					PixelMatch pixelMatch = PixelActionEvaluator.FindMatch(value.Capture(), pixelColorCheckAction);
					if (pixelMatch.IsMatch && pixelColorCheckAction is PixelColorClickAction pixelColorClickAction)
					{
						_inputManager.ClickAsync(pixelColorClickAction.Button, pixelColorCheckAction.Region.X + pixelMatch.X, pixelColorCheckAction.Region.Y + pixelMatch.Y, pixelColorClickAction.DelayMs, pixelColorClickAction.HoldMs, cancellationToken).GetAwaiter().GetResult();
					}
					num = ResolveTarget(pixelMatch.IsMatch ? pixelColorCheckAction.OnSuccessTarget : pixelColorCheckAction.OnFailTarget, num, pipeline.Length);
				}
			}
			else
			{
				if (!captures.TryGetValue(num, out IScreenCaptureSession value2))
				{
					value2 = _captureFactory.Create(templateImageMatchAction.Region);
					captures.Add(num, value2);
				}
				TemplateMatch templateMatch = _templateImageMatcher.Find(value2.Capture(), templateImageMatchAction);
				if (templateMatch.IsMatch && templateImageMatchAction.ClickOnMatch)
				{
					_inputManager.ClickAsync(MacroMouseButton.Left, templateImageMatchAction.Region.X + templateMatch.X, templateImageMatchAction.Region.Y + templateMatch.Y, templateImageMatchAction.ClickDelayMs, templateImageMatchAction.ClickHoldMs, cancellationToken).GetAwaiter().GetResult();
				}
				num = (templateMatch.IsMatch ? ResolveTarget(templateImageMatchAction.OnSuccessTarget, num, pipeline.Length) : (templateImageMatchAction.OnFailTarget ?? num));
			}
			highResolutionFramePacer.WaitForNextFrame(cancellationToken);
		}
		return MacroRunResult.Completed(executedActions);
	}

	private void PublishStateChanged(MacroRunnerStateChangedEventArgs args)
	{
		EventHandler<MacroRunnerStateChangedEventArgs> eventHandler = StateChanged;
		if (eventHandler == null)
		{
			return;
		}
		Delegate[] invocationList = eventHandler.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			EventHandler<MacroRunnerStateChangedEventArgs> eventHandler2 = (EventHandler<MacroRunnerStateChangedEventArgs>)invocationList[i];
			try
			{
				eventHandler2(this, args);
			}
			catch
			{
			}
		}
	}

	private static int ResolveTarget(int? configuredTarget, int currentIndex, int actionCount)
	{
		int num = configuredTarget ?? (currentIndex + 1);
		if (num != actionCount)
		{
			return num;
		}
		return actionCount;
	}

	private static void Wait(int milliseconds, CancellationToken cancellationToken)
	{
		if (milliseconds > 0 && cancellationToken.WaitHandle.WaitOne(milliseconds))
		{
			cancellationToken.ThrowIfCancellationRequested();
		}
	}
}

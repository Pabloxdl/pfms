using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

[SupportedOSPlatform("windows")]
public sealed class VisionDebugService : IVisionDebugService, IAsyncDisposable
{
	private readonly IScreenCaptureFactory _captureFactory;

	private readonly YoloSliderDetector _detector;

	private CancellationTokenSource? _cancellation;

	private Task? _loop;

	public bool IsRunning
	{
		get
		{
			Task loop = _loop;
			if (loop != null)
			{
				return !loop.IsCompleted;
			}
			return false;
		}
	}

	public event EventHandler<VisionDebugFrame>? FrameReady;

	public VisionDebugService(IScreenCaptureFactory captureFactory, YoloSliderDetector detector)
	{
		_captureFactory = captureFactory;
		_detector = detector;
	}

	public Task StartAsync(FishingProfile profile, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (IsRunning)
		{
			return Task.CompletedTask;
		}
		profile.Validate();
		_cancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
		_loop = Task.Run(delegate
		{
			RunLoop(profile, _cancellation.Token);
		}, _cancellation.Token);
		return Task.CompletedTask;
	}

	public async Task StopAsync()
	{
		if (_loop == null)
		{
			return;
		}
		_cancellation?.Cancel();
		try
		{
			await _loop.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (OperationCanceledException)
		{
		}
		finally
		{
			_loop = null;
			_cancellation?.Dispose();
			_cancellation = null;
		}
	}

	public async ValueTask DisposeAsync()
	{
		await StopAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	private void RunLoop(FishingProfile profile, CancellationToken cancellationToken)
	{
		try
		{
			using IScreenCaptureSession screenCaptureSession = _captureFactory.Create(profile.Rod.PrimaryRegion);
			using IScreenCaptureSession screenCaptureSession2 = (profile.Rod.HasProgressTracker ? _captureFactory.Create(profile.Rod.ProgressRegion) : null);
			PixelProgressDetector pixelProgressDetector = (profile.Rod.HasProgressTracker ? new PixelProgressDetector() : null);
			while (!cancellationToken.IsCancellationRequested)
			{
				PixelFrame frame = screenCaptureSession.Capture();
				SliderObservation observation = _detector.Evaluate(in frame, profile);
				ProgressObservation? pixelProgress = ((screenCaptureSession2 != null && pixelProgressDetector != null) ? new ProgressObservation?(pixelProgressDetector.Evaluate(screenCaptureSession2.Capture(), profile.Rod.Progress)) : ((ProgressObservation?)null));
				byte[] pngData = Render(in frame, observation.DetectionBoxes, profile);
				string summary = DetectionDisplayFormatter.BuildSummary(observation, profile, pixelProgress);
				DetectionDisplayBox[] boxes = DetectionDisplayFormatter.BuildDisplayBoxes(observation.DetectionBoxes, profile);
				BarStripFrame barStrip = DetectionDisplayFormatter.BuildBarStrip(observation, profile, frame.Width);
				FrameReady?.Invoke(this, new VisionDebugFrame(pngData, summary, observation.DetectionBoxes.Count, null, boxes, frame.Width, frame.Height, barStrip));
				cancellationToken.WaitHandle.WaitOne(100);
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex2)
		{
			FrameReady?.Invoke(this, new VisionDebugFrame(Array.Empty<byte>(), "Vision preview stopped", 0, ex2.Message));
		}
	}

	private unsafe static byte[] Render(in PixelFrame frame, IReadOnlyList<AiDetectionBox> boxes, FishingProfile profile)
	{
		using Bitmap bitmap = new Bitmap(frame.Width, frame.Height, PixelFormat.Format32bppArgb);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		try
		{
			for (int i = 0; i < frame.Height; i++)
			{
				Buffer.MemoryCopy(frame.Pixels + i * frame.Stride, (void*)(bitmapData.Scan0 + i * bitmapData.Stride), frame.Width * 4, frame.Width * 4);
			}
		}
		finally
		{
			bitmap.UnlockBits(bitmapData);
		}
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			using Font font = new Font("Segoe UI", 10f, FontStyle.Bold);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			foreach (AiDetectionBox box in boxes)
			{
				(string Name, Color Color) tuple = DetectionDisplayFormatter.DescribeClass(box.ClassId, profile);
				var (value, _) = tuple;
				using Pen pen = new Pen(tuple.Color, 3f);
				using SolidBrush brush = new SolidBrush(Color.FromArgb(210, 12, 16, 24));
				Rectangle rect = new Rectangle(box.X, box.Y, box.Width, box.Height);
				graphics.DrawRectangle(pen, rect);
				string text = $"{value} {box.Confidence:P0}";
				SizeF sizeF = graphics.MeasureString(text, font);
				int num = Math.Max(0, box.Y - (int)sizeF.Height - 3);
				graphics.FillRectangle(brush, box.X, num, sizeF.Width + 8f, sizeF.Height + 2f);
				graphics.DrawString(text, font, Brushes.White, box.X + 4, num + 1);
			}
		}
		using MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		return memoryStream.ToArray();
	}
}

using System;
using Avalonia;
using Avalonia.Threading;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;
using Pfm.Views;

namespace Pfm.Services.Vision;

public sealed class AvaloniaGameVisionOverlay : IGameVisionOverlay, IDisposable
{
	private const double HeaderHeight = 64.0;

	private GameVisionOverlay? _window;

	public bool IsVisible => _window?.IsVisible ?? false;

	public void Show(FishingProfile profile)
	{
		Dispatcher.UIThread.Post(delegate
		{
			ScreenRegion primaryRegion = profile.Rod.PrimaryRegion;
			if (_window == null)
			{
				_window = new GameVisionOverlay();
			}
			double num = _window.Screens?.Primary?.Scaling ?? 1.0;
			double width = (double)primaryRegion.Width / num;
			_ = (double)primaryRegion.Height / num;
			double num2 = 64.0 * num;
			double a = (((double)primaryRegion.Y >= num2) ? ((double)primaryRegion.Y - num2) : ((double)(primaryRegion.Y + primaryRegion.Height)));
			_window.Position = new PixelPoint(primaryRegion.X, (int)Math.Round(a));
			_window.Width = width;
			_window.Height = 64.0;
			_window.SetCaptureLayout(0.0, 64.0);
			if (!_window.IsVisible)
			{
				_window.Show();
			}
		});
	}

	public void Hide()
	{
		Dispatcher.UIThread.Post(delegate
		{
			_window?.Hide();
		});
	}

	public void Update(VisionDebugFrame frame)
	{
		Dispatcher.UIThread.Post(delegate
		{
			GameVisionOverlay? window = _window;
			if (window != null && window.IsVisible)
			{
				_window.SetFrame(frame);
			}
		});
	}

	public void Dispose()
	{
		Dispatcher.UIThread.Post(delegate
		{
			_window?.Close();
			_window = null;
		});
	}
}

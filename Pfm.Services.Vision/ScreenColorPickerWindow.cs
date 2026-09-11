using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Platform;
using Pfm.Core.Configuration;

namespace Pfm.Services.Vision;

internal sealed class ScreenColorPickerWindow : Window
{
	private static class NativeMethods
	{
		[DllImport("user32.dll")]
		public static extern nint GetDC(nint hWnd);

		[DllImport("user32.dll")]
		public static extern int ReleaseDC(nint hWnd, nint hDC);

		[DllImport("gdi32.dll")]
		public static extern uint GetPixel(nint hdc, int x, int y);
	}

	private readonly Action<PixelColor> _onColorPicked;

	private Canvas? _canvas;

	private TextBlock? _colorLabel;

	private int _screenWidth;

	private int _screenHeight;

	public ScreenColorPickerWindow(PixelColor initialColor, Action<PixelColor> onColorPicked)
	{
		_onColorPicked = onColorPicked;
		InitializeWindow(initialColor);
	}

	private void InitializeWindow(PixelColor initial)
	{
		_canvas = new Canvas
		{
			Background = Brushes.Transparent
		};
		_colorLabel = new TextBlock
		{
			Foreground = Brushes.White,
			Background = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0)),
			Padding = new Thickness(8.0, 4.0),
			FontSize = 14.0,
			FontWeight = FontWeight.Bold
		};
		Canvas.SetLeft(_colorLabel, 10.0);
		Canvas.SetTop(_colorLabel, 10.0);
		_canvas.Children.Add(_colorLabel);
		base.Content = _canvas;
		base.WindowDecorations = WindowDecorations.None;
		base.ShowInTaskbar = false;
		base.Topmost = true;
		base.Background = Brushes.Transparent;
		base.CanResize = false;
		base.PointerMoved += OnPointerMoved;
		base.PointerPressed += OnPointerPressed;
		base.KeyDown += OnKeyDown;
		base.Opened += OnOpened;
	}

	private void OnOpened(object? sender, EventArgs e)
	{
		Screen screen = base.Screens?.Primary;
		if ((object)screen != null)
		{
			_screenWidth = screen.Bounds.Width;
			_screenHeight = screen.Bounds.Height;
			base.Position = new PixelPoint(0, 0);
			base.Width = _screenWidth;
			base.Height = _screenHeight;
		}
		Focus();
	}

	private void OnPointerMoved(object? sender, PointerEventArgs e)
	{
		Point position = e.GetPosition(this);
		if (position.X >= 0.0 && position.X < (double)_screenWidth && position.Y >= 0.0 && position.Y < (double)_screenHeight)
		{
			PixelColor pixelColor = CapturePixelColor((int)position.X, (int)position.Y);
			if (_colorLabel != null)
			{
				_colorLabel.Text = $"#{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";
			}
		}
	}

	private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
	{
		if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
		{
			Point position = e.GetPosition(this);
			if (position.X >= 0.0 && position.X < (double)_screenWidth && position.Y >= 0.0 && position.Y < (double)_screenHeight)
			{
				PixelColor obj = CapturePixelColor((int)position.X, (int)position.Y);
				_onColorPicked(obj);
				Close();
			}
		}
	}

	private void OnKeyDown(object? sender, KeyEventArgs e)
	{
		if (e.Key == Key.Escape)
		{
			Close();
		}
	}

	private static PixelColor CapturePixelColor(int x, int y)
	{
		if (!OperatingSystem.IsWindows())
		{
			return new PixelColor(128, 128, 128);
		}
		try
		{
			nint dC = NativeMethods.GetDC(IntPtr.Zero);
			if (dC == IntPtr.Zero)
			{
				return new PixelColor(128, 128, 128);
			}
			try
			{
				uint pixel = NativeMethods.GetPixel(dC, x, y);
				return new PixelColor((byte)(pixel & 0xFF), (byte)((pixel >> 8) & 0xFF), (byte)((pixel >> 16) & 0xFF));
			}
			finally
			{
				NativeMethods.ReleaseDC(IntPtr.Zero, dC);
			}
		}
		catch
		{
			return new PixelColor(128, 128, 128);
		}
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using CompiledAvaloniaXaml;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Views;

public class GameVisionOverlay : Window
{
	private static class NativeMethods
	{
		[DllImport("user32.dll", EntryPoint = "GetWindowLongPtrW", ExactSpelling = true)]
		public static extern nint GetWindowLongPtr(nint windowHandle, int index);

		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW", ExactSpelling = true)]
		public static extern nint SetWindowLongPtr(nint windowHandle, int index, nint value);
	}

	private Canvas _canvas;

	private double _frameWidth = 1.0;

	private double _frameHeight = 1.0;

	private double _captureHeight = 1.0;

	private double _captureTop;

	[GeneratedCode("Avalonia.Generators.NameGenerator.InitializeComponentCodeGenerator", "12.1.0.0")]
	internal Canvas OverlayCanvas;

	[CompilerGenerated]
	private static Action<object> _0021XamlIlPopulateOverride;

	public GameVisionOverlay()
	{
		InitializeComponent();
		_canvas = this.FindControl<Canvas>("OverlayCanvas");
		base.Opened += delegate
		{
			ConfigureOverlayWindow();
		};
	}

	public void SetCaptureLayout(double captureHeight, double captureTop)
	{
		_captureHeight = Math.Max(0.0, captureHeight);
		_captureTop = Math.Max(0.0, captureTop);
	}

	public void SetFrame(VisionDebugFrame frame)
	{
		_frameWidth = Math.Max(1, frame.FrameWidth);
		_frameHeight = Math.Max(1, frame.FrameHeight);
		_canvas.Children.Clear();
		double num = base.Width / _frameWidth;
		double num2 = ((_captureHeight > 0.0) ? (_captureHeight / _frameHeight) : 0.0);
		if (_captureHeight > 0.0 && frame.Boxes != null)
		{
			foreach (DetectionDisplayBox box in frame.Boxes)
			{
				IBrush brush = ParseBrush(box.ColorHex);
				Rectangle rectangle = new Rectangle
				{
					Width = Math.Max(1.0, (double)box.Width * num),
					Height = Math.Max(1.0, (double)box.Height * num2),
					Stroke = brush,
					StrokeThickness = 2.0,
					Fill = Brushes.Transparent
				};
				Canvas.SetLeft(rectangle, (double)box.X * num);
				Canvas.SetTop(rectangle, _captureTop + (double)box.Y * num2);
				_canvas.Children.Add(rectangle);
				TextBlock textBlock = new TextBlock
				{
					Text = box.Label,
					Foreground = brush,
					Background = new SolidColorBrush(Color.FromArgb(190, 8, 10, 16)),
					Padding = new Thickness(4.0, 1.0),
					FontSize = 12.0,
					FontWeight = FontWeight.Bold
				};
				Canvas.SetLeft(textBlock, (double)box.X * num);
				Canvas.SetTop(textBlock, Math.Max(_captureTop, _captureTop + (double)box.Y * num2 - 18.0));
				_canvas.Children.Add(textBlock);
			}
		}
		if ((object)frame.BarStrip != null)
		{
			DrawBarStrip(frame.BarStrip, num2);
		}
		if (!string.IsNullOrWhiteSpace(frame.Summary) && _captureTop > 0.0)
		{
			TextBlock textBlock2 = new TextBlock
			{
				Text = frame.Summary,
				Foreground = Brushes.White,
				Background = new SolidColorBrush(Color.FromArgb(200, 8, 12, 24)),
				Padding = new Thickness(8.0, 6.0),
				FontSize = 11.0,
				TextWrapping = TextWrapping.Wrap,
				MaxWidth = Math.Max(120.0, base.Width - 16.0),
				TextTrimming = TextTrimming.CharacterEllipsis
			};
			Canvas.SetLeft(textBlock2, 8.0);
			Canvas.SetTop(textBlock2, 2.0);
			_canvas.Children.Add(textBlock2);
		}
	}

	private void DrawBarStrip(BarStripFrame strip, double scaleY)
	{
		if (_captureTop < 32.0)
		{
			return;
		}
		double num = Math.Min(34.0, _captureTop - 24.0);
		double num2 = _captureTop - num;
		Rectangle rectangle = new Rectangle
		{
			Width = base.Width - 16.0,
			Height = 8.0,
			Fill = new SolidColorBrush(Color.Parse("#1E2A3A")),
			RadiusX = 3.0,
			RadiusY = 3.0
		};
		Canvas.SetLeft(rectangle, 8.0);
		Canvas.SetTop(rectangle, num2 + num / 2.0 - 4.0);
		_canvas.Children.Add(rectangle);
		foreach (BarStripBox allBox in strip.AllBoxes)
		{
			if (double.IsFinite(allBox.Start) && double.IsFinite(allBox.End))
			{
				double value = 8.0 + allBox.Start * (base.Width - 16.0);
				double width = Math.Max(2.0, (allBox.End - allBox.Start) * (base.Width - 16.0));
				int num3 = allBox.Behavior switch
				{
					DetectionBehavior.Control => 20, 
					DetectionBehavior.Pursue => 14, 
					DetectionBehavior.Avoid => 14, 
					_ => 8, 
				};
				IBrush stroke;
				try
				{
					stroke = new SolidColorBrush(Color.Parse(allBox.ColorHex));
				}
				catch
				{
					stroke = Brushes.Gray;
				}
				Rectangle rectangle2 = new Rectangle
				{
					Width = width,
					Height = num3,
					Fill = new SolidColorBrush(Color.FromArgb(160, Color.Parse(allBox.ColorHex).R, Color.Parse(allBox.ColorHex).G, Color.Parse(allBox.ColorHex).B)),
					Stroke = stroke,
					StrokeThickness = 1.5,
					RadiusX = 2.0,
					RadiusY = 2.0
				};
				Canvas.SetLeft(rectangle2, value);
				Canvas.SetTop(rectangle2, num2 + num / 2.0 - (double)num3 / 2.0);
				_canvas.Children.Add(rectangle2);
			}
		}
		if (double.IsFinite(strip.ControlStart) && double.IsFinite(strip.ControlEnd))
		{
			double num4 = 8.0 + strip.ControlStart * (base.Width - 16.0);
			double num5 = 8.0 + strip.ControlEnd * (base.Width - 16.0);
			double[] array = new double[2] { num4, num5 };
			foreach (double x in array)
			{
				Line item = new Line
				{
					StartPoint = new Point(x, num2 + 2.0),
					EndPoint = new Point(x, num2 + num - 2.0),
					Stroke = new SolidColorBrush(Color.Parse("#5FAAFF")),
					StrokeThickness = 2.0
				};
				_canvas.Children.Add(item);
			}
		}
		if (double.IsFinite(strip.TargetCenter))
		{
			double x2 = 8.0 + strip.TargetCenter * (base.Width - 16.0);
			Line item2 = new Line
			{
				StartPoint = new Point(x2, num2 + 2.0),
				EndPoint = new Point(x2, num2 + num - 2.0),
				Stroke = Brushes.White,
				StrokeThickness = 2.5
			};
			_canvas.Children.Add(item2);
		}
	}

	public void Clear()
	{
		_canvas.Children.Clear();
	}

	private static IBrush ParseBrush(string colorHex)
	{
		try
		{
			return new SolidColorBrush(Color.Parse(colorHex));
		}
		catch
		{
			return Brushes.Lime;
		}
	}

	private void InitializeComponent()
	{
		_0021XamlIlPopulateTrampoline(this);
	}

	private void ConfigureOverlayWindow()
	{
		if (OperatingSystem.IsWindows())
		{
			nint? num = TryGetPlatformHandle()?.Handle;
			if (num.HasValue)
			{
				nint windowLongPtr = NativeMethods.GetWindowLongPtr(num.Value, -20);
				NativeMethods.SetWindowLongPtr(num.Value, -20, windowLongPtr | 0x20 | 0x8000000 | 0x80000);
			}
		}
	}

	[GeneratedCode("Avalonia.Generators.NameGenerator.InitializeComponentCodeGenerator", "12.1.0.0")]
	[ExcludeFromCodeCoverage]
	public void InitializeComponent(bool loadXaml = true)
	{
		if (loadXaml)
		{
			_0021XamlIlPopulateTrampoline(this);
		}
		OverlayCanvas = this.FindNameScope()?.Find<Canvas>("OverlayCanvas");
	}

	[CompilerGenerated]
	private static void _0021XamlIlPopulate(IServiceProvider P_0, GameVisionOverlay P_1)
	{
		CompiledAvaloniaXaml.XamlIlContext.Context<GameVisionOverlay> context = new CompiledAvaloniaXaml.XamlIlContext.Context<GameVisionOverlay>(P_0, new object[1] { _0021AvaloniaResources.NamespaceInfo_003A_002FViews_002FGameVisionOverlay_002Eaxaml.Singleton }, "avares://PFMS/Views/GameVisionOverlay.axaml")
		{
			RootObject = P_1,
			IntermediateRoot = P_1
		};
		((ISupportInitialize)P_1).BeginInit();
		P_1.WindowDecorations = WindowDecorations.None;
		P_1.ShowInTaskbar = false;
		P_1.Topmost = true;
		P_1.CanResize = false;
		P_1.ExtendClientAreaToDecorationsHint = true;
		P_1.Background = new ImmutableSolidColorBrush(16777215u);
		P_1.TransparencyLevelHint = new WindowTransparencyLevel[1] { WindowTransparencyLevel.Transparent };
		Canvas canvas2;
		Canvas canvas = (canvas2 = new Canvas());
		((ISupportInitialize)canvas).BeginInit();
		P_1.Content = canvas;
		canvas2.Name = "OverlayCanvas";
		object element = canvas2;
		context.AvaloniaNameScope.Register("OverlayCanvas", element);
		canvas2.Background = new ImmutableSolidColorBrush(16777215u);
		canvas2.IsHitTestVisible = false;
		((ISupportInitialize)canvas2).EndInit();
		((ISupportInitialize)P_1).EndInit();
		if (P_1 is StyledElement styled)
		{
			NameScope.SetNameScope(styled, context.AvaloniaNameScope);
		}
		context.AvaloniaNameScope.Complete();
	}

	[CompilerGenerated]
	private static void _0021XamlIlPopulateTrampoline(GameVisionOverlay P_0)
	{
		if (_0021XamlIlPopulateOverride != null)
		{
			_0021XamlIlPopulateOverride(P_0);
		}
		else
		{
			_0021XamlIlPopulate(XamlIlRuntimeHelpers.CreateRootServiceProviderV3(null), P_0);
		}
	}
}

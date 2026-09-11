using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using CompiledAvaloniaXaml;
using Pfm.Core.Configuration;

namespace Pfm.Views;

public class ScreenRegionSelectionWindow : Window
{
	private Border _selectionBox;

	private Point _start;

	private bool _isSelecting;

	[GeneratedCode("Avalonia.Generators.NameGenerator.InitializeComponentCodeGenerator", "12.1.0.0")]
	internal Canvas SelectionCanvas;

	[GeneratedCode("Avalonia.Generators.NameGenerator.InitializeComponentCodeGenerator", "12.1.0.0")]
	internal Border SelectionBox;

	[CompilerGenerated]
	private static Action<object> _0021XamlIlPopulateOverride;

	public ScreenRegion? SelectedRegion { get; private set; }

	public ScreenRegionSelectionWindow()
	{
		InitializeComponent();
		_selectionBox = this.FindControl<Border>("SelectionBox");
		base.PointerPressed += OnPointerPressed;
		base.PointerMoved += OnPointerMoved;
		base.PointerReleased += OnPointerReleased;
		base.KeyDown += OnKeyDown;
	}

	private void InitializeComponent()
	{
		_0021XamlIlPopulateTrampoline(this);
	}

	private void OnPointerPressed(object? sender, PointerPressedEventArgs args)
	{
		PointerPointProperties properties = args.GetCurrentPoint(this).Properties;
		if (properties.PointerUpdateKind == PointerUpdateKind.RightButtonPressed)
		{
			Close(null);
		}
		else if (properties.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
		{
			_start = args.GetPosition(this);
			_isSelecting = true;
			_selectionBox.IsVisible = true;
			UpdateSelection(_start);
			args.Pointer.Capture(this);
		}
	}

	private void OnPointerMoved(object? sender, PointerEventArgs args)
	{
		if (_isSelecting)
		{
			UpdateSelection(args.GetPosition(this));
		}
	}

	private void OnPointerReleased(object? sender, PointerReleasedEventArgs args)
	{
		if (_isSelecting)
		{
			_isSelecting = false;
			args.Pointer.Capture(null);
			Point position = args.GetPosition(this);
			double num = Math.Min(_start.X, position.X);
			double num2 = Math.Min(_start.Y, position.Y);
			double num3 = Math.Abs(position.X - _start.X);
			double num4 = Math.Abs(position.Y - _start.Y);
			if (num3 < 4.0 || num4 < 4.0)
			{
				_selectionBox.IsVisible = false;
				return;
			}
			double renderScaling = base.RenderScaling;
			SelectedRegion = new ScreenRegion
			{
				IsEnabled = true,
				X = base.Position.X + (int)Math.Round(num * renderScaling),
				Y = base.Position.Y + (int)Math.Round(num2 * renderScaling),
				Width = (int)Math.Round(num3 * renderScaling),
				Height = (int)Math.Round(num4 * renderScaling)
			};
			Close();
		}
	}

	private void OnKeyDown(object? sender, KeyEventArgs args)
	{
		if (args.Key == Key.Escape)
		{
			Close(null);
		}
	}

	private void UpdateSelection(Point current)
	{
		double value = Math.Min(_start.X, current.X);
		double value2 = Math.Min(_start.Y, current.Y);
		Canvas.SetLeft(_selectionBox, value);
		Canvas.SetTop(_selectionBox, value2);
		_selectionBox.Width = Math.Abs(current.X - _start.X);
		_selectionBox.Height = Math.Abs(current.Y - _start.Y);
	}

	[GeneratedCode("Avalonia.Generators.NameGenerator.InitializeComponentCodeGenerator", "12.1.0.0")]
	[ExcludeFromCodeCoverage]
	public void InitializeComponent(bool loadXaml = true)
	{
		if (loadXaml)
		{
			_0021XamlIlPopulateTrampoline(this);
		}
		INameScope nameScope = this.FindNameScope();
		SelectionCanvas = nameScope?.Find<Canvas>("SelectionCanvas");
		SelectionBox = nameScope?.Find<Border>("SelectionBox");
	}

	[CompilerGenerated]
	private static void _0021XamlIlPopulate(IServiceProvider P_0, ScreenRegionSelectionWindow P_1)
	{
		CompiledAvaloniaXaml.XamlIlContext.Context<ScreenRegionSelectionWindow> context = new CompiledAvaloniaXaml.XamlIlContext.Context<ScreenRegionSelectionWindow>(P_0, new object[1] { _0021AvaloniaResources.NamespaceInfo_003A_002FViews_002FScreenRegionSelectionWindow_002Eaxaml.Singleton }, "avares://PFMS/Views/ScreenRegionSelectionWindow.axaml")
		{
			RootObject = P_1,
			IntermediateRoot = P_1
		};
		((ISupportInitialize)P_1).BeginInit();
		P_1.WindowDecorations = WindowDecorations.None;
		P_1.WindowState = WindowState.FullScreen;
		P_1.Topmost = true;
		P_1.ShowInTaskbar = false;
		P_1.Background = new ImmutableSolidColorBrush(1711737620u);
		P_1.Cursor = new Cursor(StandardCursorType.Cross);
		P_1.TransparencyLevelHint = new WindowTransparencyLevel[1] { WindowTransparencyLevel.Transparent };
		Canvas canvas2;
		Canvas canvas = (canvas2 = new Canvas());
		((ISupportInitialize)canvas).BeginInit();
		P_1.Content = canvas;
		canvas2.Name = "SelectionCanvas";
		object element = canvas2;
		context.AvaloniaNameScope.Register("SelectionCanvas", element);
		Controls children = canvas2.Children;
		Border border2;
		Border border = (border2 = new Border());
		((ISupportInitialize)border).BeginInit();
		children.Add(border);
		Canvas.SetLeft(border2, 24.0);
		Canvas.SetTop(border2, 24.0);
		border2.Background = new ImmutableSolidColorBrush(3893829682u);
		border2.BorderBrush = new ImmutableSolidColorBrush(1719307178u);
		border2.BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
		border2.CornerRadius = new CornerRadius(12.0, 12.0, 12.0, 12.0);
		border2.Padding = new Thickness(16.0, 12.0, 16.0, 12.0);
		StackPanel stackPanel2;
		StackPanel stackPanel = (stackPanel2 = new StackPanel());
		((ISupportInitialize)stackPanel).BeginInit();
		border2.Child = stackPanel;
		stackPanel2.Spacing = 4.0;
		Controls children2 = stackPanel2.Children;
		TextBlock textBlock2;
		TextBlock textBlock = (textBlock2 = new TextBlock());
		((ISupportInitialize)textBlock).BeginInit();
		children2.Add(textBlock);
		textBlock2.Text = "Select screen region";
		textBlock2.FontSize = 15.0;
		textBlock2.FontWeight = FontWeight.DemiBold;
		textBlock2.Foreground = new ImmutableSolidColorBrush(uint.MaxValue);
		((ISupportInitialize)textBlock2).EndInit();
		Controls children3 = stackPanel2.Children;
		TextBlock textBlock4;
		TextBlock textBlock3 = (textBlock4 = new TextBlock());
		((ISupportInitialize)textBlock3).BeginInit();
		children3.Add(textBlock3);
		textBlock4.Text = "Drag around the pixels this rule should scan. Press Escape to cancel.";
		textBlock4.FontSize = 11.0;
		textBlock4.Foreground = new ImmutableSolidColorBrush(4290298840u);
		((ISupportInitialize)textBlock4).EndInit();
		((ISupportInitialize)stackPanel2).EndInit();
		((ISupportInitialize)border2).EndInit();
		Controls children4 = canvas2.Children;
		Border border4;
		Border border3 = (border4 = new Border());
		((ISupportInitialize)border3).BeginInit();
		children4.Add(border3);
		border4.Name = "SelectionBox";
		element = border4;
		context.AvaloniaNameScope.Register("SelectionBox", element);
		border4.IsVisible = false;
		border4.Background = new ImmutableSolidColorBrush(860589567u);
		border4.BorderBrush = new ImmutableSolidColorBrush(4289709567u);
		border4.BorderThickness = new Thickness(2.0, 2.0, 2.0, 2.0);
		border4.CornerRadius = new CornerRadius(4.0, 4.0, 4.0, 4.0);
		((ISupportInitialize)border4).EndInit();
		((ISupportInitialize)canvas2).EndInit();
		((ISupportInitialize)P_1).EndInit();
		if (P_1 is StyledElement styled)
		{
			NameScope.SetNameScope(styled, context.AvaloniaNameScope);
		}
		context.AvaloniaNameScope.Complete();
	}

	[CompilerGenerated]
	private static void _0021XamlIlPopulateTrampoline(ScreenRegionSelectionWindow P_0)
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

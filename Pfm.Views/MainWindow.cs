using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.MarkupExtensions.CompiledBindings;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using CompiledAvaloniaXaml;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;
using Pfm.ViewModels;

namespace Pfm.Views;

public class MainWindow : Window
{
	private static class NativeMethods
	{
		[DllImport("dwmapi.dll", EntryPoint = "DwmSetWindowAttribute", ExactSpelling = true)]
		public static extern int DwmSetWindowAttribute(nint hwnd, int attr, ref int value, int size);
	}

	[CompilerGenerated]
	private class XamlClosure_3
	{
		public static object Build_1(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<MainWindow> context = CreateContext(P_0);
			context.IntermediateRoot = new Border();
			object obj = context.IntermediateRoot;
			((ISupportInitialize)obj).BeginInit();
			Border border = (Border)obj;
			context.PushParent(border);
			Border border2 = border;
			border2.Classes.Add("config-card");
			border2.Margin = new Thickness(0.0, 0.0, 0.0, 10.0);
			border2.Padding = new Thickness(12.0, 12.0, 12.0, 12.0);
			Grid grid2;
			Grid grid = (grid2 = new Grid());
			((ISupportInitialize)grid).BeginInit();
			border2.Child = grid;
			Grid grid4;
			Grid grid3 = (grid4 = grid2);
			context.PushParent(grid4);
			Grid grid5 = grid4;
			ColumnDefinitions columnDefinitions = new ColumnDefinitions();
			columnDefinitions.Capacity = 5;
			columnDefinitions.Add(new ColumnDefinition(new GridLength(128.0, GridUnitType.Pixel)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
			grid5.ColumnDefinitions = columnDefinitions;
			grid5.ColumnSpacing = 16.0;
			Controls children = grid5.Children;
			Border border4;
			Border border3 = (border4 = new Border());
			((ISupportInitialize)border3).BeginInit();
			children.Add(border3);
			Border border5 = (border = border4);
			context.PushParent(border);
			Border border6 = border;
			border6.Width = 128.0;
			border6.Height = 78.0;
			border6.CornerRadius = new CornerRadius(6.0, 6.0, 6.0, 6.0);
			border6.Background = new ImmutableSolidColorBrush(4280626752u);
			border6.ClipToBounds = true;
			Grid grid7;
			Grid grid6 = (grid7 = new Grid());
			((ISupportInitialize)grid6).BeginInit();
			border6.Child = grid6;
			Grid grid8 = (grid4 = grid7);
			context.PushParent(grid4);
			Grid grid9 = grid4;
			Controls children2 = grid9.Children;
			TextBlock textBlock2;
			TextBlock textBlock = (textBlock2 = new TextBlock());
			((ISupportInitialize)textBlock).BeginInit();
			children2.Add(textBlock);
			textBlock2.Text = "YOLO";
			textBlock2.Foreground = new ImmutableSolidColorBrush(4285035918u);
			textBlock2.FontWeight = FontWeight.Bold;
			textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
			textBlock2.VerticalAlignment = VerticalAlignment.Center;
			((ISupportInitialize)textBlock2).EndInit();
			Controls children3 = grid9.Children;
			Image image2;
			Image image = (image2 = new Image());
			((ISupportInitialize)image).BeginInit();
			children3.Add(image);
			Image image4;
			Image image3 = (image4 = image2);
			context.PushParent(image4);
			StyledProperty<IImage?> sourceProperty = Image.SourceProperty;
			CompiledBindingExtension compiledBindingExtension = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ECoverImage_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Image.SourceProperty;
			CompiledBinding binding = compiledBindingExtension.ProvideValue(context);
			context.ProvideTargetProperty = null;
			image4.Bind(sourceProperty, binding);
			image4.Stretch = Stretch.UniformToFill;
			image4.Width = 128.0;
			image4.Height = 78.0;
			context.PopParent();
			((ISupportInitialize)image3).EndInit();
			context.PopParent();
			((ISupportInitialize)grid8).EndInit();
			context.PopParent();
			((ISupportInitialize)border5).EndInit();
			Controls children4 = grid5.Children;
			StackPanel stackPanel2;
			StackPanel stackPanel = (stackPanel2 = new StackPanel());
			((ISupportInitialize)stackPanel).BeginInit();
			children4.Add(stackPanel);
			StackPanel stackPanel4;
			StackPanel stackPanel3 = (stackPanel4 = stackPanel2);
			context.PushParent(stackPanel4);
			StackPanel stackPanel5 = stackPanel4;
			Grid.SetColumn(stackPanel5, 1);
			stackPanel5.Spacing = 6.0;
			stackPanel5.VerticalAlignment = VerticalAlignment.Center;
			Controls children5 = stackPanel5.Children;
			StackPanel stackPanel7;
			StackPanel stackPanel6 = (stackPanel7 = new StackPanel());
			((ISupportInitialize)stackPanel6).BeginInit();
			children5.Add(stackPanel6);
			StackPanel stackPanel8 = (stackPanel4 = stackPanel7);
			context.PushParent(stackPanel4);
			StackPanel stackPanel9 = stackPanel4;
			stackPanel9.Orientation = Orientation.Horizontal;
			stackPanel9.Spacing = 8.0;
			Controls children6 = stackPanel9.Children;
			TextBlock textBlock4;
			TextBlock textBlock3 = (textBlock4 = new TextBlock());
			((ISupportInitialize)textBlock3).BeginInit();
			children6.Add(textBlock3);
			TextBlock textBlock6;
			TextBlock textBlock5 = (textBlock6 = textBlock4);
			context.PushParent(textBlock6);
			TextBlock textBlock7 = textBlock6;
			StyledProperty<string?> textProperty = TextBlock.TextProperty;
			CompiledBindingExtension compiledBindingExtension2 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EName_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = TextBlock.TextProperty;
			CompiledBinding binding2 = compiledBindingExtension2.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBlock7.Bind(textProperty, binding2);
			textBlock7.Classes.Add("config-name");
			context.PopParent();
			((ISupportInitialize)textBlock5).EndInit();
			Controls children7 = stackPanel9.Children;
			TextBlock textBlock9;
			TextBlock textBlock8 = (textBlock9 = new TextBlock());
			((ISupportInitialize)textBlock8).BeginInit();
			children7.Add(textBlock8);
			TextBlock textBlock10 = (textBlock6 = textBlock9);
			context.PushParent(textBlock6);
			TextBlock textBlock11 = textBlock6;
			textBlock11.Text = "ACTIVE";
			textBlock11.Classes.Add("active-pill");
			StyledProperty<bool> isVisibleProperty = Visual.IsVisibleProperty;
			CompiledBindingExtension compiledBindingExtension3 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EIsEnabled_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Visual.IsVisibleProperty;
			CompiledBinding binding3 = compiledBindingExtension3.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBlock11.Bind(isVisibleProperty, binding3);
			context.PopParent();
			((ISupportInitialize)textBlock10).EndInit();
			context.PopParent();
			((ISupportInitialize)stackPanel8).EndInit();
			Controls children8 = stackPanel5.Children;
			TextBlock textBlock13;
			TextBlock textBlock12 = (textBlock13 = new TextBlock());
			((ISupportInitialize)textBlock12).BeginInit();
			children8.Add(textBlock12);
			TextBlock textBlock14 = (textBlock6 = textBlock13);
			context.PushParent(textBlock6);
			TextBlock textBlock15 = textBlock6;
			StyledProperty<string?> textProperty2 = TextBlock.TextProperty;
			CompiledBindingExtension compiledBindingExtension4 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EDescription_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = TextBlock.TextProperty;
			CompiledBinding binding4 = compiledBindingExtension4.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBlock15.Bind(textProperty2, binding4);
			textBlock15.Classes.Add("config-description");
			textBlock15.TextWrapping = TextWrapping.Wrap;
			textBlock15.MaxLines = 2;
			context.PopParent();
			((ISupportInitialize)textBlock14).EndInit();
			Controls children9 = stackPanel5.Children;
			TextBlock textBlock17;
			TextBlock textBlock16 = (textBlock17 = new TextBlock());
			((ISupportInitialize)textBlock16).BeginInit();
			children9.Add(textBlock16);
			TextBlock textBlock18 = (textBlock6 = textBlock17);
			context.PushParent(textBlock6);
			TextBlock textBlock19 = textBlock6;
			StyledProperty<string?> textProperty3 = TextBlock.TextProperty;
			CompiledBindingExtension compiledBindingExtension5 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EManagedModelName_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = TextBlock.TextProperty;
			CompiledBinding binding5 = compiledBindingExtension5.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBlock19.Bind(textProperty3, binding5);
			textBlock19.Classes.Add("meta-label");
			textBlock19.TextTrimming = TextTrimming.CharacterEllipsis;
			textBlock19.MaxWidth = 520.0;
			context.PopParent();
			((ISupportInitialize)textBlock18).EndInit();
			context.PopParent();
			((ISupportInitialize)stackPanel3).EndInit();
			Controls children10 = grid5.Children;
			Button button2;
			Button button = (button2 = new Button());
			((ISupportInitialize)button).BeginInit();
			children10.Add(button);
			Button button4;
			Button button3 = (button4 = button2);
			context.PushParent(button4);
			Button button5 = button4;
			Grid.SetColumn(button5, 2);
			button5.Classes.Add("toggle-btn");
			StyledProperty<ICommand?> commandProperty = Button.CommandProperty;
			CompiledBindingExtension compiledBindingExtension6 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EToggleEnabledCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Button.CommandProperty;
			CompiledBinding binding6 = compiledBindingExtension6.ProvideValue(context);
			context.ProvideTargetProperty = null;
			button5.Bind(commandProperty, binding6);
			button5.VerticalAlignment = VerticalAlignment.Center;
			button5.MinWidth = 78.0;
			Grid grid11;
			Grid grid10 = (grid11 = new Grid());
			((ISupportInitialize)grid10).BeginInit();
			button5.Content = grid10;
			Grid grid12 = (grid4 = grid11);
			context.PushParent(grid4);
			Grid grid13 = grid4;
			Controls children11 = grid13.Children;
			TextBlock textBlock21;
			TextBlock textBlock20 = (textBlock21 = new TextBlock());
			((ISupportInitialize)textBlock20).BeginInit();
			children11.Add(textBlock20);
			TextBlock textBlock22 = (textBlock6 = textBlock21);
			context.PushParent(textBlock6);
			TextBlock textBlock23 = textBlock6;
			textBlock23.Text = "Enabled";
			StyledProperty<bool> isVisibleProperty2 = Visual.IsVisibleProperty;
			CompiledBindingExtension compiledBindingExtension7 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EIsEnabled_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Visual.IsVisibleProperty;
			CompiledBinding binding7 = compiledBindingExtension7.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBlock23.Bind(isVisibleProperty2, binding7);
			context.PopParent();
			((ISupportInitialize)textBlock22).EndInit();
			Controls children12 = grid13.Children;
			TextBlock textBlock25;
			TextBlock textBlock24 = (textBlock25 = new TextBlock());
			((ISupportInitialize)textBlock24).BeginInit();
			children12.Add(textBlock24);
			TextBlock textBlock26 = (textBlock6 = textBlock25);
			context.PushParent(textBlock6);
			TextBlock textBlock27 = textBlock6;
			textBlock27.Text = "Disabled";
			StyledProperty<bool> isVisibleProperty3 = Visual.IsVisibleProperty;
			CompiledBindingExtension compiledBindingExtension8 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EIsDisabled_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Visual.IsVisibleProperty;
			CompiledBinding binding8 = compiledBindingExtension8.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBlock27.Bind(isVisibleProperty3, binding8);
			context.PopParent();
			((ISupportInitialize)textBlock26).EndInit();
			context.PopParent();
			((ISupportInitialize)grid12).EndInit();
			context.PopParent();
			((ISupportInitialize)button3).EndInit();
			Controls children13 = grid5.Children;
			Button button7;
			Button button6 = (button7 = new Button());
			((ISupportInitialize)button6).BeginInit();
			children13.Add(button6);
			Button button8 = (button4 = button7);
			context.PushParent(button4);
			Button button9 = button4;
			Grid.SetColumn(button9, 3);
			button9.Classes.Add("ghost-button");
			StyledProperty<ICommand?> commandProperty2 = Button.CommandProperty;
			CompiledBindingExtension compiledBindingExtension9 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EEditCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Button.CommandProperty;
			CompiledBinding binding9 = compiledBindingExtension9.ProvideValue(context);
			context.ProvideTargetProperty = null;
			button9.Bind(commandProperty2, binding9);
			button9.VerticalAlignment = VerticalAlignment.Center;
			button9.Content = "Edit";
			context.PopParent();
			((ISupportInitialize)button8).EndInit();
			Controls children14 = grid5.Children;
			Button button11;
			Button button10 = (button11 = new Button());
			((ISupportInitialize)button10).BeginInit();
			children14.Add(button10);
			Button button12 = (button4 = button11);
			context.PushParent(button4);
			Button button13 = button4;
			Grid.SetColumn(button13, 4);
			button13.Classes.Add("ghost-button");
			StyledProperty<ICommand?> commandProperty3 = Button.CommandProperty;
			CompiledBindingExtension compiledBindingExtension10 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Ancestor(typeof(Window), 0).Property(StyledElement.DataContextProperty, PropertyInfoAccessorFactory.CreateAvaloniaPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EExportProfileCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor)
				.Build());
			context.ProvideTargetProperty = Button.CommandProperty;
			CompiledBinding binding10 = compiledBindingExtension10.ProvideValue(context);
			context.ProvideTargetProperty = null;
			button13.Bind(commandProperty3, binding10);
			CompiledBindingExtension compiledBindingExtension11 = new CompiledBindingExtension();
			context.ProvideTargetProperty = Button.CommandParameterProperty;
			CompiledBinding compiledBinding = compiledBindingExtension11.ProvideValue(context);
			context.ProvideTargetProperty = null;
			CompiledAvaloniaXaml.XamlDynamicSetters._003C_003EXamlDynamicSetter_2(button13, compiledBinding);
			button13.VerticalAlignment = VerticalAlignment.Center;
			button13.Content = "Export";
			context.PopParent();
			((ISupportInitialize)button12).EndInit();
			context.PopParent();
			((ISupportInitialize)grid3).EndInit();
			context.PopParent();
			((ISupportInitialize)obj).EndInit();
			return obj;
		}

		public static CompiledAvaloniaXaml.XamlIlContext.Context<MainWindow> CreateContext(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<MainWindow> context = new CompiledAvaloniaXaml.XamlIlContext.Context<MainWindow>(P_0, new object[1] { _0021AvaloniaResources.NamespaceInfo_003A_002FViews_002FMainWindow_002Eaxaml.Singleton }, "avares://PFMS/Views/MainWindow.axaml");
			if (P_0 != null)
			{
				object service = P_0.GetService(typeof(IRootObjectProvider));
				if (service != null)
				{
					service = ((IRootObjectProvider)service).RootObject;
					context.RootObject = (MainWindow)service;
				}
			}
			return context;
		}

		public static object Build_2(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<MainWindow> context = CreateContext(P_0);
			context.IntermediateRoot = new Grid();
			object obj = context.IntermediateRoot;
			((ISupportInitialize)obj).BeginInit();
			Grid grid = (Grid)obj;
			context.PushParent(grid);
			ColumnDefinitions columnDefinitions = new ColumnDefinitions();
			columnDefinitions.Capacity = 8;
			columnDefinitions.Add(new ColumnDefinition(new GridLength(64.0, GridUnitType.Pixel)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(160.0, GridUnitType.Pixel)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(120.0, GridUnitType.Pixel)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(72.0, GridUnitType.Pixel)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
			columnDefinitions.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
			grid.ColumnDefinitions = columnDefinitions;
			grid.ColumnSpacing = 8.0;
			grid.Margin = new Thickness(0.0, 2.0, 0.0, 0.0);
			Controls children = grid.Children;
			TextBox textBox2;
			TextBox textBox = (textBox2 = new TextBox());
			((ISupportInitialize)textBox).BeginInit();
			children.Add(textBox);
			TextBox textBox4;
			TextBox textBox3 = (textBox4 = textBox2);
			context.PushParent(textBox4);
			TextBox textBox5 = textBox4;
			textBox5.Classes.Add("editor-input");
			StyledProperty<string?> textProperty = TextBox.TextProperty;
			CompiledBindingExtension obj2 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EId_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
			{
				Mode = BindingMode.TwoWay
			};
			context.ProvideTargetProperty = TextBox.TextProperty;
			CompiledBinding binding = obj2.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBox5.Bind(textProperty, binding);
			textBox5.PlaceholderText = "ID";
			context.PopParent();
			((ISupportInitialize)textBox3).EndInit();
			Controls children2 = grid.Children;
			TextBox textBox7;
			TextBox textBox6 = (textBox7 = new TextBox());
			((ISupportInitialize)textBox6).BeginInit();
			children2.Add(textBox6);
			TextBox textBox8 = (textBox4 = textBox7);
			context.PushParent(textBox4);
			TextBox textBox9 = textBox4;
			Grid.SetColumn(textBox9, 1);
			textBox9.Classes.Add("editor-input");
			StyledProperty<string?> textProperty2 = TextBox.TextProperty;
			CompiledBindingExtension obj3 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EName_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
			{
				Mode = BindingMode.TwoWay
			};
			context.ProvideTargetProperty = TextBox.TextProperty;
			CompiledBinding binding2 = obj3.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBox9.Bind(textProperty2, binding2);
			textBox9.PlaceholderText = "Name";
			context.PopParent();
			((ISupportInitialize)textBox8).EndInit();
			Controls children3 = grid.Children;
			ComboBox comboBox2;
			ComboBox comboBox = (comboBox2 = new ComboBox());
			((ISupportInitialize)comboBox).BeginInit();
			children3.Add(comboBox);
			ComboBox comboBox4;
			ComboBox comboBox3 = (comboBox4 = comboBox2);
			context.PushParent(comboBox4);
			Grid.SetColumn(comboBox4, 2);
			comboBox4.Classes.Add("builder-select");
			StyledProperty<IEnumerable?> itemsSourceProperty = ItemsControl.ItemsSourceProperty;
			CompiledBindingExtension compiledBindingExtension = new CompiledBindingExtension(new CompiledBindingPathBuilder().Ancestor(typeof(Window), 0).Property(StyledElement.DataContextProperty, PropertyInfoAccessorFactory.CreateAvaloniaPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor)
				.Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EDetectionBehaviorOptions_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor)
				.Build());
			context.ProvideTargetProperty = ItemsControl.ItemsSourceProperty;
			CompiledBinding binding3 = compiledBindingExtension.ProvideValue(context);
			context.ProvideTargetProperty = null;
			comboBox4.Bind(itemsSourceProperty, binding3);
			CompiledBindingExtension obj4 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EBehavior_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
			{
				Mode = BindingMode.TwoWay
			};
			context.ProvideTargetProperty = SelectingItemsControl.SelectedItemProperty;
			CompiledBinding compiledBinding = obj4.ProvideValue(context);
			context.ProvideTargetProperty = null;
			CompiledAvaloniaXaml.XamlDynamicSetters._003C_003EXamlDynamicSetter_3(comboBox4, compiledBinding);
			context.PopParent();
			((ISupportInitialize)comboBox3).EndInit();
			Controls children4 = grid.Children;
			TextBox textBox11;
			TextBox textBox10 = (textBox11 = new TextBox());
			((ISupportInitialize)textBox10).BeginInit();
			children4.Add(textBox10);
			TextBox textBox12 = (textBox4 = textBox11);
			context.PushParent(textBox4);
			TextBox textBox13 = textBox4;
			Grid.SetColumn(textBox13, 3);
			textBox13.Classes.Add("editor-input");
			StyledProperty<string?> textProperty3 = TextBox.TextProperty;
			CompiledBindingExtension obj5 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EWeight_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
			{
				Mode = BindingMode.TwoWay
			};
			context.ProvideTargetProperty = TextBox.TextProperty;
			CompiledBinding binding4 = obj5.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBox13.Bind(textProperty3, binding4);
			textBox13.PlaceholderText = "Blend";
			ToolTip.SetTip(textBox13, "Relative priority when multiple Pursue or Avoid detections are combined. It has no effect with only one Pursue target.");
			context.PopParent();
			((ISupportInitialize)textBox12).EndInit();
			Controls children5 = grid.Children;
			TextBox textBox15;
			TextBox textBox14 = (textBox15 = new TextBox());
			((ISupportInitialize)textBox14).BeginInit();
			children5.Add(textBox14);
			TextBox textBox16 = (textBox4 = textBox15);
			context.PushParent(textBox4);
			TextBox textBox17 = textBox4;
			Grid.SetColumn(textBox17, 4);
			textBox17.Classes.Add("editor-input");
			StyledProperty<string?> textProperty4 = TextBox.TextProperty;
			CompiledBindingExtension obj6 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EInfluenceFormula_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
			{
				Mode = BindingMode.TwoWay
			};
			context.ProvideTargetProperty = TextBox.TextProperty;
			CompiledBinding binding5 = obj6.ProvideValue(context);
			context.ProvideTargetProperty = null;
			textBox17.Bind(textProperty4, binding5);
			textBox17.PlaceholderText = "Optional influence formula";
			context.PopParent();
			((ISupportInitialize)textBox16).EndInit();
			Controls children6 = grid.Children;
			Button button2;
			Button button = (button2 = new Button());
			((ISupportInitialize)button).BeginInit();
			children6.Add(button);
			Button button4;
			Button button3 = (button4 = button2);
			context.PushParent(button4);
			Button button5 = button4;
			Grid.SetColumn(button5, 5);
			button5.Classes.Add("ghost-button");
			StyledProperty<ICommand?> commandProperty = Button.CommandProperty;
			CompiledBindingExtension compiledBindingExtension2 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EPickColorCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Button.CommandProperty;
			CompiledBinding binding6 = compiledBindingExtension2.ProvideValue(context);
			context.ProvideTargetProperty = null;
			button5.Bind(commandProperty, binding6);
			ToolTip.SetTip(button5, "Pick color to filter by detection color hint");
			button5.Width = 80.0;
			button5.Padding = new Thickness(6.0, 4.0, 6.0, 4.0);
			StackPanel stackPanel2;
			StackPanel stackPanel = (stackPanel2 = new StackPanel());
			((ISupportInitialize)stackPanel).BeginInit();
			button5.Content = stackPanel;
			StackPanel stackPanel4;
			StackPanel stackPanel3 = (stackPanel4 = stackPanel2);
			context.PushParent(stackPanel4);
			stackPanel4.Orientation = Orientation.Horizontal;
			stackPanel4.Spacing = 6.0;
			Controls children7 = stackPanel4.Children;
			Border border2;
			Border border = (border2 = new Border());
			((ISupportInitialize)border).BeginInit();
			children7.Add(border);
			Border border4;
			Border border3 = (border4 = border2);
			context.PushParent(border4);
			border4.Width = 16.0;
			border4.Height = 16.0;
			border4.CornerRadius = new CornerRadius(2.0, 2.0, 2.0, 2.0);
			SolidColorBrush solidColorBrush;
			SolidColorBrush background = (solidColorBrush = new SolidColorBrush());
			context.PushParent(solidColorBrush);
			StyledProperty<Color> colorProperty = SolidColorBrush.ColorProperty;
			CompiledBindingExtension compiledBindingExtension4;
			CompiledBindingExtension compiledBindingExtension3 = (compiledBindingExtension4 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EColorHintSwatch_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build()));
			context.PushParent(compiledBindingExtension4);
			StaticResourceExtension staticResourceExtension = new StaticResourceExtension("HexToColorConverter");
			context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EData_002ECompiledBinding_002CAvalonia_002EBase_002EConverter_0021Property();
			object? obj7 = staticResourceExtension.ProvideValue(context);
			context.ProvideTargetProperty = null;
			compiledBindingExtension4.Converter = (IValueConverter)obj7;
			context.PopParent();
			context.ProvideTargetProperty = SolidColorBrush.ColorProperty;
			CompiledBinding binding7 = compiledBindingExtension3.ProvideValue(context);
			context.ProvideTargetProperty = null;
			solidColorBrush.Bind(colorProperty, binding7);
			context.PopParent();
			border4.Background = background;
			context.PopParent();
			((ISupportInitialize)border3).EndInit();
			Controls children8 = stackPanel4.Children;
			TextBlock textBlock2;
			TextBlock textBlock = (textBlock2 = new TextBlock());
			((ISupportInitialize)textBlock).BeginInit();
			children8.Add(textBlock);
			textBlock2.Text = "Color";
			((ISupportInitialize)textBlock2).EndInit();
			context.PopParent();
			((ISupportInitialize)stackPanel3).EndInit();
			context.PopParent();
			((ISupportInitialize)button3).EndInit();
			Controls children9 = grid.Children;
			Button button7;
			Button button6 = (button7 = new Button());
			((ISupportInitialize)button6).BeginInit();
			children9.Add(button6);
			Button button8 = (button4 = button7);
			context.PushParent(button4);
			Button button9 = button4;
			Grid.SetColumn(button9, 6);
			button9.Classes.Add("ghost-button");
			StyledProperty<ICommand?> commandProperty2 = Button.CommandProperty;
			CompiledBindingExtension compiledBindingExtension5 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EClearColorCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Button.CommandProperty;
			CompiledBinding binding8 = compiledBindingExtension5.ProvideValue(context);
			context.ProvideTargetProperty = null;
			button9.Bind(commandProperty2, binding8);
			ToolTip.SetTip(button9, "Clear color hint filter");
			StyledProperty<bool> isVisibleProperty = Visual.IsVisibleProperty;
			CompiledBindingExtension compiledBindingExtension6 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EDetectionClassViewModel_002CPFMS_002EHasColorHint_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
			context.ProvideTargetProperty = Visual.IsVisibleProperty;
			CompiledBinding binding9 = compiledBindingExtension6.ProvideValue(context);
			context.ProvideTargetProperty = null;
			button9.Bind(isVisibleProperty, binding9);
			button9.Content = "Clear";
			context.PopParent();
			((ISupportInitialize)button8).EndInit();
			Controls children10 = grid.Children;
			Button button11;
			Button button10 = (button11 = new Button());
			((ISupportInitialize)button10).BeginInit();
			children10.Add(button10);
			Button button12 = (button4 = button11);
			context.PushParent(button4);
			Button button13 = button4;
			Grid.SetColumn(button13, 7);
			button13.Classes.Add("ghost-button");
			StyledProperty<ICommand?> commandProperty3 = Button.CommandProperty;
			CompiledBindingExtension compiledBindingExtension7 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Ancestor(typeof(Window), 0).Property(StyledElement.DataContextProperty, PropertyInfoAccessorFactory.CreateAvaloniaPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor)
				.Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ERemoveCustomClassCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor)
				.Build());
			context.ProvideTargetProperty = Button.CommandProperty;
			CompiledBinding binding10 = compiledBindingExtension7.ProvideValue(context);
			context.ProvideTargetProperty = null;
			button13.Bind(commandProperty3, binding10);
			CompiledBindingExtension compiledBindingExtension8 = new CompiledBindingExtension();
			context.ProvideTargetProperty = Button.CommandParameterProperty;
			CompiledBinding compiledBinding2 = compiledBindingExtension8.ProvideValue(context);
			context.ProvideTargetProperty = null;
			CompiledAvaloniaXaml.XamlDynamicSetters._003C_003EXamlDynamicSetter_2(button13, compiledBinding2);
			button13.Content = "Remove";
			context.PopParent();
			((ISupportInitialize)button12).EndInit();
			context.PopParent();
			((ISupportInitialize)obj).EndInit();
			return obj;
		}
	}

	private Canvas? _barStripCanvas;

	private Grid? _rodCatalogView;

	[CompilerGenerated]
	private static Action<object> _0021XamlIlPopulateOverride;

	public MainWindow()
	{
		InitializeComponent();
		base.Opened += OnOpened;
	}

	protected override void OnDataContextChanged(EventArgs e)
	{
		base.OnDataContextChanged(e);
		if (base.DataContext is MainViewModel mainViewModel)
		{
			mainViewModel.PropertyChanged += OnViewModelPropertyChanged;
			BuildRodCatalog(mainViewModel);
		}
	}

	private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsEditorOpen" && _rodCatalogView != null && sender is MainViewModel viewModel)
		{
			_rodCatalogView.IsVisible = !viewModel.IsEditorOpen;
		}
		if (e.PropertyName == "VisionBarStrip")
		{
			if (_barStripCanvas == null)
			{
				_barStripCanvas = this.FindControl<Canvas>("BarStripCanvas");
			}
			if (_barStripCanvas != null && sender is MainViewModel mainViewModel)
			{
				RenderBarStrip(_barStripCanvas, mainViewModel.VisionBarStrip);
			}
		}
	}

	private void BuildRodCatalog(MainViewModel viewModel)
	{
		if (_rodCatalogView != null || base.Content is not Border shell || shell.Child is not Grid shellGrid)
		{
			return;
		}

		Grid catalog = new Grid
		{
			Background = new SolidColorBrush(Color.Parse("#0B0D0D")),
			RowDefinitions = new RowDefinitions("58,*,34"),
			Margin = new Thickness(0),
			IsVisible = !viewModel.IsEditorOpen
		};
		Grid.SetRow(catalog, 1);
		shellGrid.Children.Add(catalog);
		_rodCatalogView = catalog;

		Grid toolbar = new Grid
		{
			Background = new SolidColorBrush(Color.Parse("#111615")),
			ColumnDefinitions = new ColumnDefinitions("220,Auto,*,Auto,Auto"),
			Margin = new Thickness(0, 0, 0, 1)
		};
		catalog.Children.Add(toolbar);

		ComboBox category = new ComboBox
		{
			Classes = { "catalog-category" },
			ItemsSource = new[] { "Fishing Rods", "Harpoon Guns", "Spears" },
			SelectedIndex = 0,
			Margin = new Thickness(14, 9, 10, 9),
			HorizontalContentAlignment = HorizontalAlignment.Left
		};
		toolbar.Children.Add(category);

		TextBlock unlocked = new TextBlock
		{
			Text = "64% Unlocked",
			FontStyle = FontStyle.Italic,
			VerticalAlignment = VerticalAlignment.Center,
			Foreground = new SolidColorBrush(Color.Parse("#C5FF6D")),
			FontWeight = FontWeight.SemiBold
		};
		Grid.SetColumn(unlocked, 1);
		toolbar.Children.Add(unlocked);

		TextBox search = new TextBox
		{
			Watermark = "Search Rods...",
			Margin = new Thickness(12, 10, 8, 10),
			HorizontalContentAlignment = HorizontalAlignment.Left,
			Classes = { "catalog-search" }
		};
		Grid.SetColumn(search, 2);
		toolbar.Children.Add(search);

		Button viewMode = new Button
		{
			Content = "▦",
			Classes = { "catalog-icon-button" },
			Margin = new Thickness(4, 9, 4, 9)
		};
		ToolTip.SetTip(viewMode, "Toggle catalog view");
		Grid.SetColumn(viewMode, 3);
		toolbar.Children.Add(viewMode);

		Button menu = new Button
		{
			Content = "☰",
			Classes = { "catalog-icon-button" },
			Margin = new Thickness(4, 9, 12, 9)
		};
		ToolTip.SetTip(menu, "Open menu");
		menu.Click += (_, _) => category.IsDropDownOpen = !category.IsDropDownOpen;
		Grid.SetColumn(menu, 4);
		toolbar.Children.Add(menu);

		ScrollViewer rail = new ScrollViewer
		{
			HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
			VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
			Padding = new Thickness(14, 12, 14, 8)
		};
		Grid.SetRow(rail, 1);
		catalog.Children.Add(rail);

		ItemsControl rods = new ItemsControl
		{
			ItemsPanel = new FuncTemplate<Panel>(() => new WrapPanel { Orientation = Orientation.Horizontal, ItemWidth = 244, ItemHeight = 520 }),
			ItemTemplate = new FuncDataTemplate<ConfigurationItemViewModel>((item, _) => BuildRodCard(item), supportsRecycling: false)
		};
		rods.ItemsSource = viewModel.Configurations;
		search.TextChanged += (_, _) =>
		{
			string query = search.Text?.Trim() ?? string.Empty;
			rods.ItemsSource = string.IsNullOrEmpty(query)
				? viewModel.Configurations
				: viewModel.Configurations.Where(rod => rod.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToArray();
		};
		rail.Content = rods;

		Grid footer = new Grid
		{
			ColumnDefinitions = new ColumnDefinitions("*,Auto"),
			Background = new SolidColorBrush(Color.Parse("#111615")),
			Margin = new Thickness(16, 0)
		};
		Grid.SetRow(footer, 2);
		catalog.Children.Add(footer);
		TextBlock footerText = new TextBlock
		{
			Text = "PFMS / FISHING RODS",
			VerticalAlignment = VerticalAlignment.Center,
			Foreground = new SolidColorBrush(Color.Parse("#66736B")),
			FontSize = 10,
			LetterSpacing = 1.2
		};
		footer.Children.Add(footerText);
		TextBlock count = new TextBlock
		{
			VerticalAlignment = VerticalAlignment.Center,
			Foreground = new SolidColorBrush(Color.Parse("#8A968F")),
			FontSize = 11
		};
		count.Text = viewModel.ConfigurationCount + " rods";
		Grid.SetColumn(count, 1);
		footer.Children.Add(count);
	}

	private static Control BuildRodCard(ConfigurationItemViewModel item)
	{
		Border card = new Border
		{
			Background = new SolidColorBrush(Color.Parse("#151C19")),
			BorderBrush = new SolidColorBrush(Color.Parse("#425048")),
			BorderThickness = new Thickness(1),
			Margin = new Thickness(0, 0, 12, 0),
			Padding = new Thickness(10),
			CornerRadius = new CornerRadius(2)
		};
		Grid body = new Grid
		{
			RowDefinitions = new RowDefinitions("* ,Auto,Auto"),
			MinWidth = 220
		};
		card.Child = body;

		Grid imageFrame = new Grid { Background = new SolidColorBrush(Color.Parse("#080A0A")) };
		Image image = new Image { Stretch = Stretch.Uniform, Opacity = 0.95 };
		image.Source = item.CoverImage;
		imageFrame.Children.Add(image);
		StackPanel imageStats = new StackPanel { Margin = new Thickness(8), Spacing = 3, VerticalAlignment = VerticalAlignment.Top };
		imageStats.Children.Add(BoundText("Model", item.Model.Fishing.Mode.ToString(), "#C5FF6D"));
		imageStats.Children.Add(BoundText("FPS", item.Model.Fishing.Rod.TargetFramesPerSecond.ToString(), "#E9F0E8"));
		imageStats.Children.Add(BoundText("AI class", item.Model.Fishing.TargetClassId.ToString(), "#E9F0E8"));
		imageFrame.Children.Add(imageStats);
		Grid.SetRow(imageFrame, 0);
		body.Children.Add(imageFrame);

		StackPanel caption = new StackPanel { Margin = new Thickness(4, 10, 4, 8), Spacing = 4 };
		TextBlock name = new TextBlock { FontSize = 15, FontWeight = FontWeight.Bold, Foreground = new SolidColorBrush(Color.Parse("#E9F0E8")), TextWrapping = TextWrapping.Wrap };
		name.Text = item.Name;
		caption.Children.Add(name);
		TextBlock description = new TextBlock { FontSize = 10, Foreground = new SolidColorBrush(Color.Parse("#8A968F")), TextWrapping = TextWrapping.Wrap, MaxHeight = 34 };
		description.Text = item.Description;
		caption.Children.Add(description);
		Grid.SetRow(caption, 1);
		body.Children.Add(caption);

		Grid actions = new Grid { ColumnDefinitions = new ColumnDefinitions("Auto,Auto,*,Auto"), ColumnSpacing = 5 };
		Button favorite = new Button { Content = "☆", Classes = { "catalog-icon-button" } };
		ToolTip.SetTip(favorite, "Favorite");
		actions.Children.Add(favorite);
		Button edit = new Button { Content = "✎", Classes = { "catalog-icon-button" } };
		ToolTip.SetTip(edit, "Edit rod configuration");
		edit.Command = item.EditCommand;
		Grid.SetColumn(edit, 1);
		actions.Children.Add(edit);
		Button equip = new Button { Content = "[Equip]", Classes = { "equip-button" }, HorizontalAlignment = HorizontalAlignment.Stretch };
		equip.Command = item.ToggleEnabledCommand;
		Grid.SetColumn(equip, 3);
		actions.Children.Add(equip);
		Grid.SetRow(actions, 2);
		body.Children.Add(actions);
		return card;
	}

	private static TextBlock BoundText(string label, string value, string color)
	{
		TextBlock text = new TextBlock { FontSize = 10, Foreground = new SolidColorBrush(Color.Parse(color)), FontStyle = FontStyle.Italic };
		text.Text = label + ": " + value;
		return text;
	}

	private static void RenderBarStrip(Canvas canvas, BarStripFrame? strip)
	{
		canvas.Children.Clear();
		double width = canvas.Bounds.Width;
		double height = canvas.Bounds.Height;
		if (width <= 0.0 || height <= 0.0)
		{
			return;
		}
		Rectangle rectangle = new Rectangle
		{
			Width = width,
			Height = 8.0,
			Fill = new SolidColorBrush(Color.Parse("#1E2A3A")),
			RadiusX = 3.0,
			RadiusY = 3.0
		};
		Canvas.SetLeft(rectangle, 0.0);
		Canvas.SetTop(rectangle, height / 2.0 - 4.0);
		canvas.Children.Add(rectangle);
		if ((object)strip == null)
		{
			return;
		}
		foreach (BarStripBox allBox in strip.AllBoxes)
		{
			if (double.IsFinite(allBox.Start) && double.IsFinite(allBox.End))
			{
				double num = allBox.Start * width;
				double width2 = Math.Max(2.0, (allBox.End - allBox.Start) * width);
				int num2 = allBox.Behavior switch
				{
					DetectionBehavior.Control => 20, 
					DetectionBehavior.Pursue => 14, 
					DetectionBehavior.Avoid => 14, 
					_ => 8, 
				};
				IBrush brush;
				try
				{
					brush = new SolidColorBrush(Color.Parse(allBox.ColorHex));
				}
				catch
				{
					brush = Brushes.Gray;
				}
				Rectangle rectangle2 = new Rectangle
				{
					Width = width2,
					Height = num2,
					Fill = new SolidColorBrush(Color.FromArgb(160, Color.Parse(allBox.ColorHex).R, Color.Parse(allBox.ColorHex).G, Color.Parse(allBox.ColorHex).B)),
					Stroke = brush,
					StrokeThickness = 1.5,
					RadiusX = 2.0,
					RadiusY = 2.0
				};
				Canvas.SetLeft(rectangle2, num);
				Canvas.SetTop(rectangle2, height / 2.0 - (double)num2 / 2.0);
				canvas.Children.Add(rectangle2);
				TextBlock textBlock = new TextBlock
				{
					Text = allBox.Label,
					Foreground = brush,
					Background = new SolidColorBrush(Color.FromArgb(180, 8, 12, 20)),
					FontSize = 10.0,
					Padding = new Thickness(3.0, 1.0)
				};
				Canvas.SetLeft(textBlock, Math.Min(num, width - 80.0));
				Canvas.SetTop(textBlock, height / 2.0 - (double)num2 / 2.0 - 16.0);
				canvas.Children.Add(textBlock);
			}
		}
		if (double.IsFinite(strip.ControlStart) && double.IsFinite(strip.ControlEnd))
		{
			double num3 = strip.ControlStart * width;
			double num4 = strip.ControlEnd * width;
			double[] array = new double[2] { num3, num4 };
			foreach (double x in array)
			{
				Line item = new Line
				{
					StartPoint = new Point(x, 4.0),
					EndPoint = new Point(x, height - 4.0),
					Stroke = new SolidColorBrush(Color.Parse("#5FAAFF")),
					StrokeThickness = 2.0
				};
				canvas.Children.Add(item);
			}
		}
		if (double.IsFinite(strip.TargetCenter))
		{
			double x2 = strip.TargetCenter * width;
			Line item2 = new Line
			{
				StartPoint = new Point(x2, 2.0),
				EndPoint = new Point(x2, height - 2.0),
				Stroke = Brushes.White,
				StrokeThickness = 2.5
			};
			canvas.Children.Add(item2);
		}
	}

	private void OnOpened(object? sender, EventArgs args)
	{
		if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000))
		{
			nint? num = TryGetPlatformHandle()?.Handle;
			if (num.HasValue)
			{
				int value = 2;
				NativeMethods.DwmSetWindowAttribute(num.Value, 33, ref value, 4);
			}
		}
	}

	private void OnTitleBarPointerPressed(object? sender, PointerPressedEventArgs args)
	{
		if (args.GetCurrentPoint(sender as Control).Properties.IsLeftButtonPressed)
		{
			BeginMoveDrag(args);
		}
	}

	private void OnHelpClick(object? sender, RoutedEventArgs args)
	{
		new HelpWindow().ShowDialog(this);
	}

	private void OnMinimizeClick(object? sender, RoutedEventArgs args)
	{
		base.WindowState = WindowState.Minimized;
	}

	private void OnCloseClick(object? sender, RoutedEventArgs args)
	{
		Close();
	}

	[GeneratedCode("Avalonia.Generators.NameGenerator.InitializeComponentCodeGenerator", "12.1.0.0")]
	[ExcludeFromCodeCoverage]
	public void InitializeComponent(bool loadXaml = true)
	{
		if (loadXaml)
		{
			_0021XamlIlPopulateTrampoline(this);
		}
	}

	[CompilerGenerated]
	private unsafe static void _0021XamlIlPopulate(IServiceProvider P_0, MainWindow P_1)
	{
		CompiledAvaloniaXaml.XamlIlContext.Context<MainWindow> context = new CompiledAvaloniaXaml.XamlIlContext.Context<MainWindow>(P_0, new object[1] { _0021AvaloniaResources.NamespaceInfo_003A_002FViews_002FMainWindow_002Eaxaml.Singleton }, "avares://PFMS/Views/MainWindow.axaml")
		{
			RootObject = P_1,
			IntermediateRoot = P_1
		};
		((ISupportInitialize)P_1).BeginInit();
		context.PushParent(P_1);
		P_1.Icon = (WindowIcon)new IconTypeConverter().ConvertFrom(context, CultureInfo.InvariantCulture, "/Assets/avalonia-logo.ico");
		P_1.Title = "PFMS | Fishing Macro Studio";
		P_1.Width = 1360.0;
		P_1.Height = 860.0;
		P_1.MinWidth = 1040.0;
		P_1.MinHeight = 700.0;
		P_1.WindowDecorations = WindowDecorations.None;
		P_1.CanResize = true;
		P_1.Background = new ImmutableSolidColorBrush(4278914317u);
		P_1.TransparencyLevelHint = new WindowTransparencyLevel[2]
		{
			WindowTransparencyLevel.AcrylicBlur,
			WindowTransparencyLevel.Blur
		};
		Border border2;
		Border border = (border2 = new Border());
		((ISupportInitialize)border).BeginInit();
		P_1.Content = border;
		Border border4;
		Border border3 = (border4 = border2);
		context.PushParent(border4);
		Border border5 = border4;
		border5.Classes.Add("glass-shell");
		border5.CornerRadius = new CornerRadius(2.0, 2.0, 2.0, 2.0);
		border5.Padding = new Thickness(1.0, 1.0, 1.0, 1.0);
		Grid grid2;
		Grid grid = (grid2 = new Grid());
		((ISupportInitialize)grid).BeginInit();
		border5.Child = grid;
		Grid grid4;
		Grid grid3 = (grid4 = grid2);
		context.PushParent(grid4);
		Grid grid5 = grid4;
		RowDefinitions rowDefinitions = new RowDefinitions();
		rowDefinitions.Capacity = 2;
		rowDefinitions.Add(new RowDefinition(new GridLength(42.0, GridUnitType.Pixel)));
		rowDefinitions.Add(new RowDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid5.RowDefinitions = rowDefinitions;
		Controls children = grid5.Children;
		Grid grid7;
		Grid grid6 = (grid7 = new Grid());
		((ISupportInitialize)grid6).BeginInit();
		children.Add(grid6);
		grid7.Background = new ImmutableSolidColorBrush(3289783596u);
		grid7.AddHandler(InputElement.PointerPressedEvent, context.RootObject.OnTitleBarPointerPressed);
		Controls children2 = grid7.Children;
		Grid grid9;
		Grid grid8 = (grid9 = new Grid());
		((ISupportInitialize)grid8).BeginInit();
		children2.Add(grid8);
		ColumnDefinitions columnDefinitions = new ColumnDefinitions();
		columnDefinitions.Capacity = 2;
		columnDefinitions.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid9.ColumnDefinitions = columnDefinitions;
		grid9.Margin = new Thickness(18.0, 0.0, 8.0, 0.0);
		Controls children3 = grid9.Children;
		StackPanel stackPanel2;
		StackPanel stackPanel = (stackPanel2 = new StackPanel());
		((ISupportInitialize)stackPanel).BeginInit();
		children3.Add(stackPanel);
		stackPanel2.Orientation = Orientation.Horizontal;
		stackPanel2.Spacing = 10.0;
		stackPanel2.VerticalAlignment = VerticalAlignment.Center;
		Controls children4 = stackPanel2.Children;
		Border border7;
		Border border6 = (border7 = new Border());
		((ISupportInitialize)border6).BeginInit();
		children4.Add(border6);
		border7.Width = 28.0;
		border7.Height = 28.0;
		border7.CornerRadius = new CornerRadius(2.0, 2.0, 2.0, 2.0);
		border7.Background = new ImmutableSolidColorBrush(4291166061u);
		TextBlock textBlock2;
		TextBlock textBlock = (textBlock2 = new TextBlock());
		((ISupportInitialize)textBlock).BeginInit();
		border7.Child = textBlock;
		textBlock2.Text = "P";
		textBlock2.FontSize = 9.0;
		textBlock2.FontWeight = FontWeight.Bold;
		textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
		textBlock2.VerticalAlignment = VerticalAlignment.Center;
		((ISupportInitialize)textBlock2).EndInit();
		((ISupportInitialize)border7).EndInit();
		Controls children5 = stackPanel2.Children;
		TextBlock textBlock4;
		TextBlock textBlock3 = (textBlock4 = new TextBlock());
		((ISupportInitialize)textBlock3).BeginInit();
		children5.Add(textBlock3);
		textBlock4.Text = "PFMS / FISHING SYSTEM";
		textBlock4.FontWeight = FontWeight.DemiBold;
		textBlock4.FontSize = 13.0;
		textBlock4.VerticalAlignment = VerticalAlignment.Center;
		((ISupportInitialize)textBlock4).EndInit();
		Controls children6 = stackPanel2.Children;
		TextBlock textBlock6;
		TextBlock textBlock5 = (textBlock6 = new TextBlock());
		((ISupportInitialize)textBlock5).BeginInit();
		children6.Add(textBlock5);
		textBlock6.Text = "CONTROL SURFACE";
		textBlock6.Classes.Add("eyebrow");
		textBlock6.VerticalAlignment = VerticalAlignment.Center;
		((ISupportInitialize)textBlock6).EndInit();
		((ISupportInitialize)stackPanel2).EndInit();
		Controls children7 = grid9.Children;
		StackPanel stackPanel4;
		StackPanel stackPanel3 = (stackPanel4 = new StackPanel());
		((ISupportInitialize)stackPanel3).BeginInit();
		children7.Add(stackPanel3);
		Grid.SetColumn(stackPanel4, 1);
		stackPanel4.Orientation = Orientation.Horizontal;
		stackPanel4.VerticalAlignment = VerticalAlignment.Center;
		Controls children8 = stackPanel4.Children;
		Button button2;
		Button button = (button2 = new Button());
		((ISupportInitialize)button).BeginInit();
		children8.Add(button);
		button2.Classes.Add("title-bar-btn");
		button2.Content = "?";
		button2.AddHandler((RoutedEvent)Button.ClickEvent, (Delegate)new EventHandler<RoutedEventArgs>(context.RootObject.OnHelpClick), RoutingStrategies.Direct | RoutingStrategies.Bubble, false);
		((ISupportInitialize)button2).EndInit();
		Controls children9 = stackPanel4.Children;
		Button button5;
		Button button4 = (button5 = new Button());
		((ISupportInitialize)button4).BeginInit();
		children9.Add(button4);
		button5.Classes.Add("title-bar-btn");
		button5.Content = "_";
		button5.AddHandler((RoutedEvent)Button.ClickEvent, (Delegate)new EventHandler<RoutedEventArgs>(context.RootObject.OnMinimizeClick), RoutingStrategies.Direct | RoutingStrategies.Bubble, false);
		((ISupportInitialize)button5).EndInit();
		Controls children10 = stackPanel4.Children;
		Button button7;
		Button button6 = (button7 = new Button());
		((ISupportInitialize)button6).BeginInit();
		children10.Add(button6);
		button7.Classes.Add("title-bar-btn");
		button7.Classes.Add("close");
		button7.Content = "X";
		button7.AddHandler((RoutedEvent)Button.ClickEvent, (Delegate)new EventHandler<RoutedEventArgs>(context.RootObject.OnCloseClick), RoutingStrategies.Direct | RoutingStrategies.Bubble, false);
		((ISupportInitialize)button7).EndInit();
		((ISupportInitialize)stackPanel4).EndInit();
		((ISupportInitialize)grid9).EndInit();
		((ISupportInitialize)grid7).EndInit();
		Controls children11 = grid5.Children;
		Grid grid11;
		Grid grid10 = (grid11 = new Grid());
		((ISupportInitialize)grid10).BeginInit();
		children11.Add(grid10);
		Grid grid12 = (grid4 = grid11);
		context.PushParent(grid4);
		Grid grid13 = grid4;
		Grid.SetRow(grid13, 1);
		ColumnDefinitions columnDefinitions2 = new ColumnDefinitions();
		columnDefinitions2.Capacity = 2;
		columnDefinitions2.Add(new ColumnDefinition(new GridLength(214.0, GridUnitType.Pixel)));
		columnDefinitions2.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid13.ColumnDefinitions = columnDefinitions2;
		Controls children12 = grid13.Children;
		Border border9;
		Border border8 = (border9 = new Border());
		((ISupportInitialize)border8).BeginInit();
		children12.Add(border8);
		Border border10 = (border4 = border9);
		context.PushParent(border4);
		Border border11 = border4;
		border11.Classes.Add("sidebar");
		Grid grid15;
		Grid grid14 = (grid15 = new Grid());
		((ISupportInitialize)grid14).BeginInit();
		border11.Child = grid14;
		Grid grid16 = (grid4 = grid15);
		context.PushParent(grid4);
		Grid grid17 = grid4;
		RowDefinitions rowDefinitions2 = new RowDefinitions();
		rowDefinitions2.Capacity = 3;
		rowDefinitions2.Add(new RowDefinition(new GridLength(0.0, GridUnitType.Auto)));
		rowDefinitions2.Add(new RowDefinition(new GridLength(1.0, GridUnitType.Star)));
		rowDefinitions2.Add(new RowDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid17.RowDefinitions = rowDefinitions2;
		grid17.Margin = new Thickness(16.0, 16.0, 16.0, 16.0);
		Controls children13 = grid17.Children;
		StackPanel stackPanel6;
		StackPanel stackPanel5 = (stackPanel6 = new StackPanel());
		((ISupportInitialize)stackPanel5).BeginInit();
		children13.Add(stackPanel5);
		StackPanel stackPanel8;
		StackPanel stackPanel7 = (stackPanel8 = stackPanel6);
		context.PushParent(stackPanel8);
		StackPanel stackPanel9 = stackPanel8;
		stackPanel9.Spacing = 6.0;
		Controls children14 = stackPanel9.Children;
		TextBlock textBlock8;
		TextBlock textBlock7 = (textBlock8 = new TextBlock());
		((ISupportInitialize)textBlock7).BeginInit();
		children14.Add(textBlock7);
		textBlock8.Text = "AUTOMATION";
		textBlock8.Classes.Add("nav-caption");
		textBlock8.Margin = new Thickness(8.0, 4.0, 0.0, 5.0);
		((ISupportInitialize)textBlock8).EndInit();
		Controls children15 = stackPanel9.Children;
		Button button9;
		Button button8 = (button9 = new Button());
		((ISupportInitialize)button8).BeginInit();
		children15.Add(button8);
		Button button3;
		Button button10 = (button3 = button9);
		context.PushParent(button3);
		Button button11 = button3;
		button11.Classes.Add("nav-item");
		CompiledBindingExtension compiledBindingExtension = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EIsConfigurations_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = "class:selected";
		CompiledBinding compiledBinding = compiledBindingExtension.ProvideValue(context);
		context.ProvideTargetProperty = null;
		BindingBase source = compiledBinding;
		button11.BindClass("selected", source, null);
		StyledProperty<ICommand?> commandProperty = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension2 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ENavigateCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding = compiledBindingExtension2.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button11.Bind(commandProperty, binding);
		button11.CommandParameter = "Configurations";
		StackPanel stackPanel11;
		StackPanel stackPanel10 = (stackPanel11 = new StackPanel());
		((ISupportInitialize)stackPanel10).BeginInit();
		button11.Content = stackPanel10;
		stackPanel11.Orientation = Orientation.Horizontal;
		stackPanel11.Spacing = 10.0;
		Controls children16 = stackPanel11.Children;
		TextBlock textBlock10;
		TextBlock textBlock9 = (textBlock10 = new TextBlock());
		((ISupportInitialize)textBlock9).BeginInit();
		children16.Add(textBlock9);
		textBlock10.Text = "[]";
		textBlock10.Classes.Add("nav-icon");
		((ISupportInitialize)textBlock10).EndInit();
		Controls children17 = stackPanel11.Children;
		TextBlock textBlock12;
		TextBlock textBlock11 = (textBlock12 = new TextBlock());
		((ISupportInitialize)textBlock11).BeginInit();
		children17.Add(textBlock11);
		textBlock12.Text = "Configurations";
		((ISupportInitialize)textBlock12).EndInit();
		((ISupportInitialize)stackPanel11).EndInit();
		context.PopParent();
		((ISupportInitialize)button10).EndInit();
		Controls children18 = stackPanel9.Children;
		Button button13;
		Button button12 = (button13 = new Button());
		((ISupportInitialize)button12).BeginInit();
		children18.Add(button12);
		Button button14 = (button3 = button13);
		context.PushParent(button3);
		Button button15 = button3;
		button15.Classes.Add("nav-item");
		CompiledBindingExtension compiledBindingExtension3 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EIsSettings_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = "class:selected";
		CompiledBinding compiledBinding2 = compiledBindingExtension3.ProvideValue(context);
		context.ProvideTargetProperty = null;
		source = compiledBinding2;
		button15.BindClass("selected", source, null);
		StyledProperty<ICommand?> commandProperty2 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension4 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ENavigateCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding2 = compiledBindingExtension4.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button15.Bind(commandProperty2, binding2);
		button15.CommandParameter = "Settings";
		StackPanel stackPanel13;
		StackPanel stackPanel12 = (stackPanel13 = new StackPanel());
		((ISupportInitialize)stackPanel12).BeginInit();
		button15.Content = stackPanel12;
		stackPanel13.Orientation = Orientation.Horizontal;
		stackPanel13.Spacing = 10.0;
		Controls children19 = stackPanel13.Children;
		TextBlock textBlock14;
		TextBlock textBlock13 = (textBlock14 = new TextBlock());
		((ISupportInitialize)textBlock13).BeginInit();
		children19.Add(textBlock13);
		textBlock14.Text = "*";
		textBlock14.Classes.Add("nav-icon");
		((ISupportInitialize)textBlock14).EndInit();
		Controls children20 = stackPanel13.Children;
		TextBlock textBlock16;
		TextBlock textBlock15 = (textBlock16 = new TextBlock());
		((ISupportInitialize)textBlock15).BeginInit();
		children20.Add(textBlock15);
		textBlock16.Text = "Settings";
		((ISupportInitialize)textBlock16).EndInit();
		((ISupportInitialize)stackPanel13).EndInit();
		context.PopParent();
		((ISupportInitialize)button14).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel7).EndInit();
		Controls children21 = grid17.Children;
		StackPanel stackPanel15;
		StackPanel stackPanel14 = (stackPanel15 = new StackPanel());
		((ISupportInitialize)stackPanel14).BeginInit();
		children21.Add(stackPanel14);
		StackPanel stackPanel16 = (stackPanel8 = stackPanel15);
		context.PushParent(stackPanel8);
		StackPanel stackPanel17 = stackPanel8;
		Grid.SetRow(stackPanel17, 1);
		stackPanel17.VerticalAlignment = VerticalAlignment.Bottom;
		stackPanel17.Spacing = 8.0;
		stackPanel17.Margin = new Thickness(0.0, 0.0, 0.0, 16.0);
		Controls children22 = stackPanel17.Children;
		TextBlock textBlock18;
		TextBlock textBlock17 = (textBlock18 = new TextBlock());
		((ISupportInitialize)textBlock17).BeginInit();
		children22.Add(textBlock17);
		textBlock18.Text = "RUN CONTROL";
		textBlock18.Classes.Add("nav-caption");
		((ISupportInitialize)textBlock18).EndInit();
		Controls children23 = stackPanel17.Children;
		Button button17;
		Button button16 = (button17 = new Button());
		((ISupportInitialize)button16).BeginInit();
		children23.Add(button16);
		Button button18 = (button3 = button17);
		context.PushParent(button3);
		Button button19 = button3;
		button19.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty3 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension5 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EStartMacroCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding3 = compiledBindingExtension5.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button19.Bind(commandProperty3, binding3);
		button19.HorizontalContentAlignment = HorizontalAlignment.Center;
		button19.Content = "Start configuration (F6)";
		context.PopParent();
		((ISupportInitialize)button18).EndInit();
		Controls children24 = stackPanel17.Children;
		Button button21;
		Button button20 = (button21 = new Button());
		((ISupportInitialize)button20).BeginInit();
		children24.Add(button20);
		Button button22 = (button3 = button21);
		context.PushParent(button3);
		Button button23 = button3;
		button23.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty4 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension6 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EStopMacroCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding4 = compiledBindingExtension6.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button23.Bind(commandProperty4, binding4);
		button23.HorizontalContentAlignment = HorizontalAlignment.Center;
		button23.Content = "Stop (F7)";
		context.PopParent();
		((ISupportInitialize)button22).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel16).EndInit();
		Controls children25 = grid17.Children;
		Border border13;
		Border border12 = (border13 = new Border());
		((ISupportInitialize)border12).BeginInit();
		children25.Add(border12);
		Border border14 = (border4 = border13);
		context.PushParent(border4);
		Border border15 = border4;
		Grid.SetRow(border15, 2);
		border15.Classes.Add("status-card");
		border15.Padding = new Thickness(12.0, 12.0, 12.0, 12.0);
		StackPanel stackPanel19;
		StackPanel stackPanel18 = (stackPanel19 = new StackPanel());
		((ISupportInitialize)stackPanel18).BeginInit();
		border15.Child = stackPanel18;
		StackPanel stackPanel20 = (stackPanel8 = stackPanel19);
		context.PushParent(stackPanel8);
		StackPanel stackPanel21 = stackPanel8;
		stackPanel21.Spacing = 5.0;
		Controls children26 = stackPanel21.Children;
		StackPanel stackPanel23;
		StackPanel stackPanel22 = (stackPanel23 = new StackPanel());
		((ISupportInitialize)stackPanel22).BeginInit();
		children26.Add(stackPanel22);
		stackPanel23.Orientation = Orientation.Horizontal;
		stackPanel23.Spacing = 7.0;
		Controls children27 = stackPanel23.Children;
		Ellipse ellipse2;
		Ellipse ellipse = (ellipse2 = new Ellipse());
		((ISupportInitialize)ellipse).BeginInit();
		children27.Add(ellipse);
		ellipse2.Width = 7.0;
		ellipse2.Height = 7.0;
		ellipse2.Fill = new ImmutableSolidColorBrush(4285919422u);
		ellipse2.VerticalAlignment = VerticalAlignment.Center;
		((ISupportInitialize)ellipse2).EndInit();
		Controls children28 = stackPanel23.Children;
		TextBlock textBlock20;
		TextBlock textBlock19 = (textBlock20 = new TextBlock());
		((ISupportInitialize)textBlock19).BeginInit();
		children28.Add(textBlock19);
		textBlock20.Text = "Runtime";
		textBlock20.Classes.Add("status-title");
		((ISupportInitialize)textBlock20).EndInit();
		((ISupportInitialize)stackPanel23).EndInit();
		Controls children29 = stackPanel21.Children;
		TextBlock textBlock22;
		TextBlock textBlock21 = (textBlock22 = new TextBlock());
		((ISupportInitialize)textBlock21).BeginInit();
		children29.Add(textBlock21);
		TextBlock textBlock24;
		TextBlock textBlock23 = (textBlock24 = textBlock22);
		context.PushParent(textBlock24);
		TextBlock textBlock25 = textBlock24;
		StyledProperty<string?> textProperty = TextBlock.TextProperty;
		CompiledBindingExtension compiledBindingExtension7 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EStatusMessage_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = TextBlock.TextProperty;
		CompiledBinding binding5 = compiledBindingExtension7.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBlock25.Bind(textProperty, binding5);
		textBlock25.Classes.Add("status-copy");
		textBlock25.TextWrapping = TextWrapping.Wrap;
		textBlock25.MaxHeight = 56.0;
		context.PopParent();
		((ISupportInitialize)textBlock23).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel20).EndInit();
		context.PopParent();
		((ISupportInitialize)border14).EndInit();
		context.PopParent();
		((ISupportInitialize)grid16).EndInit();
		context.PopParent();
		((ISupportInitialize)border10).EndInit();
		Controls children30 = grid13.Children;
		Grid grid19;
		Grid grid18 = (grid19 = new Grid());
		((ISupportInitialize)grid18).BeginInit();
		children30.Add(grid18);
		Grid grid20 = (grid4 = grid19);
		context.PushParent(grid4);
		Grid grid21 = grid4;
		Grid.SetColumn(grid21, 1);
		grid21.Margin = new Thickness(30.0, 26.0, 30.0, 26.0);
		Controls children31 = grid21.Children;
		Grid grid23;
		Grid grid22 = (grid23 = new Grid());
		((ISupportInitialize)grid22).BeginInit();
		children31.Add(grid22);
		Grid grid24 = (grid4 = grid23);
		context.PushParent(grid4);
		Grid grid25 = grid4;
		StyledProperty<bool> isVisibleProperty = Visual.IsVisibleProperty;
		CompiledBindingExtension compiledBindingExtension8 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EIsConfigurations_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Visual.IsVisibleProperty;
		CompiledBinding binding6 = compiledBindingExtension8.ProvideValue(context);
		context.ProvideTargetProperty = null;
		grid25.Bind(isVisibleProperty, binding6);
		RowDefinitions rowDefinitions3 = new RowDefinitions();
		rowDefinitions3.Capacity = 2;
		rowDefinitions3.Add(new RowDefinition(new GridLength(0.0, GridUnitType.Auto)));
		rowDefinitions3.Add(new RowDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid25.RowDefinitions = rowDefinitions3;
		Controls children32 = grid25.Children;
		Grid grid27;
		Grid grid26 = (grid27 = new Grid());
		((ISupportInitialize)grid26).BeginInit();
		children32.Add(grid26);
		Grid grid28 = (grid4 = grid27);
		context.PushParent(grid4);
		Grid grid29 = grid4;
		ColumnDefinitions columnDefinitions3 = new ColumnDefinitions();
		columnDefinitions3.Capacity = 2;
		columnDefinitions3.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions3.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid29.ColumnDefinitions = columnDefinitions3;
		Controls children33 = grid29.Children;
		StackPanel stackPanel25;
		StackPanel stackPanel24 = (stackPanel25 = new StackPanel());
		((ISupportInitialize)stackPanel24).BeginInit();
		children33.Add(stackPanel24);
		stackPanel25.Spacing = 4.0;
		Controls children34 = stackPanel25.Children;
		TextBlock textBlock27;
		TextBlock textBlock26 = (textBlock27 = new TextBlock());
		((ISupportInitialize)textBlock26).BeginInit();
		children34.Add(textBlock26);
		textBlock27.Text = "YOLO CONFIGURATIONS";
		textBlock27.Classes.Add("eyebrow");
		textBlock27.Classes.Add("accent");
		((ISupportInitialize)textBlock27).EndInit();
		Controls children35 = stackPanel25.Children;
		TextBlock textBlock29;
		TextBlock textBlock28 = (textBlock29 = new TextBlock());
		((ISupportInitialize)textBlock28).BeginInit();
		children35.Add(textBlock28);
		textBlock29.Text = "Fishing configurations";
		textBlock29.Classes.Add("page-title");
		((ISupportInitialize)textBlock29).EndInit();
		Controls children36 = stackPanel25.Children;
		TextBlock textBlock31;
		TextBlock textBlock30 = (textBlock31 = new TextBlock());
		((ISupportInitialize)textBlock30).BeginInit();
		children36.Add(textBlock30);
		textBlock31.Text = "Each configuration owns one managed YOLO model, cast timing, shake detection, and fishing control.";
		textBlock31.Classes.Add("page-subtitle");
		((ISupportInitialize)textBlock31).EndInit();
		((ISupportInitialize)stackPanel25).EndInit();
		Controls children37 = grid29.Children;
		StackPanel stackPanel27;
		StackPanel stackPanel26 = (stackPanel27 = new StackPanel());
		((ISupportInitialize)stackPanel26).BeginInit();
		children37.Add(stackPanel26);
		StackPanel stackPanel28 = (stackPanel8 = stackPanel27);
		context.PushParent(stackPanel8);
		StackPanel stackPanel29 = stackPanel8;
		Grid.SetColumn(stackPanel29, 1);
		stackPanel29.Orientation = Orientation.Horizontal;
		stackPanel29.Spacing = 8.0;
		stackPanel29.VerticalAlignment = VerticalAlignment.Center;
		Controls children38 = stackPanel29.Children;
		Button button25;
		Button button24 = (button25 = new Button());
		((ISupportInitialize)button24).BeginInit();
		children38.Add(button24);
		Button button26 = (button3 = button25);
		context.PushParent(button3);
		Button button27 = button3;
		button27.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty5 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension9 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EImportProfileCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding7 = compiledBindingExtension9.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button27.Bind(commandProperty5, binding7);
		button27.Content = "Import configuration";
		context.PopParent();
		((ISupportInitialize)button26).EndInit();
		Controls children39 = stackPanel29.Children;
		Button button29;
		Button button28 = (button29 = new Button());
		((ISupportInitialize)button28).BeginInit();
		children39.Add(button28);
		Button button30 = (button3 = button29);
		context.PushParent(button3);
		Button button31 = button3;
		button31.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty6 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension10 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ECreateConfigurationCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding8 = compiledBindingExtension10.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button31.Bind(commandProperty6, binding8);
		button31.Content = "+ New configuration";
		context.PopParent();
		((ISupportInitialize)button30).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel28).EndInit();
		context.PopParent();
		((ISupportInitialize)grid28).EndInit();
		Controls children40 = grid25.Children;
		Grid grid31;
		Grid grid30 = (grid31 = new Grid());
		((ISupportInitialize)grid30).BeginInit();
		children40.Add(grid30);
		Grid grid32 = (grid4 = grid31);
		context.PushParent(grid4);
		Grid grid33 = grid4;
		Grid.SetRow(grid33, 1);
		RowDefinitions rowDefinitions4 = new RowDefinitions();
		rowDefinitions4.Capacity = 2;
		rowDefinitions4.Add(new RowDefinition(new GridLength(0.0, GridUnitType.Auto)));
		rowDefinitions4.Add(new RowDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid33.RowDefinitions = rowDefinitions4;
		grid33.Margin = new Thickness(0.0, 24.0, 0.0, 0.0);
		Controls children41 = grid33.Children;
		Grid grid35;
		Grid grid34 = (grid35 = new Grid());
		((ISupportInitialize)grid34).BeginInit();
		children41.Add(grid34);
		Grid grid36 = (grid4 = grid35);
		context.PushParent(grid4);
		Grid grid37 = grid4;
		ColumnDefinitions columnDefinitions4 = new ColumnDefinitions();
		columnDefinitions4.Capacity = 2;
		columnDefinitions4.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions4.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid37.ColumnDefinitions = columnDefinitions4;
		grid37.Margin = new Thickness(0.0, 0.0, 0.0, 12.0);
		Controls children42 = grid37.Children;
		TextBlock textBlock33;
		TextBlock textBlock32 = (textBlock33 = new TextBlock());
		((ISupportInitialize)textBlock32).BeginInit();
		children42.Add(textBlock32);
		textBlock33.Text = "Configuration library";
		textBlock33.Classes.Add("section-title");
		((ISupportInitialize)textBlock33).EndInit();
		Controls children43 = grid37.Children;
		TextBlock textBlock35;
		TextBlock textBlock34 = (textBlock35 = new TextBlock());
		((ISupportInitialize)textBlock34).BeginInit();
		children43.Add(textBlock34);
		TextBlock textBlock36 = (textBlock24 = textBlock35);
		context.PushParent(textBlock24);
		TextBlock textBlock37 = textBlock24;
		Grid.SetColumn(textBlock37, 1);
		StyledProperty<string?> textProperty2 = TextBlock.TextProperty;
		CompiledBindingExtension obj = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EConfigurationCount_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			StringFormat = "{0} configurations"
		};
		context.ProvideTargetProperty = TextBlock.TextProperty;
		CompiledBinding binding9 = obj.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBlock37.Bind(textProperty2, binding9);
		textBlock37.Classes.Add("count-label");
		textBlock37.VerticalAlignment = VerticalAlignment.Center;
		context.PopParent();
		((ISupportInitialize)textBlock36).EndInit();
		context.PopParent();
		((ISupportInitialize)grid36).EndInit();
		Controls children44 = grid33.Children;
		ScrollViewer scrollViewer2;
		ScrollViewer scrollViewer = (scrollViewer2 = new ScrollViewer());
		((ISupportInitialize)scrollViewer).BeginInit();
		children44.Add(scrollViewer);
		ScrollViewer scrollViewer4;
		ScrollViewer scrollViewer3 = (scrollViewer4 = scrollViewer2);
		context.PushParent(scrollViewer4);
		ScrollViewer scrollViewer5 = scrollViewer4;
		Grid.SetRow(scrollViewer5, 1);
		scrollViewer5.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
		ItemsControl itemsControl2;
		ItemsControl itemsControl = (itemsControl2 = new ItemsControl());
		((ISupportInitialize)itemsControl).BeginInit();
		scrollViewer5.Content = itemsControl;
		ItemsControl itemsControl4;
		ItemsControl itemsControl3 = (itemsControl4 = itemsControl2);
		context.PushParent(itemsControl4);
		ItemsControl itemsControl5 = itemsControl4;
		StyledProperty<IEnumerable?> itemsSourceProperty = ItemsControl.ItemsSourceProperty;
		CompiledBindingExtension compiledBindingExtension11 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EConfigurations_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = ItemsControl.ItemsSourceProperty;
		CompiledBinding binding10 = compiledBindingExtension11.ProvideValue(context);
		context.ProvideTargetProperty = null;
		itemsControl5.Bind(itemsSourceProperty, binding10);
		DataTemplate dataTemplate;
		DataTemplate itemTemplate = (dataTemplate = new DataTemplate());
		context.PushParent(dataTemplate);
		DataTemplate dataTemplate2 = dataTemplate;
		dataTemplate2.DataType = typeof(ConfigurationItemViewModel);
		dataTemplate2.Content = XamlIlRuntimeHelpers.DeferredTransformationFactoryV3<Control>((nint)(delegate*<IServiceProvider, object>)(&XamlClosure_3.Build_1), context);
		context.PopParent();
		itemsControl5.ItemTemplate = itemTemplate;
		context.PopParent();
		((ISupportInitialize)itemsControl3).EndInit();
		context.PopParent();
		((ISupportInitialize)scrollViewer3).EndInit();
		context.PopParent();
		((ISupportInitialize)grid32).EndInit();
		context.PopParent();
		((ISupportInitialize)grid24).EndInit();
		Controls children45 = grid21.Children;
		Grid grid39;
		Grid grid38 = (grid39 = new Grid());
		((ISupportInitialize)grid38).BeginInit();
		children45.Add(grid38);
		Grid grid40 = (grid4 = grid39);
		context.PushParent(grid4);
		Grid grid41 = grid4;
		StyledProperty<bool> isVisibleProperty2 = Visual.IsVisibleProperty;
		CompiledBindingExtension compiledBindingExtension12 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EIsSettings_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Visual.IsVisibleProperty;
		CompiledBinding binding11 = compiledBindingExtension12.ProvideValue(context);
		context.ProvideTargetProperty = null;
		grid41.Bind(isVisibleProperty2, binding11);
		RowDefinitions rowDefinitions5 = new RowDefinitions();
		rowDefinitions5.Capacity = 2;
		rowDefinitions5.Add(new RowDefinition(new GridLength(0.0, GridUnitType.Auto)));
		rowDefinitions5.Add(new RowDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid41.RowDefinitions = rowDefinitions5;
		Controls children46 = grid41.Children;
		StackPanel stackPanel31;
		StackPanel stackPanel30 = (stackPanel31 = new StackPanel());
		((ISupportInitialize)stackPanel30).BeginInit();
		children46.Add(stackPanel30);
		stackPanel31.Spacing = 4.0;
		Controls children47 = stackPanel31.Children;
		TextBlock textBlock39;
		TextBlock textBlock38 = (textBlock39 = new TextBlock());
		((ISupportInitialize)textBlock38).BeginInit();
		children47.Add(textBlock38);
		textBlock39.Text = "SETTINGS";
		textBlock39.Classes.Add("eyebrow");
		textBlock39.Classes.Add("accent");
		((ISupportInitialize)textBlock39).EndInit();
		Controls children48 = stackPanel31.Children;
		TextBlock textBlock41;
		TextBlock textBlock40 = (textBlock41 = new TextBlock());
		((ISupportInitialize)textBlock40).BeginInit();
		children48.Add(textBlock40);
		textBlock41.Text = "Application controls";
		textBlock41.Classes.Add("page-title");
		((ISupportInitialize)textBlock41).EndInit();
		Controls children49 = stackPanel31.Children;
		TextBlock textBlock43;
		TextBlock textBlock42 = (textBlock43 = new TextBlock());
		((ISupportInitialize)textBlock42).BeginInit();
		children49.Add(textBlock42);
		textBlock43.Text = "Set global hotkeys and access local PFMS files.";
		textBlock43.Classes.Add("page-subtitle");
		((ISupportInitialize)textBlock43).EndInit();
		((ISupportInitialize)stackPanel31).EndInit();
		Controls children50 = grid41.Children;
		StackPanel stackPanel33;
		StackPanel stackPanel32 = (stackPanel33 = new StackPanel());
		((ISupportInitialize)stackPanel32).BeginInit();
		children50.Add(stackPanel32);
		StackPanel stackPanel34 = (stackPanel8 = stackPanel33);
		context.PushParent(stackPanel8);
		StackPanel stackPanel35 = stackPanel8;
		Grid.SetRow(stackPanel35, 1);
		stackPanel35.Margin = new Thickness(0.0, 24.0, 0.0, 0.0);
		stackPanel35.Spacing = 14.0;
		Controls children51 = stackPanel35.Children;
		Border border17;
		Border border16 = (border17 = new Border());
		((ISupportInitialize)border16).BeginInit();
		children51.Add(border16);
		Border border18 = (border4 = border17);
		context.PushParent(border4);
		Border border19 = border4;
		border19.Classes.Add("feature-card");
		border19.Padding = new Thickness(18.0, 18.0, 18.0, 18.0);
		StackPanel stackPanel37;
		StackPanel stackPanel36 = (stackPanel37 = new StackPanel());
		((ISupportInitialize)stackPanel36).BeginInit();
		border19.Child = stackPanel36;
		StackPanel stackPanel38 = (stackPanel8 = stackPanel37);
		context.PushParent(stackPanel8);
		StackPanel stackPanel39 = stackPanel8;
		stackPanel39.Spacing = 12.0;
		Controls children52 = stackPanel39.Children;
		TextBlock textBlock45;
		TextBlock textBlock44 = (textBlock45 = new TextBlock());
		((ISupportInitialize)textBlock44).BeginInit();
		children52.Add(textBlock44);
		textBlock45.Text = "Global hotkeys";
		textBlock45.Classes.Add("section-title");
		((ISupportInitialize)textBlock45).EndInit();
		Controls children53 = stackPanel39.Children;
		Grid grid43;
		Grid grid42 = (grid43 = new Grid());
		((ISupportInitialize)grid42).BeginInit();
		children53.Add(grid42);
		Grid grid44 = (grid4 = grid43);
		context.PushParent(grid4);
		Grid grid45 = grid4;
		ColumnDefinitions columnDefinitions5 = new ColumnDefinitions();
		columnDefinitions5.Capacity = 3;
		columnDefinitions5.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions5.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions5.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid45.ColumnDefinitions = columnDefinitions5;
		grid45.ColumnSpacing = 10.0;
		Controls children54 = grid45.Children;
		StackPanel stackPanel41;
		StackPanel stackPanel40 = (stackPanel41 = new StackPanel());
		((ISupportInitialize)stackPanel40).BeginInit();
		children54.Add(stackPanel40);
		StackPanel stackPanel42 = (stackPanel8 = stackPanel41);
		context.PushParent(stackPanel8);
		StackPanel stackPanel43 = stackPanel8;
		stackPanel43.Spacing = 6.0;
		Controls children55 = stackPanel43.Children;
		TextBlock textBlock47;
		TextBlock textBlock46 = (textBlock47 = new TextBlock());
		((ISupportInitialize)textBlock46).BeginInit();
		children55.Add(textBlock46);
		textBlock47.Text = "Start fishing";
		textBlock47.Classes.Add("field-label");
		((ISupportInitialize)textBlock47).EndInit();
		Controls children56 = stackPanel43.Children;
		ComboBox comboBox2;
		ComboBox comboBox = (comboBox2 = new ComboBox());
		((ISupportInitialize)comboBox).BeginInit();
		children56.Add(comboBox);
		ComboBox comboBox4;
		ComboBox comboBox3 = (comboBox4 = comboBox2);
		context.PushParent(comboBox4);
		ComboBox comboBox5 = comboBox4;
		comboBox5.Classes.Add("builder-select");
		StyledProperty<IEnumerable?> itemsSourceProperty2 = ItemsControl.ItemsSourceProperty;
		CompiledBindingExtension compiledBindingExtension13 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EHotkeyOptions_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = ItemsControl.ItemsSourceProperty;
		CompiledBinding binding12 = compiledBindingExtension13.ProvideValue(context);
		context.ProvideTargetProperty = null;
		comboBox5.Bind(itemsSourceProperty2, binding12);
		CompiledBindingExtension obj2 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EStartHotkey_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = SelectingItemsControl.SelectedItemProperty;
		CompiledBinding compiledBinding3 = obj2.ProvideValue(context);
		context.ProvideTargetProperty = null;
		CompiledAvaloniaXaml.XamlDynamicSetters._003C_003EXamlDynamicSetter_3(comboBox5, compiledBinding3);
		context.PopParent();
		((ISupportInitialize)comboBox3).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel42).EndInit();
		Controls children57 = grid45.Children;
		StackPanel stackPanel45;
		StackPanel stackPanel44 = (stackPanel45 = new StackPanel());
		((ISupportInitialize)stackPanel44).BeginInit();
		children57.Add(stackPanel44);
		StackPanel stackPanel46 = (stackPanel8 = stackPanel45);
		context.PushParent(stackPanel8);
		StackPanel stackPanel47 = stackPanel8;
		Grid.SetColumn(stackPanel47, 1);
		stackPanel47.Spacing = 6.0;
		Controls children58 = stackPanel47.Children;
		TextBlock textBlock49;
		TextBlock textBlock48 = (textBlock49 = new TextBlock());
		((ISupportInitialize)textBlock48).BeginInit();
		children58.Add(textBlock48);
		textBlock49.Text = "Stop fishing";
		textBlock49.Classes.Add("field-label");
		((ISupportInitialize)textBlock49).EndInit();
		Controls children59 = stackPanel47.Children;
		ComboBox comboBox7;
		ComboBox comboBox6 = (comboBox7 = new ComboBox());
		((ISupportInitialize)comboBox6).BeginInit();
		children59.Add(comboBox6);
		ComboBox comboBox8 = (comboBox4 = comboBox7);
		context.PushParent(comboBox4);
		ComboBox comboBox9 = comboBox4;
		comboBox9.Classes.Add("builder-select");
		StyledProperty<IEnumerable?> itemsSourceProperty3 = ItemsControl.ItemsSourceProperty;
		CompiledBindingExtension compiledBindingExtension14 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EHotkeyOptions_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = ItemsControl.ItemsSourceProperty;
		CompiledBinding binding13 = compiledBindingExtension14.ProvideValue(context);
		context.ProvideTargetProperty = null;
		comboBox9.Bind(itemsSourceProperty3, binding13);
		CompiledBindingExtension obj3 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EStopHotkey_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = SelectingItemsControl.SelectedItemProperty;
		CompiledBinding compiledBinding4 = obj3.ProvideValue(context);
		context.ProvideTargetProperty = null;
		CompiledAvaloniaXaml.XamlDynamicSetters._003C_003EXamlDynamicSetter_3(comboBox9, compiledBinding4);
		context.PopParent();
		((ISupportInitialize)comboBox8).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel46).EndInit();
		Controls children60 = grid45.Children;
		Button button33;
		Button button32 = (button33 = new Button());
		((ISupportInitialize)button32).BeginInit();
		children60.Add(button32);
		Button button34 = (button3 = button33);
		context.PushParent(button3);
		Button button35 = button3;
		Grid.SetColumn(button35, 2);
		button35.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty7 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension15 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EApplyHotkeysCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding14 = compiledBindingExtension15.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button35.Bind(commandProperty7, binding14);
		button35.VerticalAlignment = VerticalAlignment.Bottom;
		button35.Content = "Apply keys";
		context.PopParent();
		((ISupportInitialize)button34).EndInit();
		context.PopParent();
		((ISupportInitialize)grid44).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel38).EndInit();
		context.PopParent();
		((ISupportInitialize)border18).EndInit();
		Controls children61 = stackPanel35.Children;
		Border border21;
		Border border20 = (border21 = new Border());
		((ISupportInitialize)border20).BeginInit();
		children61.Add(border20);
		Border border22 = (border4 = border21);
		context.PushParent(border4);
		Border border23 = border4;
		border23.Classes.Add("feature-card");
		border23.Padding = new Thickness(18.0, 18.0, 18.0, 18.0);
		Grid grid47;
		Grid grid46 = (grid47 = new Grid());
		((ISupportInitialize)grid46).BeginInit();
		border23.Child = grid46;
		Grid grid48 = (grid4 = grid47);
		context.PushParent(grid4);
		Grid grid49 = grid4;
		ColumnDefinitions columnDefinitions6 = new ColumnDefinitions();
		columnDefinitions6.Capacity = 2;
		columnDefinitions6.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions6.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid49.ColumnDefinitions = columnDefinitions6;
		grid49.ColumnSpacing = 18.0;
		Controls children62 = grid49.Children;
		StackPanel stackPanel49;
		StackPanel stackPanel48 = (stackPanel49 = new StackPanel());
		((ISupportInitialize)stackPanel48).BeginInit();
		children62.Add(stackPanel48);
		StackPanel stackPanel50 = (stackPanel8 = stackPanel49);
		context.PushParent(stackPanel8);
		StackPanel stackPanel51 = stackPanel8;
		stackPanel51.Spacing = 6.0;
		Controls children63 = stackPanel51.Children;
		TextBlock textBlock51;
		TextBlock textBlock50 = (textBlock51 = new TextBlock());
		((ISupportInitialize)textBlock50).BeginInit();
		children63.Add(textBlock50);
		textBlock51.Text = "PFMS files";
		textBlock51.Classes.Add("section-title");
		((ISupportInitialize)textBlock51).EndInit();
		Controls children64 = stackPanel51.Children;
		TextBlock textBlock53;
		TextBlock textBlock52 = (textBlock53 = new TextBlock());
		((ISupportInitialize)textBlock52).BeginInit();
		children64.Add(textBlock52);
		textBlock53.Text = "Open configurations.json and the Templates folder in Windows Explorer.";
		textBlock53.Classes.Add("config-description");
		textBlock53.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock53).EndInit();
		Controls children65 = stackPanel51.Children;
		TextBlock textBlock55;
		TextBlock textBlock54 = (textBlock55 = new TextBlock());
		((ISupportInitialize)textBlock54).BeginInit();
		children65.Add(textBlock54);
		TextBlock textBlock56 = (textBlock24 = textBlock55);
		context.PushParent(textBlock24);
		TextBlock textBlock57 = textBlock24;
		StyledProperty<string?> textProperty3 = TextBlock.TextProperty;
		CompiledBindingExtension compiledBindingExtension16 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EDataDirectory_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = TextBlock.TextProperty;
		CompiledBinding binding15 = compiledBindingExtension16.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBlock57.Bind(textProperty3, binding15);
		textBlock57.Classes.Add("path-label");
		textBlock57.TextWrapping = TextWrapping.Wrap;
		context.PopParent();
		((ISupportInitialize)textBlock56).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel50).EndInit();
		Controls children66 = grid49.Children;
		Button button37;
		Button button36 = (button37 = new Button());
		((ISupportInitialize)button36).BeginInit();
		children66.Add(button36);
		Button button38 = (button3 = button37);
		context.PushParent(button3);
		Button button39 = button3;
		Grid.SetColumn(button39, 1);
		button39.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty8 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension17 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EOpenTemplatesCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding16 = compiledBindingExtension17.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button39.Bind(commandProperty8, binding16);
		button39.VerticalAlignment = VerticalAlignment.Center;
		button39.Content = "Open folder";
		context.PopParent();
		((ISupportInitialize)button38).EndInit();
		context.PopParent();
		((ISupportInitialize)grid48).EndInit();
		context.PopParent();
		((ISupportInitialize)border22).EndInit();
		Controls children67 = stackPanel35.Children;
		Border border25;
		Border border24 = (border25 = new Border());
		((ISupportInitialize)border24).BeginInit();
		children67.Add(border24);
		Border border26 = (border4 = border25);
		context.PushParent(border4);
		Border border27 = border4;
		border27.Classes.Add("feature-card");
		border27.Padding = new Thickness(18.0, 18.0, 18.0, 18.0);
		StackPanel stackPanel53;
		StackPanel stackPanel52 = (stackPanel53 = new StackPanel());
		((ISupportInitialize)stackPanel52).BeginInit();
		border27.Child = stackPanel52;
		StackPanel stackPanel54 = (stackPanel8 = stackPanel53);
		context.PushParent(stackPanel8);
		StackPanel stackPanel55 = stackPanel8;
		stackPanel55.Spacing = 8.0;
		Controls children68 = stackPanel55.Children;
		TextBlock textBlock59;
		TextBlock textBlock58 = (textBlock59 = new TextBlock());
		((ISupportInitialize)textBlock58).BeginInit();
		children68.Add(textBlock58);
		textBlock59.Text = "Live detection overlay";
		textBlock59.Classes.Add("section-title");
		((ISupportInitialize)textBlock59).EndInit();
		Controls children69 = stackPanel55.Children;
		TextBlock textBlock61;
		TextBlock textBlock60 = (textBlock61 = new TextBlock());
		((ISupportInitialize)textBlock60).BeginInit();
		children69.Add(textBlock60);
		textBlock61.Text = "Draws real-time detection boxes directly on your game screen while a configuration is running.";
		textBlock61.Classes.Add("config-description");
		textBlock61.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock61).EndInit();
		Controls children70 = stackPanel55.Children;
		CheckBox checkBox2;
		CheckBox checkBox = (checkBox2 = new CheckBox());
		((ISupportInitialize)checkBox).BeginInit();
		children70.Add(checkBox);
		CheckBox checkBox4;
		CheckBox checkBox3 = (checkBox4 = checkBox2);
		context.PushParent(checkBox4);
		CheckBox checkBox5 = checkBox4;
		checkBox5.Content = "Show detection overlay on game screen";
		StyledProperty<bool?> isCheckedProperty = ToggleButton.IsCheckedProperty;
		CompiledBindingExtension obj4 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EShowGameVisionOverlay_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = ToggleButton.IsCheckedProperty;
		CompiledBinding binding17 = obj4.ProvideValue(context);
		context.ProvideTargetProperty = null;
		checkBox5.Bind(isCheckedProperty, binding17);
		context.PopParent();
		((ISupportInitialize)checkBox3).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel54).EndInit();
		context.PopParent();
		((ISupportInitialize)border26).EndInit();
		Controls children71 = stackPanel35.Children;
		StackPanel stackPanel57;
		StackPanel stackPanel56 = (stackPanel57 = new StackPanel());
		((ISupportInitialize)stackPanel56).BeginInit();
		children71.Add(stackPanel56);
		stackPanel57.HorizontalAlignment = HorizontalAlignment.Center;
		stackPanel57.Spacing = 1.0;
		stackPanel57.Margin = new Thickness(0.0, 10.0, 0.0, 0.0);
		Controls children72 = stackPanel57.Children;
		TextBlock textBlock63;
		TextBlock textBlock62 = (textBlock63 = new TextBlock());
		((ISupportInitialize)textBlock62).BeginInit();
		children72.Add(textBlock62);
		textBlock63.Text = "v1.3.0";
		textBlock63.Classes.Add("meta-label");
		textBlock63.HorizontalAlignment = HorizontalAlignment.Center;
		((ISupportInitialize)textBlock63).EndInit();
		Controls children73 = stackPanel57.Children;
		TextBlock textBlock65;
		TextBlock textBlock64 = (textBlock65 = new TextBlock());
		((ISupportInitialize)textBlock64).BeginInit();
		children73.Add(textBlock64);
		textBlock65.Text = "made by Pablo inspired by AsphaltCake";
		textBlock65.Classes.Add("meta-label");
		textBlock65.HorizontalAlignment = HorizontalAlignment.Center;
		((ISupportInitialize)textBlock65).EndInit();
		((ISupportInitialize)stackPanel57).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel34).EndInit();
		context.PopParent();
		((ISupportInitialize)grid40).EndInit();
		Controls children74 = grid21.Children;
		Border border29;
		Border border28 = (border29 = new Border());
		((ISupportInitialize)border28).BeginInit();
		children74.Add(border28);
		Border border30 = (border4 = border29);
		context.PushParent(border4);
		Border border31 = border4;
		StyledProperty<bool> isVisibleProperty3 = Visual.IsVisibleProperty;
		CompiledBindingExtension compiledBindingExtension18 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EIsEditorOpen_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Visual.IsVisibleProperty;
		CompiledBinding binding18 = compiledBindingExtension18.ProvideValue(context);
		context.ProvideTargetProperty = null;
		border31.Bind(isVisibleProperty3, binding18);
		border31.Classes.Add("editor-overlay");
		border31.Padding = new Thickness(24.0, 24.0, 24.0, 24.0);
		Grid grid51;
		Grid grid50 = (grid51 = new Grid());
		((ISupportInitialize)grid50).BeginInit();
		border31.Child = grid50;
		Grid grid52 = (grid4 = grid51);
		context.PushParent(grid4);
		Grid grid53 = grid4;
		RowDefinitions rowDefinitions6 = new RowDefinitions();
		rowDefinitions6.Capacity = 3;
		rowDefinitions6.Add(new RowDefinition(new GridLength(0.0, GridUnitType.Auto)));
		rowDefinitions6.Add(new RowDefinition(new GridLength(1.0, GridUnitType.Star)));
		rowDefinitions6.Add(new RowDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid53.RowDefinitions = rowDefinitions6;
		Controls children75 = grid53.Children;
		Grid grid55;
		Grid grid54 = (grid55 = new Grid());
		((ISupportInitialize)grid54).BeginInit();
		children75.Add(grid54);
		Grid grid56 = (grid4 = grid55);
		context.PushParent(grid4);
		Grid grid57 = grid4;
		ColumnDefinitions columnDefinitions7 = new ColumnDefinitions();
		columnDefinitions7.Capacity = 2;
		columnDefinitions7.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions7.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid57.ColumnDefinitions = columnDefinitions7;
		Controls children76 = grid57.Children;
		StackPanel stackPanel59;
		StackPanel stackPanel58 = (stackPanel59 = new StackPanel());
		((ISupportInitialize)stackPanel58).BeginInit();
		children76.Add(stackPanel58);
		stackPanel59.Spacing = 3.0;
		Controls children77 = stackPanel59.Children;
		TextBlock textBlock67;
		TextBlock textBlock66 = (textBlock67 = new TextBlock());
		((ISupportInitialize)textBlock66).BeginInit();
		children77.Add(textBlock66);
		textBlock67.Text = "YOLO CONFIGURATION";
		textBlock67.Classes.Add("eyebrow");
		textBlock67.Classes.Add("accent");
		((ISupportInitialize)textBlock67).EndInit();
		Controls children78 = stackPanel59.Children;
		TextBlock textBlock69;
		TextBlock textBlock68 = (textBlock69 = new TextBlock());
		((ISupportInitialize)textBlock68).BeginInit();
		children78.Add(textBlock68);
		textBlock69.Text = "Configuration";
		textBlock69.Classes.Add("page-title");
		((ISupportInitialize)textBlock69).EndInit();
		((ISupportInitialize)stackPanel59).EndInit();
		Controls children79 = grid57.Children;
		Button button41;
		Button button40 = (button41 = new Button());
		((ISupportInitialize)button40).BeginInit();
		children79.Add(button40);
		Button button42 = (button3 = button41);
		context.PushParent(button3);
		Button button43 = button3;
		Grid.SetColumn(button43, 1);
		button43.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty9 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension19 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ECloseEditorCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding19 = compiledBindingExtension19.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button43.Bind(commandProperty9, binding19);
		button43.VerticalAlignment = VerticalAlignment.Top;
		button43.Content = "Close";
		context.PopParent();
		((ISupportInitialize)button42).EndInit();
		context.PopParent();
		((ISupportInitialize)grid56).EndInit();
		Controls children80 = grid53.Children;
		ScrollViewer scrollViewer7;
		ScrollViewer scrollViewer6 = (scrollViewer7 = new ScrollViewer());
		((ISupportInitialize)scrollViewer6).BeginInit();
		children80.Add(scrollViewer6);
		ScrollViewer scrollViewer8 = (scrollViewer4 = scrollViewer7);
		context.PushParent(scrollViewer4);
		ScrollViewer scrollViewer9 = scrollViewer4;
		Grid.SetRow(scrollViewer9, 1);
		scrollViewer9.Margin = new Thickness(0.0, 18.0, 0.0, 16.0);
		scrollViewer9.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
		StackPanel stackPanel61;
		StackPanel stackPanel60 = (stackPanel61 = new StackPanel());
		((ISupportInitialize)stackPanel60).BeginInit();
		scrollViewer9.Content = stackPanel60;
		StackPanel stackPanel62 = (stackPanel8 = stackPanel61);
		context.PushParent(stackPanel8);
		StackPanel stackPanel63 = stackPanel8;
		stackPanel63.Spacing = 18.0;
		Controls children81 = stackPanel63.Children;
		Grid grid59;
		Grid grid58 = (grid59 = new Grid());
		((ISupportInitialize)grid58).BeginInit();
		children81.Add(grid58);
		Grid grid60 = (grid4 = grid59);
		context.PushParent(grid4);
		Grid grid61 = grid4;
		ColumnDefinitions columnDefinitions8 = new ColumnDefinitions();
		columnDefinitions8.Capacity = 2;
		columnDefinitions8.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions8.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid61.ColumnDefinitions = columnDefinitions8;
		grid61.ColumnSpacing = 12.0;
		Controls children82 = grid61.Children;
		StackPanel stackPanel65;
		StackPanel stackPanel64 = (stackPanel65 = new StackPanel());
		((ISupportInitialize)stackPanel64).BeginInit();
		children82.Add(stackPanel64);
		StackPanel stackPanel66 = (stackPanel8 = stackPanel65);
		context.PushParent(stackPanel8);
		StackPanel stackPanel67 = stackPanel8;
		stackPanel67.Spacing = 6.0;
		Controls children83 = stackPanel67.Children;
		TextBlock textBlock71;
		TextBlock textBlock70 = (textBlock71 = new TextBlock());
		((ISupportInitialize)textBlock70).BeginInit();
		children83.Add(textBlock70);
		textBlock71.Text = "Configuration name";
		textBlock71.Classes.Add("field-label");
		((ISupportInitialize)textBlock71).EndInit();
		Controls children84 = stackPanel67.Children;
		TextBox textBox2;
		TextBox textBox = (textBox2 = new TextBox());
		((ISupportInitialize)textBox).BeginInit();
		children84.Add(textBox);
		TextBox textBox4;
		TextBox textBox3 = (textBox4 = textBox2);
		context.PushParent(textBox4);
		TextBox textBox5 = textBox4;
		textBox5.Classes.Add("editor-input");
		StyledProperty<string?> textProperty4 = TextBox.TextProperty;
		CompiledBindingExtension obj5 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EName_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding20 = obj5.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox5.Bind(textProperty4, binding20);
		context.PopParent();
		((ISupportInitialize)textBox3).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel66).EndInit();
		Controls children85 = grid61.Children;
		StackPanel stackPanel69;
		StackPanel stackPanel68 = (stackPanel69 = new StackPanel());
		((ISupportInitialize)stackPanel68).BeginInit();
		children85.Add(stackPanel68);
		StackPanel stackPanel70 = (stackPanel8 = stackPanel69);
		context.PushParent(stackPanel8);
		StackPanel stackPanel71 = stackPanel8;
		Grid.SetColumn(stackPanel71, 1);
		stackPanel71.Spacing = 6.0;
		Controls children86 = stackPanel71.Children;
		TextBlock textBlock73;
		TextBlock textBlock72 = (textBlock73 = new TextBlock());
		((ISupportInitialize)textBlock72).BeginInit();
		children86.Add(textBlock72);
		textBlock73.Text = "Cover PNG";
		textBlock73.Classes.Add("field-label");
		((ISupportInitialize)textBlock73).EndInit();
		Controls children87 = stackPanel71.Children;
		Grid grid63;
		Grid grid62 = (grid63 = new Grid());
		((ISupportInitialize)grid62).BeginInit();
		children87.Add(grid62);
		Grid grid64 = (grid4 = grid63);
		context.PushParent(grid4);
		Grid grid65 = grid4;
		ColumnDefinitions columnDefinitions9 = new ColumnDefinitions();
		columnDefinitions9.Capacity = 2;
		columnDefinitions9.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions9.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid65.ColumnDefinitions = columnDefinitions9;
		grid65.ColumnSpacing = 8.0;
		Controls children88 = grid65.Children;
		TextBox textBox7;
		TextBox textBox6 = (textBox7 = new TextBox());
		((ISupportInitialize)textBox6).BeginInit();
		children88.Add(textBox6);
		TextBox textBox8 = (textBox4 = textBox7);
		context.PushParent(textBox4);
		TextBox textBox9 = textBox4;
		textBox9.Classes.Add("editor-input");
		StyledProperty<string?> textProperty5 = TextBox.TextProperty;
		CompiledBindingExtension obj6 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ECoverImagePath_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding21 = obj6.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox9.Bind(textProperty5, binding21);
		context.PopParent();
		((ISupportInitialize)textBox8).EndInit();
		Controls children89 = grid65.Children;
		Button button45;
		Button button44 = (button45 = new Button());
		((ISupportInitialize)button44).BeginInit();
		children89.Add(button44);
		Button button46 = (button3 = button45);
		context.PushParent(button3);
		Button button47 = button3;
		Grid.SetColumn(button47, 1);
		button47.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty10 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension20 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EBrowseCoverImageCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding22 = compiledBindingExtension20.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button47.Bind(commandProperty10, binding22);
		button47.Content = "Browse";
		context.PopParent();
		((ISupportInitialize)button46).EndInit();
		context.PopParent();
		((ISupportInitialize)grid64).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel70).EndInit();
		context.PopParent();
		((ISupportInitialize)grid60).EndInit();
		Controls children90 = stackPanel63.Children;
		StackPanel stackPanel73;
		StackPanel stackPanel72 = (stackPanel73 = new StackPanel());
		((ISupportInitialize)stackPanel72).BeginInit();
		children90.Add(stackPanel72);
		StackPanel stackPanel74 = (stackPanel8 = stackPanel73);
		context.PushParent(stackPanel8);
		StackPanel stackPanel75 = stackPanel8;
		stackPanel75.Spacing = 6.0;
		Controls children91 = stackPanel75.Children;
		TextBlock textBlock75;
		TextBlock textBlock74 = (textBlock75 = new TextBlock());
		((ISupportInitialize)textBlock74).BeginInit();
		children91.Add(textBlock74);
		textBlock75.Text = "Description";
		textBlock75.Classes.Add("field-label");
		((ISupportInitialize)textBlock75).EndInit();
		Controls children92 = stackPanel75.Children;
		TextBox textBox11;
		TextBox textBox10 = (textBox11 = new TextBox());
		((ISupportInitialize)textBox10).BeginInit();
		children92.Add(textBox10);
		TextBox textBox12 = (textBox4 = textBox11);
		context.PushParent(textBox4);
		TextBox textBox13 = textBox4;
		textBox13.Classes.Add("editor-input");
		StyledProperty<string?> textProperty6 = TextBox.TextProperty;
		CompiledBindingExtension obj7 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EDescription_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding23 = obj7.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox13.Bind(textProperty6, binding23);
		textBox13.AcceptsReturn = true;
		textBox13.MinHeight = 58.0;
		textBox13.TextWrapping = TextWrapping.Wrap;
		context.PopParent();
		((ISupportInitialize)textBox12).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel74).EndInit();
		Controls children93 = stackPanel63.Children;
		CheckBox checkBox7;
		CheckBox checkBox6 = (checkBox7 = new CheckBox());
		((ISupportInitialize)checkBox6).BeginInit();
		children93.Add(checkBox6);
		CheckBox checkBox8 = (checkBox4 = checkBox7);
		context.PushParent(checkBox4);
		CheckBox checkBox9 = checkBox4;
		checkBox9.Content = "Enable this configuration";
		StyledProperty<bool?> isCheckedProperty2 = ToggleButton.IsCheckedProperty;
		CompiledBindingExtension obj8 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EIsEnabled_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = ToggleButton.IsCheckedProperty;
		CompiledBinding binding24 = obj8.ProvideValue(context);
		context.ProvideTargetProperty = null;
		checkBox9.Bind(isCheckedProperty2, binding24);
		context.PopParent();
		((ISupportInitialize)checkBox8).EndInit();
		Controls children94 = stackPanel63.Children;
		TextBlock textBlock77;
		TextBlock textBlock76 = (textBlock77 = new TextBlock());
		((ISupportInitialize)textBlock76).BeginInit();
		children94.Add(textBlock76);
		textBlock77.Text = "MODEL AND CLASSES";
		textBlock77.Classes.Add("eyebrow");
		textBlock77.Classes.Add("accent");
		((ISupportInitialize)textBlock77).EndInit();
		Controls children95 = stackPanel63.Children;
		Border border33;
		Border border32 = (border33 = new Border());
		((ISupportInitialize)border32).BeginInit();
		children95.Add(border32);
		Border border34 = (border4 = border33);
		context.PushParent(border4);
		Border border35 = border4;
		border35.Classes.Add("feature-card");
		border35.Padding = new Thickness(12.0, 12.0, 12.0, 12.0);
		Grid grid67;
		Grid grid66 = (grid67 = new Grid());
		((ISupportInitialize)grid66).BeginInit();
		border35.Child = grid66;
		Grid grid68 = (grid4 = grid67);
		context.PushParent(grid4);
		Grid grid69 = grid4;
		ColumnDefinitions columnDefinitions10 = new ColumnDefinitions();
		columnDefinitions10.Capacity = 3;
		columnDefinitions10.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions10.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		columnDefinitions10.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid69.ColumnDefinitions = columnDefinitions10;
		grid69.ColumnSpacing = 8.0;
		Controls children96 = grid69.Children;
		StackPanel stackPanel77;
		StackPanel stackPanel76 = (stackPanel77 = new StackPanel());
		((ISupportInitialize)stackPanel76).BeginInit();
		children96.Add(stackPanel76);
		StackPanel stackPanel78 = (stackPanel8 = stackPanel77);
		context.PushParent(stackPanel8);
		StackPanel stackPanel79 = stackPanel8;
		stackPanel79.Spacing = 3.0;
		Controls children97 = stackPanel79.Children;
		TextBlock textBlock79;
		TextBlock textBlock78 = (textBlock79 = new TextBlock());
		((ISupportInitialize)textBlock78).BeginInit();
		children97.Add(textBlock78);
		textBlock79.Text = "Stored YOLO model";
		textBlock79.Classes.Add("field-label");
		((ISupportInitialize)textBlock79).EndInit();
		Controls children98 = stackPanel79.Children;
		TextBlock textBlock81;
		TextBlock textBlock80 = (textBlock81 = new TextBlock());
		((ISupportInitialize)textBlock80).BeginInit();
		children98.Add(textBlock80);
		TextBlock textBlock82 = (textBlock24 = textBlock81);
		context.PushParent(textBlock24);
		TextBlock textBlock83 = textBlock24;
		StyledProperty<string?> textProperty7 = TextBlock.TextProperty;
		CompiledBindingExtension compiledBindingExtension21 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EManagedModelName_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = TextBlock.TextProperty;
		CompiledBinding binding25 = compiledBindingExtension21.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBlock83.Bind(textProperty7, binding25);
		textBlock83.Classes.Add("config-description");
		textBlock83.TextTrimming = TextTrimming.CharacterEllipsis;
		context.PopParent();
		((ISupportInitialize)textBlock82).EndInit();
		Controls children99 = stackPanel79.Children;
		TextBlock textBlock85;
		TextBlock textBlock84 = (textBlock85 = new TextBlock());
		((ISupportInitialize)textBlock84).BeginInit();
		children99.Add(textBlock84);
		textBlock85.Text = "Models are copied into the PFMS template store so configuration bundles stay portable.";
		textBlock85.Classes.Add("meta-label");
		textBlock85.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock85).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel78).EndInit();
		Controls children100 = grid69.Children;
		Button button49;
		Button button48 = (button49 = new Button());
		((ISupportInitialize)button48).BeginInit();
		children100.Add(button48);
		Button button50 = (button3 = button49);
		context.PushParent(button3);
		Button button51 = button3;
		Grid.SetColumn(button51, 1);
		button51.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty11 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension22 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EBrowseModelFileCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding26 = compiledBindingExtension22.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button51.Bind(commandProperty11, binding26);
		button51.VerticalAlignment = VerticalAlignment.Center;
		button51.Content = "Load model";
		context.PopParent();
		((ISupportInitialize)button50).EndInit();
		Controls children101 = grid69.Children;
		Button button53;
		Button button52 = (button53 = new Button());
		((ISupportInitialize)button52).BeginInit();
		children101.Add(button52);
		Button button54 = (button3 = button53);
		context.PushParent(button3);
		Button button55 = button3;
		Grid.SetColumn(button55, 2);
		button55.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty12 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension23 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ERemoveModelCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding27 = compiledBindingExtension23.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button55.Bind(commandProperty12, binding27);
		StyledProperty<bool> isVisibleProperty4 = Visual.IsVisibleProperty;
		CompiledBindingExtension compiledBindingExtension24 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EHasModel_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Visual.IsVisibleProperty;
		CompiledBinding binding28 = compiledBindingExtension24.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button55.Bind(isVisibleProperty4, binding28);
		button55.VerticalAlignment = VerticalAlignment.Center;
		button55.Content = "Remove";
		context.PopParent();
		((ISupportInitialize)button54).EndInit();
		context.PopParent();
		((ISupportInitialize)grid68).EndInit();
		context.PopParent();
		((ISupportInitialize)border34).EndInit();
		Controls children102 = stackPanel63.Children;
		StackPanel stackPanel81;
		StackPanel stackPanel80 = (stackPanel81 = new StackPanel());
		((ISupportInitialize)stackPanel80).BeginInit();
		children102.Add(stackPanel80);
		StackPanel stackPanel82 = (stackPanel8 = stackPanel81);
		context.PushParent(stackPanel8);
		StackPanel stackPanel83 = stackPanel8;
		stackPanel83.Spacing = 6.0;
		stackPanel83.Width = 180.0;
		stackPanel83.HorizontalAlignment = HorizontalAlignment.Left;
		Controls children103 = stackPanel83.Children;
		TextBlock textBlock87;
		TextBlock textBlock86 = (textBlock87 = new TextBlock());
		((ISupportInitialize)textBlock86).BeginInit();
		children103.Add(textBlock86);
		textBlock87.Text = "Detection confidence";
		textBlock87.Classes.Add("field-label");
		((ISupportInitialize)textBlock87).EndInit();
		Controls children104 = stackPanel83.Children;
		TextBox textBox15;
		TextBox textBox14 = (textBox15 = new TextBox());
		((ISupportInitialize)textBox14).BeginInit();
		children104.Add(textBox14);
		TextBox textBox16 = (textBox4 = textBox15);
		context.PushParent(textBox4);
		TextBox textBox17 = textBox4;
		textBox17.Classes.Add("editor-input");
		StyledProperty<string?> textProperty8 = TextBox.TextProperty;
		CompiledBindingExtension compiledBindingExtension25 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EConfidenceThreshold_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		compiledBindingExtension25.Mode = BindingMode.TwoWay;
		compiledBindingExtension25.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding29 = compiledBindingExtension25.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox17.Bind(textProperty8, binding29);
		context.PopParent();
		((ISupportInitialize)textBox16).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel82).EndInit();
		Controls children105 = stackPanel63.Children;
		Border border37;
		Border border36 = (border37 = new Border());
		((ISupportInitialize)border36).BeginInit();
		children105.Add(border36);
		Border border38 = (border4 = border37);
		context.PushParent(border4);
		Border border39 = border4;
		border39.Classes.Add("feature-card");
		border39.Padding = new Thickness(12.0, 12.0, 12.0, 12.0);
		StackPanel stackPanel85;
		StackPanel stackPanel84 = (stackPanel85 = new StackPanel());
		((ISupportInitialize)stackPanel84).BeginInit();
		border39.Child = stackPanel84;
		StackPanel stackPanel86 = (stackPanel8 = stackPanel85);
		context.PushParent(stackPanel8);
		StackPanel stackPanel87 = stackPanel8;
		stackPanel87.Spacing = 9.0;
		Controls children106 = stackPanel87.Children;
		Grid grid71;
		Grid grid70 = (grid71 = new Grid());
		((ISupportInitialize)grid70).BeginInit();
		children106.Add(grid70);
		Grid grid72 = (grid4 = grid71);
		context.PushParent(grid4);
		Grid grid73 = grid4;
		ColumnDefinitions columnDefinitions11 = new ColumnDefinitions();
		columnDefinitions11.Capacity = 2;
		columnDefinitions11.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions11.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid73.ColumnDefinitions = columnDefinitions11;
		Controls children107 = grid73.Children;
		StackPanel stackPanel89;
		StackPanel stackPanel88 = (stackPanel89 = new StackPanel());
		((ISupportInitialize)stackPanel88).BeginInit();
		children107.Add(stackPanel88);
		stackPanel89.Spacing = 2.0;
		Controls children108 = stackPanel89.Children;
		TextBlock textBlock89;
		TextBlock textBlock88 = (textBlock89 = new TextBlock());
		((ISupportInitialize)textBlock88).BeginInit();
		children108.Add(textBlock88);
		textBlock89.Text = "MODEL CLASSES";
		textBlock89.Classes.Add("section-title");
		((ISupportInitialize)textBlock89).EndInit();
		Controls children109 = stackPanel89.Children;
		TextBlock textBlock91;
		TextBlock textBlock90 = (textBlock91 = new TextBlock());
		((ISupportInitialize)textBlock90).BeginInit();
		children109.Add(textBlock90);
		textBlock91.Text = "Assign each model class a runtime behavior. Avoid classes repel the control bar; Observe classes only appear in diagnostics.";
		textBlock91.Classes.Add("config-description");
		textBlock91.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock91).EndInit();
		((ISupportInitialize)stackPanel89).EndInit();
		Controls children110 = grid73.Children;
		Button button57;
		Button button56 = (button57 = new Button());
		((ISupportInitialize)button56).BeginInit();
		children110.Add(button56);
		Button button58 = (button3 = button57);
		context.PushParent(button3);
		Button button59 = button3;
		Grid.SetColumn(button59, 1);
		button59.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty13 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension26 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EAddCustomClassCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding30 = compiledBindingExtension26.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button59.Bind(commandProperty13, binding30);
		button59.VerticalAlignment = VerticalAlignment.Center;
		button59.Content = "+ Add class";
		context.PopParent();
		((ISupportInitialize)button58).EndInit();
		context.PopParent();
		((ISupportInitialize)grid72).EndInit();
		Controls children111 = stackPanel87.Children;
		ItemsControl itemsControl7;
		ItemsControl itemsControl6 = (itemsControl7 = new ItemsControl());
		((ISupportInitialize)itemsControl6).BeginInit();
		children111.Add(itemsControl6);
		ItemsControl itemsControl8 = (itemsControl4 = itemsControl7);
		context.PushParent(itemsControl4);
		ItemsControl itemsControl9 = itemsControl4;
		StyledProperty<IEnumerable?> itemsSourceProperty4 = ItemsControl.ItemsSourceProperty;
		CompiledBindingExtension compiledBindingExtension27 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ECustomClasses_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = ItemsControl.ItemsSourceProperty;
		CompiledBinding binding31 = compiledBindingExtension27.ProvideValue(context);
		context.ProvideTargetProperty = null;
		itemsControl9.Bind(itemsSourceProperty4, binding31);
		DataTemplate itemTemplate2 = (dataTemplate = new DataTemplate());
		context.PushParent(dataTemplate);
		DataTemplate dataTemplate3 = dataTemplate;
		dataTemplate3.DataType = typeof(DetectionClassViewModel);
		dataTemplate3.Content = XamlIlRuntimeHelpers.DeferredTransformationFactoryV3<Control>((nint)(delegate*<IServiceProvider, object>)(&XamlClosure_3.Build_2), context);
		context.PopParent();
		itemsControl9.ItemTemplate = itemTemplate2;
		context.PopParent();
		((ISupportInitialize)itemsControl8).EndInit();
		Controls children112 = stackPanel87.Children;
		TextBlock textBlock93;
		TextBlock textBlock92 = (textBlock93 = new TextBlock());
		((ISupportInitialize)textBlock92).BeginInit();
		children112.Add(textBlock92);
		textBlock93.Text = "Class formula variables: x, y, width, height, center_x, center_y, confidence, class_id, player_x, player_width, distance, distance_norm, overlap, direction, weight, frame_width, frame_height.";
		textBlock93.Classes.Add("meta-label");
		textBlock93.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock93).EndInit();
		Controls children113 = stackPanel87.Children;
		StackPanel stackPanel91;
		StackPanel stackPanel90 = (stackPanel91 = new StackPanel());
		((ISupportInitialize)stackPanel90).BeginInit();
		children113.Add(stackPanel90);
		StackPanel stackPanel92 = (stackPanel8 = stackPanel91);
		context.PushParent(stackPanel8);
		StackPanel stackPanel93 = stackPanel8;
		stackPanel93.Spacing = 6.0;
		stackPanel93.Margin = new Thickness(0.0, 6.0, 0.0, 0.0);
		Controls children114 = stackPanel93.Children;
		TextBlock textBlock95;
		TextBlock textBlock94 = (textBlock95 = new TextBlock());
		((ISupportInitialize)textBlock94).BeginInit();
		children114.Add(textBlock94);
		textBlock95.Text = "Final steering formula";
		textBlock95.Classes.Add("field-label");
		((ISupportInitialize)textBlock95).EndInit();
		Controls children115 = stackPanel93.Children;
		TextBox textBox19;
		TextBox textBox18 = (textBox19 = new TextBox());
		((ISupportInitialize)textBox18).BeginInit();
		children115.Add(textBox18);
		TextBox textBox20 = (textBox4 = textBox19);
		context.PushParent(textBox4);
		TextBox textBox21 = textBox4;
		textBox21.Classes.Add("editor-input");
		StyledProperty<string?> textProperty9 = TextBox.TextProperty;
		CompiledBindingExtension obj9 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ESteeringFormula_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding32 = obj9.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox21.Bind(textProperty9, binding32);
		textBox21.PlaceholderText = "Optional: combine pursuit_error and avoidance_error";
		context.PopParent();
		((ISupportInitialize)textBox20).EndInit();
		Controls children116 = stackPanel93.Children;
		TextBlock textBlock97;
		TextBlock textBlock96 = (textBlock97 = new TextBlock());
		((ISupportInitialize)textBlock96).BeginInit();
		children116.Add(textBlock96);
		textBlock97.Text = "Variables: pursuit_error, avoidance_error, pursuit_weight, avoidance_weight, legacy_error, player_x, frame_width, frame_height. Functions: abs, min, max, clamp, sqrt, pow, sign, lerp, if.";
		textBlock97.Classes.Add("meta-label");
		textBlock97.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock97).EndInit();
		Controls children117 = stackPanel93.Children;
		Grid grid75;
		Grid grid74 = (grid75 = new Grid());
		((ISupportInitialize)grid74).BeginInit();
		children117.Add(grid74);
		Grid grid76 = (grid4 = grid75);
		context.PushParent(grid4);
		Grid grid77 = grid4;
		ColumnDefinitions columnDefinitions12 = new ColumnDefinitions();
		columnDefinitions12.Capacity = 2;
		columnDefinitions12.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		columnDefinitions12.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid77.ColumnDefinitions = columnDefinitions12;
		grid77.ColumnSpacing = 10.0;
		Controls children118 = grid77.Children;
		Button button61;
		Button button60 = (button61 = new Button());
		((ISupportInitialize)button60).BeginInit();
		children118.Add(button60);
		Button button62 = (button3 = button61);
		context.PushParent(button3);
		Button button63 = button3;
		button63.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty14 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension28 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EValidateSteeringCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding33 = compiledBindingExtension28.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button63.Bind(commandProperty14, binding33);
		button63.Content = "Validate rules";
		context.PopParent();
		((ISupportInitialize)button62).EndInit();
		Controls children119 = grid77.Children;
		TextBlock textBlock99;
		TextBlock textBlock98 = (textBlock99 = new TextBlock());
		((ISupportInitialize)textBlock98).BeginInit();
		children119.Add(textBlock98);
		TextBlock textBlock100 = (textBlock24 = textBlock99);
		context.PushParent(textBlock24);
		TextBlock textBlock101 = textBlock24;
		Grid.SetColumn(textBlock101, 1);
		StyledProperty<string?> textProperty10 = TextBlock.TextProperty;
		CompiledBindingExtension compiledBindingExtension29 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ESteeringValidationMessage_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = TextBlock.TextProperty;
		CompiledBinding binding34 = compiledBindingExtension29.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBlock101.Bind(textProperty10, binding34);
		textBlock101.Classes.Add("meta-label");
		textBlock101.VerticalAlignment = VerticalAlignment.Center;
		textBlock101.TextWrapping = TextWrapping.Wrap;
		context.PopParent();
		((ISupportInitialize)textBlock100).EndInit();
		context.PopParent();
		((ISupportInitialize)grid76).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel92).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel86).EndInit();
		context.PopParent();
		((ISupportInitialize)border38).EndInit();
		Controls children120 = stackPanel63.Children;
		TextBlock textBlock103;
		TextBlock textBlock102 = (textBlock103 = new TextBlock());
		((ISupportInitialize)textBlock102).BeginInit();
		children120.Add(textBlock102);
		textBlock103.Text = "CAST, SHAKE, FISH";
		textBlock103.Classes.Add("eyebrow");
		textBlock103.Classes.Add("accent");
		((ISupportInitialize)textBlock103).EndInit();
		Controls children121 = stackPanel63.Children;
		Grid grid79;
		Grid grid78 = (grid79 = new Grid());
		((ISupportInitialize)grid78).BeginInit();
		children121.Add(grid78);
		Grid grid80 = (grid4 = grid79);
		context.PushParent(grid4);
		Grid grid81 = grid4;
		ColumnDefinitions columnDefinitions13 = new ColumnDefinitions();
		columnDefinitions13.Capacity = 5;
		columnDefinitions13.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions13.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions13.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions13.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions13.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid81.ColumnDefinitions = columnDefinitions13;
		grid81.ColumnSpacing = 10.0;
		Controls children122 = grid81.Children;
		StackPanel stackPanel95;
		StackPanel stackPanel94 = (stackPanel95 = new StackPanel());
		((ISupportInitialize)stackPanel94).BeginInit();
		children122.Add(stackPanel94);
		StackPanel stackPanel96 = (stackPanel8 = stackPanel95);
		context.PushParent(stackPanel8);
		StackPanel stackPanel97 = stackPanel8;
		stackPanel97.Spacing = 6.0;
		Controls children123 = stackPanel97.Children;
		TextBlock textBlock105;
		TextBlock textBlock104 = (textBlock105 = new TextBlock());
		((ISupportInitialize)textBlock104).BeginInit();
		children123.Add(textBlock104);
		textBlock105.Text = "Cast hold ms";
		textBlock105.Classes.Add("field-label");
		((ISupportInitialize)textBlock105).EndInit();
		Controls children124 = stackPanel97.Children;
		TextBox textBox23;
		TextBox textBox22 = (textBox23 = new TextBox());
		((ISupportInitialize)textBox22).BeginInit();
		children124.Add(textBox22);
		TextBox textBox24 = (textBox4 = textBox23);
		context.PushParent(textBox4);
		TextBox textBox25 = textBox4;
		textBox25.Classes.Add("editor-input");
		StyledProperty<string?> textProperty11 = TextBox.TextProperty;
		CompiledBindingExtension obj10 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ECastHoldTimeMs_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding35 = obj10.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox25.Bind(textProperty11, binding35);
		context.PopParent();
		((ISupportInitialize)textBox24).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel96).EndInit();
		Controls children125 = grid81.Children;
		StackPanel stackPanel99;
		StackPanel stackPanel98 = (stackPanel99 = new StackPanel());
		((ISupportInitialize)stackPanel98).BeginInit();
		children125.Add(stackPanel98);
		StackPanel stackPanel100 = (stackPanel8 = stackPanel99);
		context.PushParent(stackPanel8);
		StackPanel stackPanel101 = stackPanel8;
		Grid.SetColumn(stackPanel101, 1);
		stackPanel101.Spacing = 6.0;
		Controls children126 = stackPanel101.Children;
		TextBlock textBlock107;
		TextBlock textBlock106 = (textBlock107 = new TextBlock());
		((ISupportInitialize)textBlock106).BeginInit();
		children126.Add(textBlock106);
		textBlock107.Text = "Shake timeout ms";
		textBlock107.Classes.Add("field-label");
		((ISupportInitialize)textBlock107).EndInit();
		Controls children127 = stackPanel101.Children;
		TextBox textBox27;
		TextBox textBox26 = (textBox27 = new TextBox());
		((ISupportInitialize)textBox26).BeginInit();
		children127.Add(textBox26);
		TextBox textBox28 = (textBox4 = textBox27);
		context.PushParent(textBox4);
		TextBox textBox29 = textBox4;
		textBox29.Classes.Add("editor-input");
		StyledProperty<string?> textProperty12 = TextBox.TextProperty;
		CompiledBindingExtension obj11 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EBiteTimeoutMs_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding36 = obj11.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox29.Bind(textProperty12, binding36);
		context.PopParent();
		((ISupportInitialize)textBox28).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel100).EndInit();
		Controls children128 = grid81.Children;
		StackPanel stackPanel103;
		StackPanel stackPanel102 = (stackPanel103 = new StackPanel());
		((ISupportInitialize)stackPanel102).BeginInit();
		children128.Add(stackPanel102);
		StackPanel stackPanel104 = (stackPanel8 = stackPanel103);
		context.PushParent(stackPanel8);
		StackPanel stackPanel105 = stackPanel8;
		Grid.SetColumn(stackPanel105, 2);
		stackPanel105.Spacing = 6.0;
		Controls children129 = stackPanel105.Children;
		TextBlock textBlock109;
		TextBlock textBlock108 = (textBlock109 = new TextBlock());
		((ISupportInitialize)textBlock108).BeginInit();
		children129.Add(textBlock108);
		textBlock109.Text = "Recast delay ms";
		textBlock109.Classes.Add("field-label");
		((ISupportInitialize)textBlock109).EndInit();
		Controls children130 = stackPanel105.Children;
		TextBox textBox31;
		TextBox textBox30 = (textBox31 = new TextBox());
		((ISupportInitialize)textBox30).BeginInit();
		children130.Add(textBox30);
		TextBox textBox32 = (textBox4 = textBox31);
		context.PushParent(textBox4);
		TextBox textBox33 = textBox4;
		textBox33.Classes.Add("editor-input");
		StyledProperty<string?> textProperty13 = TextBox.TextProperty;
		CompiledBindingExtension obj12 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ERecastDelayMs_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding37 = obj12.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox33.Bind(textProperty13, binding37);
		context.PopParent();
		((ISupportInitialize)textBox32).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel104).EndInit();
		Controls children131 = grid81.Children;
		StackPanel stackPanel107;
		StackPanel stackPanel106 = (stackPanel107 = new StackPanel());
		((ISupportInitialize)stackPanel106).BeginInit();
		children131.Add(stackPanel106);
		StackPanel stackPanel108 = (stackPanel8 = stackPanel107);
		context.PushParent(stackPanel8);
		StackPanel stackPanel109 = stackPanel8;
		Grid.SetColumn(stackPanel109, 3);
		stackPanel109.Spacing = 6.0;
		Controls children132 = stackPanel109.Children;
		TextBlock textBlock111;
		TextBlock textBlock110 = (textBlock111 = new TextBlock());
		((ISupportInitialize)textBlock110).BeginInit();
		children132.Add(textBlock110);
		textBlock111.Text = "Kp";
		textBlock111.Classes.Add("field-label");
		((ISupportInitialize)textBlock111).EndInit();
		Controls children133 = stackPanel109.Children;
		TextBox textBox35;
		TextBox textBox34 = (textBox35 = new TextBox());
		((ISupportInitialize)textBox34).BeginInit();
		children133.Add(textBox34);
		TextBox textBox36 = (textBox4 = textBox35);
		context.PushParent(textBox4);
		TextBox textBox37 = textBox4;
		textBox37.Classes.Add("editor-input");
		StyledProperty<string?> textProperty14 = TextBox.TextProperty;
		CompiledBindingExtension compiledBindingExtension30 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EFishingKp_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		compiledBindingExtension30.Mode = BindingMode.TwoWay;
		compiledBindingExtension30.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding38 = compiledBindingExtension30.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox37.Bind(textProperty14, binding38);
		context.PopParent();
		((ISupportInitialize)textBox36).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel108).EndInit();
		Controls children134 = grid81.Children;
		StackPanel stackPanel111;
		StackPanel stackPanel110 = (stackPanel111 = new StackPanel());
		((ISupportInitialize)stackPanel110).BeginInit();
		children134.Add(stackPanel110);
		StackPanel stackPanel112 = (stackPanel8 = stackPanel111);
		context.PushParent(stackPanel8);
		StackPanel stackPanel113 = stackPanel8;
		Grid.SetColumn(stackPanel113, 4);
		stackPanel113.Spacing = 6.0;
		Controls children135 = stackPanel113.Children;
		TextBlock textBlock113;
		TextBlock textBlock112 = (textBlock113 = new TextBlock());
		((ISupportInitialize)textBlock112).BeginInit();
		children135.Add(textBlock112);
		textBlock113.Text = "Kd";
		textBlock113.Classes.Add("field-label");
		((ISupportInitialize)textBlock113).EndInit();
		Controls children136 = stackPanel113.Children;
		TextBox textBox39;
		TextBox textBox38 = (textBox39 = new TextBox());
		((ISupportInitialize)textBox38).BeginInit();
		children136.Add(textBox38);
		TextBox textBox40 = (textBox4 = textBox39);
		context.PushParent(textBox4);
		TextBox textBox41 = textBox4;
		textBox41.Classes.Add("editor-input");
		StyledProperty<string?> textProperty15 = TextBox.TextProperty;
		CompiledBindingExtension compiledBindingExtension31 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EFishingKd_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		compiledBindingExtension31.Mode = BindingMode.TwoWay;
		compiledBindingExtension31.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding39 = compiledBindingExtension31.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox41.Bind(textProperty15, binding39);
		context.PopParent();
		((ISupportInitialize)textBox40).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel112).EndInit();
		context.PopParent();
		((ISupportInitialize)grid80).EndInit();
		Controls children137 = stackPanel63.Children;
		StackPanel stackPanel115;
		StackPanel stackPanel114 = (stackPanel115 = new StackPanel());
		((ISupportInitialize)stackPanel114).BeginInit();
		children137.Add(stackPanel114);
		StackPanel stackPanel116 = (stackPanel8 = stackPanel115);
		context.PushParent(stackPanel8);
		StackPanel stackPanel117 = stackPanel8;
		stackPanel117.Spacing = 6.0;
		Controls children138 = stackPanel117.Children;
		TextBlock textBlock115;
		TextBlock textBlock114 = (textBlock115 = new TextBlock());
		((ISupportInitialize)textBlock114).BeginInit();
		children138.Add(textBlock114);
		textBlock115.Text = "Control dead zone pixels";
		textBlock115.Classes.Add("field-label");
		((ISupportInitialize)textBlock115).EndInit();
		Controls children139 = stackPanel117.Children;
		TextBox textBox43;
		TextBox textBox42 = (textBox43 = new TextBox());
		((ISupportInitialize)textBox42).BeginInit();
		children139.Add(textBox42);
		TextBox textBox44 = (textBox4 = textBox43);
		context.PushParent(textBox4);
		TextBox textBox45 = textBox4;
		textBox45.Classes.Add("editor-input");
		textBox45.Width = 160.0;
		textBox45.HorizontalAlignment = HorizontalAlignment.Left;
		StyledProperty<string?> textProperty16 = TextBox.TextProperty;
		CompiledBindingExtension compiledBindingExtension32 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EFishingDeadZonePixels_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		compiledBindingExtension32.Mode = BindingMode.TwoWay;
		compiledBindingExtension32.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding40 = compiledBindingExtension32.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox45.Bind(textProperty16, binding40);
		context.PopParent();
		((ISupportInitialize)textBox44).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel116).EndInit();
		Controls children140 = stackPanel63.Children;
		Grid grid83;
		Grid grid82 = (grid83 = new Grid());
		((ISupportInitialize)grid82).BeginInit();
		children140.Add(grid82);
		Grid grid84 = (grid4 = grid83);
		context.PushParent(grid4);
		Grid grid85 = grid4;
		ColumnDefinitions columnDefinitions14 = new ColumnDefinitions();
		columnDefinitions14.Capacity = 2;
		columnDefinitions14.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		columnDefinitions14.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid85.ColumnDefinitions = columnDefinitions14;
		grid85.ColumnSpacing = 10.0;
		Controls children141 = grid85.Children;
		TextBlock textBlock117;
		TextBlock textBlock116 = (textBlock117 = new TextBlock());
		((ISupportInitialize)textBlock116).BeginInit();
		children141.Add(textBlock116);
		textBlock117.Text = "Fishing mode";
		textBlock117.Classes.Add("field-label");
		textBlock117.VerticalAlignment = VerticalAlignment.Center;
		((ISupportInitialize)textBlock117).EndInit();
		Controls children142 = grid85.Children;
		ComboBox comboBox11;
		ComboBox comboBox10 = (comboBox11 = new ComboBox());
		((ISupportInitialize)comboBox10).BeginInit();
		children142.Add(comboBox10);
		ComboBox comboBox12 = (comboBox4 = comboBox11);
		context.PushParent(comboBox4);
		ComboBox comboBox13 = comboBox4;
		Grid.SetColumn(comboBox13, 1);
		comboBox13.Classes.Add("builder-select");
		StyledProperty<IEnumerable?> itemsSourceProperty5 = ItemsControl.ItemsSourceProperty;
		CompiledBindingExtension compiledBindingExtension33 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EFishingModeOptions_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = ItemsControl.ItemsSourceProperty;
		CompiledBinding binding41 = compiledBindingExtension33.ProvideValue(context);
		context.ProvideTargetProperty = null;
		comboBox13.Bind(itemsSourceProperty5, binding41);
		CompiledBindingExtension obj13 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EFishingMode_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = SelectingItemsControl.SelectedItemProperty;
		CompiledBinding compiledBinding5 = obj13.ProvideValue(context);
		context.ProvideTargetProperty = null;
		CompiledAvaloniaXaml.XamlDynamicSetters._003C_003EXamlDynamicSetter_3(comboBox13, compiledBinding5);
		comboBox13.Width = 200.0;
		comboBox13.HorizontalAlignment = HorizontalAlignment.Left;
		context.PopParent();
		((ISupportInitialize)comboBox12).EndInit();
		context.PopParent();
		((ISupportInitialize)grid84).EndInit();
		Controls children143 = stackPanel63.Children;
		Border border41;
		Border border40 = (border41 = new Border());
		((ISupportInitialize)border40).BeginInit();
		children143.Add(border40);
		Border border42 = (border4 = border41);
		context.PushParent(border4);
		Border border43 = border4;
		border43.Classes.Add("feature-card");
		border43.Padding = new Thickness(14.0, 14.0, 14.0, 14.0);
		StyledProperty<bool> isVisibleProperty5 = Visual.IsVisibleProperty;
		CompiledBindingExtension compiledBindingExtension34 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EIsTimingClick_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Visual.IsVisibleProperty;
		CompiledBinding binding42 = compiledBindingExtension34.ProvideValue(context);
		context.ProvideTargetProperty = null;
		border43.Bind(isVisibleProperty5, binding42);
		StackPanel stackPanel119;
		StackPanel stackPanel118 = (stackPanel119 = new StackPanel());
		((ISupportInitialize)stackPanel118).BeginInit();
		border43.Child = stackPanel118;
		StackPanel stackPanel120 = (stackPanel8 = stackPanel119);
		context.PushParent(stackPanel8);
		StackPanel stackPanel121 = stackPanel8;
		stackPanel121.Spacing = 10.0;
		Controls children144 = stackPanel121.Children;
		TextBlock textBlock119;
		TextBlock textBlock118 = (textBlock119 = new TextBlock());
		((ISupportInitialize)textBlock118).BeginInit();
		children144.Add(textBlock118);
		textBlock119.Text = "TIMING CLICK SETTINGS";
		textBlock119.Classes.Add("section-title");
		((ISupportInitialize)textBlock119).EndInit();
		Controls children145 = stackPanel121.Children;
		StackPanel stackPanel123;
		StackPanel stackPanel122 = (stackPanel123 = new StackPanel());
		((ISupportInitialize)stackPanel122).BeginInit();
		children145.Add(stackPanel122);
		StackPanel stackPanel124 = (stackPanel8 = stackPanel123);
		context.PushParent(stackPanel8);
		StackPanel stackPanel125 = stackPanel8;
		stackPanel125.Spacing = 6.0;
		Controls children146 = stackPanel125.Children;
		TextBlock textBlock121;
		TextBlock textBlock120 = (textBlock121 = new TextBlock());
		((ISupportInitialize)textBlock120).BeginInit();
		children146.Add(textBlock120);
		textBlock121.Text = "Trigger formula";
		textBlock121.Classes.Add("field-label");
		((ISupportInitialize)textBlock121).EndInit();
		Controls children147 = stackPanel125.Children;
		TextBox textBox47;
		TextBox textBox46 = (textBox47 = new TextBox());
		((ISupportInitialize)textBox46).BeginInit();
		children147.Add(textBox46);
		TextBox textBox48 = (textBox4 = textBox47);
		context.PushParent(textBox4);
		TextBox textBox49 = textBox4;
		textBox49.Classes.Add("editor-input");
		StyledProperty<string?> textProperty17 = TextBox.TextProperty;
		CompiledBindingExtension obj14 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ETriggerFormula_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding43 = obj14.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox49.Bind(textProperty17, binding43);
		textBox49.PlaceholderText = "overlap_max >= 0.3 ? 1 : 0";
		context.PopParent();
		((ISupportInitialize)textBox48).EndInit();
		Controls children148 = stackPanel125.Children;
		TextBlock textBlock123;
		TextBlock textBlock122 = (textBlock123 = new TextBlock());
		((ISupportInitialize)textBlock122).BeginInit();
		children148.Add(textBlock122);
		textBlock123.Text = "Variables: overlap_max, overlap_sum, pursue_count, control_count, player_x, player_width, frame_width, frame_height. Return > 0 to trigger click.";
		textBlock123.Classes.Add("meta-label");
		textBlock123.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock123).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel124).EndInit();
		Controls children149 = stackPanel121.Children;
		Grid grid87;
		Grid grid86 = (grid87 = new Grid());
		((ISupportInitialize)grid86).BeginInit();
		children149.Add(grid86);
		Grid grid88 = (grid4 = grid87);
		context.PushParent(grid4);
		Grid grid89 = grid4;
		ColumnDefinitions columnDefinitions15 = new ColumnDefinitions();
		columnDefinitions15.Capacity = 2;
		columnDefinitions15.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions15.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid89.ColumnDefinitions = columnDefinitions15;
		grid89.ColumnSpacing = 10.0;
		Controls children150 = grid89.Children;
		StackPanel stackPanel127;
		StackPanel stackPanel126 = (stackPanel127 = new StackPanel());
		((ISupportInitialize)stackPanel126).BeginInit();
		children150.Add(stackPanel126);
		StackPanel stackPanel128 = (stackPanel8 = stackPanel127);
		context.PushParent(stackPanel8);
		StackPanel stackPanel129 = stackPanel8;
		stackPanel129.Spacing = 4.0;
		Controls children151 = stackPanel129.Children;
		TextBlock textBlock125;
		TextBlock textBlock124 = (textBlock125 = new TextBlock());
		((ISupportInitialize)textBlock124).BeginInit();
		children151.Add(textBlock124);
		textBlock125.Text = "Click cooldown ms";
		textBlock125.Classes.Add("field-label");
		((ISupportInitialize)textBlock125).EndInit();
		Controls children152 = stackPanel129.Children;
		TextBox textBox51;
		TextBox textBox50 = (textBox51 = new TextBox());
		((ISupportInitialize)textBox50).BeginInit();
		children152.Add(textBox50);
		TextBox textBox52 = (textBox4 = textBox51);
		context.PushParent(textBox4);
		TextBox textBox53 = textBox4;
		textBox53.Classes.Add("editor-input");
		StyledProperty<string?> textProperty18 = TextBox.TextProperty;
		CompiledBindingExtension obj15 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EClickCooldownMs_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding44 = obj15.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox53.Bind(textProperty18, binding44);
		context.PopParent();
		((ISupportInitialize)textBox52).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel128).EndInit();
		Controls children153 = grid89.Children;
		StackPanel stackPanel131;
		StackPanel stackPanel130 = (stackPanel131 = new StackPanel());
		((ISupportInitialize)stackPanel130).BeginInit();
		children153.Add(stackPanel130);
		StackPanel stackPanel132 = (stackPanel8 = stackPanel131);
		context.PushParent(stackPanel8);
		StackPanel stackPanel133 = stackPanel8;
		Grid.SetColumn(stackPanel133, 1);
		stackPanel133.Spacing = 4.0;
		Controls children154 = stackPanel133.Children;
		TextBlock textBlock127;
		TextBlock textBlock126 = (textBlock127 = new TextBlock());
		((ISupportInitialize)textBlock126).BeginInit();
		children154.Add(textBlock126);
		textBlock127.Text = "Click hold ms";
		textBlock127.Classes.Add("field-label");
		((ISupportInitialize)textBlock127).EndInit();
		Controls children155 = stackPanel133.Children;
		TextBox textBox55;
		TextBox textBox54 = (textBox55 = new TextBox());
		((ISupportInitialize)textBox54).BeginInit();
		children155.Add(textBox54);
		TextBox textBox56 = (textBox4 = textBox55);
		context.PushParent(textBox4);
		TextBox textBox57 = textBox4;
		textBox57.Classes.Add("editor-input");
		StyledProperty<string?> textProperty19 = TextBox.TextProperty;
		CompiledBindingExtension obj16 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EClickHoldDurationMs_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding45 = obj16.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox57.Bind(textProperty19, binding45);
		context.PopParent();
		((ISupportInitialize)textBox56).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel132).EndInit();
		context.PopParent();
		((ISupportInitialize)grid88).EndInit();
		Controls children156 = stackPanel121.Children;
		TextBlock textBlock129;
		TextBlock textBlock128 = (textBlock129 = new TextBlock());
		((ISupportInitialize)textBlock128).BeginInit();
		children156.Add(textBlock128);
		textBlock129.Text = "When the trigger formula returns > 0, LMB is pressed for the hold duration then released. Cooldown prevents rapid re-clicks.";
		textBlock129.Classes.Add("meta-label");
		textBlock129.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock129).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel120).EndInit();
		context.PopParent();
		((ISupportInitialize)border42).EndInit();
		Controls children157 = stackPanel63.Children;
		TextBlock textBlock131;
		TextBlock textBlock130 = (textBlock131 = new TextBlock());
		((ISupportInitialize)textBlock130).BeginInit();
		children157.Add(textBlock130);
		textBlock131.Text = "FISHING CAPTURE AREA";
		textBlock131.Classes.Add("eyebrow");
		textBlock131.Classes.Add("accent");
		((ISupportInitialize)textBlock131).EndInit();
		Controls children158 = stackPanel63.Children;
		Grid grid91;
		Grid grid90 = (grid91 = new Grid());
		((ISupportInitialize)grid90).BeginInit();
		children158.Add(grid90);
		Grid grid92 = (grid4 = grid91);
		context.PushParent(grid4);
		Grid grid93 = grid4;
		ColumnDefinitions columnDefinitions16 = new ColumnDefinitions();
		columnDefinitions16.Capacity = 5;
		columnDefinitions16.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions16.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions16.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions16.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions16.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid93.ColumnDefinitions = columnDefinitions16;
		grid93.ColumnSpacing = 8.0;
		Controls children159 = grid93.Children;
		StackPanel stackPanel135;
		StackPanel stackPanel134 = (stackPanel135 = new StackPanel());
		((ISupportInitialize)stackPanel134).BeginInit();
		children159.Add(stackPanel134);
		StackPanel stackPanel136 = (stackPanel8 = stackPanel135);
		context.PushParent(stackPanel8);
		StackPanel stackPanel137 = stackPanel8;
		stackPanel137.Spacing = 5.0;
		Controls children160 = stackPanel137.Children;
		TextBlock textBlock133;
		TextBlock textBlock132 = (textBlock133 = new TextBlock());
		((ISupportInitialize)textBlock132).BeginInit();
		children160.Add(textBlock132);
		textBlock133.Text = "X";
		textBlock133.Classes.Add("field-label");
		((ISupportInitialize)textBlock133).EndInit();
		Controls children161 = stackPanel137.Children;
		TextBox textBox59;
		TextBox textBox58 = (textBox59 = new TextBox());
		((ISupportInitialize)textBox58).BeginInit();
		children161.Add(textBox58);
		TextBox textBox60 = (textBox4 = textBox59);
		context.PushParent(textBox4);
		TextBox textBox61 = textBox4;
		textBox61.Classes.Add("editor-input");
		textBox61.IsReadOnly = true;
		StyledProperty<string?> textProperty20 = TextBox.TextProperty;
		CompiledBindingExtension obj17 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EScanAreaX_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.OneWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding46 = obj17.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox61.Bind(textProperty20, binding46);
		context.PopParent();
		((ISupportInitialize)textBox60).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel136).EndInit();
		Controls children162 = grid93.Children;
		StackPanel stackPanel139;
		StackPanel stackPanel138 = (stackPanel139 = new StackPanel());
		((ISupportInitialize)stackPanel138).BeginInit();
		children162.Add(stackPanel138);
		StackPanel stackPanel140 = (stackPanel8 = stackPanel139);
		context.PushParent(stackPanel8);
		StackPanel stackPanel141 = stackPanel8;
		Grid.SetColumn(stackPanel141, 1);
		stackPanel141.Spacing = 5.0;
		Controls children163 = stackPanel141.Children;
		TextBlock textBlock135;
		TextBlock textBlock134 = (textBlock135 = new TextBlock());
		((ISupportInitialize)textBlock134).BeginInit();
		children163.Add(textBlock134);
		textBlock135.Text = "Y";
		textBlock135.Classes.Add("field-label");
		((ISupportInitialize)textBlock135).EndInit();
		Controls children164 = stackPanel141.Children;
		TextBox textBox63;
		TextBox textBox62 = (textBox63 = new TextBox());
		((ISupportInitialize)textBox62).BeginInit();
		children164.Add(textBox62);
		TextBox textBox64 = (textBox4 = textBox63);
		context.PushParent(textBox4);
		TextBox textBox65 = textBox4;
		textBox65.Classes.Add("editor-input");
		textBox65.IsReadOnly = true;
		StyledProperty<string?> textProperty21 = TextBox.TextProperty;
		CompiledBindingExtension obj18 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EScanAreaY_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.OneWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding47 = obj18.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox65.Bind(textProperty21, binding47);
		context.PopParent();
		((ISupportInitialize)textBox64).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel140).EndInit();
		Controls children165 = grid93.Children;
		StackPanel stackPanel143;
		StackPanel stackPanel142 = (stackPanel143 = new StackPanel());
		((ISupportInitialize)stackPanel142).BeginInit();
		children165.Add(stackPanel142);
		StackPanel stackPanel144 = (stackPanel8 = stackPanel143);
		context.PushParent(stackPanel8);
		StackPanel stackPanel145 = stackPanel8;
		Grid.SetColumn(stackPanel145, 2);
		stackPanel145.Spacing = 5.0;
		Controls children166 = stackPanel145.Children;
		TextBlock textBlock137;
		TextBlock textBlock136 = (textBlock137 = new TextBlock());
		((ISupportInitialize)textBlock136).BeginInit();
		children166.Add(textBlock136);
		textBlock137.Text = "Width";
		textBlock137.Classes.Add("field-label");
		((ISupportInitialize)textBlock137).EndInit();
		Controls children167 = stackPanel145.Children;
		TextBox textBox67;
		TextBox textBox66 = (textBox67 = new TextBox());
		((ISupportInitialize)textBox66).BeginInit();
		children167.Add(textBox66);
		TextBox textBox68 = (textBox4 = textBox67);
		context.PushParent(textBox4);
		TextBox textBox69 = textBox4;
		textBox69.Classes.Add("editor-input");
		textBox69.IsReadOnly = true;
		StyledProperty<string?> textProperty22 = TextBox.TextProperty;
		CompiledBindingExtension obj19 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EScanAreaWidth_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.OneWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding48 = obj19.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox69.Bind(textProperty22, binding48);
		context.PopParent();
		((ISupportInitialize)textBox68).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel144).EndInit();
		Controls children168 = grid93.Children;
		StackPanel stackPanel147;
		StackPanel stackPanel146 = (stackPanel147 = new StackPanel());
		((ISupportInitialize)stackPanel146).BeginInit();
		children168.Add(stackPanel146);
		StackPanel stackPanel148 = (stackPanel8 = stackPanel147);
		context.PushParent(stackPanel8);
		StackPanel stackPanel149 = stackPanel8;
		Grid.SetColumn(stackPanel149, 3);
		stackPanel149.Spacing = 5.0;
		Controls children169 = stackPanel149.Children;
		TextBlock textBlock139;
		TextBlock textBlock138 = (textBlock139 = new TextBlock());
		((ISupportInitialize)textBlock138).BeginInit();
		children169.Add(textBlock138);
		textBlock139.Text = "Height";
		textBlock139.Classes.Add("field-label");
		((ISupportInitialize)textBlock139).EndInit();
		Controls children170 = stackPanel149.Children;
		TextBox textBox71;
		TextBox textBox70 = (textBox71 = new TextBox());
		((ISupportInitialize)textBox70).BeginInit();
		children170.Add(textBox70);
		TextBox textBox72 = (textBox4 = textBox71);
		context.PushParent(textBox4);
		TextBox textBox73 = textBox4;
		textBox73.Classes.Add("editor-input");
		textBox73.IsReadOnly = true;
		StyledProperty<string?> textProperty23 = TextBox.TextProperty;
		CompiledBindingExtension obj20 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EScanAreaHeight_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.OneWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding49 = obj20.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox73.Bind(textProperty23, binding49);
		context.PopParent();
		((ISupportInitialize)textBox72).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel148).EndInit();
		Controls children171 = grid93.Children;
		Button button65;
		Button button64 = (button65 = new Button());
		((ISupportInitialize)button64).BeginInit();
		children171.Add(button64);
		Button button66 = (button3 = button65);
		context.PushParent(button3);
		Button button67 = button3;
		Grid.SetColumn(button67, 4);
		button67.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty15 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension35 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ESelectFishingScanAreaCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding50 = compiledBindingExtension35.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button67.Bind(commandProperty15, binding50);
		button67.VerticalAlignment = VerticalAlignment.Bottom;
		button67.Content = "Select area";
		context.PopParent();
		((ISupportInitialize)button66).EndInit();
		context.PopParent();
		((ISupportInitialize)grid92).EndInit();
		Controls children172 = stackPanel63.Children;
		TextBlock textBlock141;
		TextBlock textBlock140 = (textBlock141 = new TextBlock());
		((ISupportInitialize)textBlock140).BeginInit();
		children172.Add(textBlock140);
		textBlock141.Text = "PIXEL PROGRESS FALLBACK";
		textBlock141.Classes.Add("eyebrow");
		textBlock141.Classes.Add("accent");
		((ISupportInitialize)textBlock141).EndInit();
		Controls children173 = stackPanel63.Children;
		CheckBox checkBox11;
		CheckBox checkBox10 = (checkBox11 = new CheckBox());
		((ISupportInitialize)checkBox10).BeginInit();
		children173.Add(checkBox10);
		CheckBox checkBox12 = (checkBox4 = checkBox11);
		context.PushParent(checkBox4);
		CheckBox checkBox13 = checkBox4;
		checkBox13.Content = "Use a selected pixel area for the progress bar";
		StyledProperty<bool?> isCheckedProperty3 = ToggleButton.IsCheckedProperty;
		CompiledBindingExtension obj21 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EPixelProgressEnabled_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = ToggleButton.IsCheckedProperty;
		CompiledBinding binding51 = obj21.ProvideValue(context);
		context.ProvideTargetProperty = null;
		checkBox13.Bind(isCheckedProperty3, binding51);
		context.PopParent();
		((ISupportInitialize)checkBox12).EndInit();
		Controls children174 = stackPanel63.Children;
		Grid grid95;
		Grid grid94 = (grid95 = new Grid());
		((ISupportInitialize)grid94).BeginInit();
		children174.Add(grid94);
		Grid grid96 = (grid4 = grid95);
		context.PushParent(grid4);
		Grid grid97 = grid4;
		ColumnDefinitions columnDefinitions17 = new ColumnDefinitions();
		columnDefinitions17.Capacity = 5;
		columnDefinitions17.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions17.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions17.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions17.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions17.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid97.ColumnDefinitions = columnDefinitions17;
		grid97.ColumnSpacing = 8.0;
		Controls children175 = grid97.Children;
		StackPanel stackPanel151;
		StackPanel stackPanel150 = (stackPanel151 = new StackPanel());
		((ISupportInitialize)stackPanel150).BeginInit();
		children175.Add(stackPanel150);
		StackPanel stackPanel152 = (stackPanel8 = stackPanel151);
		context.PushParent(stackPanel8);
		StackPanel stackPanel153 = stackPanel8;
		stackPanel153.Spacing = 5.0;
		Controls children176 = stackPanel153.Children;
		TextBlock textBlock143;
		TextBlock textBlock142 = (textBlock143 = new TextBlock());
		((ISupportInitialize)textBlock142).BeginInit();
		children176.Add(textBlock142);
		textBlock143.Text = "Progress X";
		textBlock143.Classes.Add("field-label");
		((ISupportInitialize)textBlock143).EndInit();
		Controls children177 = stackPanel153.Children;
		TextBox textBox75;
		TextBox textBox74 = (textBox75 = new TextBox());
		((ISupportInitialize)textBox74).BeginInit();
		children177.Add(textBox74);
		TextBox textBox76 = (textBox4 = textBox75);
		context.PushParent(textBox4);
		TextBox textBox77 = textBox4;
		textBox77.Classes.Add("editor-input");
		StyledProperty<string?> textProperty24 = TextBox.TextProperty;
		CompiledBindingExtension obj22 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressAreaX_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding52 = obj22.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox77.Bind(textProperty24, binding52);
		context.PopParent();
		((ISupportInitialize)textBox76).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel152).EndInit();
		Controls children178 = grid97.Children;
		StackPanel stackPanel155;
		StackPanel stackPanel154 = (stackPanel155 = new StackPanel());
		((ISupportInitialize)stackPanel154).BeginInit();
		children178.Add(stackPanel154);
		StackPanel stackPanel156 = (stackPanel8 = stackPanel155);
		context.PushParent(stackPanel8);
		StackPanel stackPanel157 = stackPanel8;
		Grid.SetColumn(stackPanel157, 1);
		stackPanel157.Spacing = 5.0;
		Controls children179 = stackPanel157.Children;
		TextBlock textBlock145;
		TextBlock textBlock144 = (textBlock145 = new TextBlock());
		((ISupportInitialize)textBlock144).BeginInit();
		children179.Add(textBlock144);
		textBlock145.Text = "Progress Y";
		textBlock145.Classes.Add("field-label");
		((ISupportInitialize)textBlock145).EndInit();
		Controls children180 = stackPanel157.Children;
		TextBox textBox79;
		TextBox textBox78 = (textBox79 = new TextBox());
		((ISupportInitialize)textBox78).BeginInit();
		children180.Add(textBox78);
		TextBox textBox80 = (textBox4 = textBox79);
		context.PushParent(textBox4);
		TextBox textBox81 = textBox4;
		textBox81.Classes.Add("editor-input");
		StyledProperty<string?> textProperty25 = TextBox.TextProperty;
		CompiledBindingExtension obj23 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressAreaY_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding53 = obj23.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox81.Bind(textProperty25, binding53);
		context.PopParent();
		((ISupportInitialize)textBox80).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel156).EndInit();
		Controls children181 = grid97.Children;
		StackPanel stackPanel159;
		StackPanel stackPanel158 = (stackPanel159 = new StackPanel());
		((ISupportInitialize)stackPanel158).BeginInit();
		children181.Add(stackPanel158);
		StackPanel stackPanel160 = (stackPanel8 = stackPanel159);
		context.PushParent(stackPanel8);
		StackPanel stackPanel161 = stackPanel8;
		Grid.SetColumn(stackPanel161, 2);
		stackPanel161.Spacing = 5.0;
		Controls children182 = stackPanel161.Children;
		TextBlock textBlock147;
		TextBlock textBlock146 = (textBlock147 = new TextBlock());
		((ISupportInitialize)textBlock146).BeginInit();
		children182.Add(textBlock146);
		textBlock147.Text = "Width";
		textBlock147.Classes.Add("field-label");
		((ISupportInitialize)textBlock147).EndInit();
		Controls children183 = stackPanel161.Children;
		TextBox textBox83;
		TextBox textBox82 = (textBox83 = new TextBox());
		((ISupportInitialize)textBox82).BeginInit();
		children183.Add(textBox82);
		TextBox textBox84 = (textBox4 = textBox83);
		context.PushParent(textBox4);
		TextBox textBox85 = textBox4;
		textBox85.Classes.Add("editor-input");
		StyledProperty<string?> textProperty26 = TextBox.TextProperty;
		CompiledBindingExtension obj24 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressAreaWidth_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding54 = obj24.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox85.Bind(textProperty26, binding54);
		context.PopParent();
		((ISupportInitialize)textBox84).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel160).EndInit();
		Controls children184 = grid97.Children;
		StackPanel stackPanel163;
		StackPanel stackPanel162 = (stackPanel163 = new StackPanel());
		((ISupportInitialize)stackPanel162).BeginInit();
		children184.Add(stackPanel162);
		StackPanel stackPanel164 = (stackPanel8 = stackPanel163);
		context.PushParent(stackPanel8);
		StackPanel stackPanel165 = stackPanel8;
		Grid.SetColumn(stackPanel165, 3);
		stackPanel165.Spacing = 5.0;
		Controls children185 = stackPanel165.Children;
		TextBlock textBlock149;
		TextBlock textBlock148 = (textBlock149 = new TextBlock());
		((ISupportInitialize)textBlock148).BeginInit();
		children185.Add(textBlock148);
		textBlock149.Text = "Height";
		textBlock149.Classes.Add("field-label");
		((ISupportInitialize)textBlock149).EndInit();
		Controls children186 = stackPanel165.Children;
		TextBox textBox87;
		TextBox textBox86 = (textBox87 = new TextBox());
		((ISupportInitialize)textBox86).BeginInit();
		children186.Add(textBox86);
		TextBox textBox88 = (textBox4 = textBox87);
		context.PushParent(textBox4);
		TextBox textBox89 = textBox4;
		textBox89.Classes.Add("editor-input");
		StyledProperty<string?> textProperty27 = TextBox.TextProperty;
		CompiledBindingExtension obj25 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressAreaHeight_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding55 = obj25.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox89.Bind(textProperty27, binding55);
		context.PopParent();
		((ISupportInitialize)textBox88).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel164).EndInit();
		Controls children187 = grid97.Children;
		Button button69;
		Button button68 = (button69 = new Button());
		((ISupportInitialize)button68).BeginInit();
		children187.Add(button68);
		Button button70 = (button3 = button69);
		context.PushParent(button3);
		Button button71 = button3;
		Grid.SetColumn(button71, 4);
		button71.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty16 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension36 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002ESelectProgressScanAreaCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding56 = compiledBindingExtension36.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button71.Bind(commandProperty16, binding56);
		button71.VerticalAlignment = VerticalAlignment.Bottom;
		button71.Content = "Select progress area";
		context.PopParent();
		((ISupportInitialize)button70).EndInit();
		context.PopParent();
		((ISupportInitialize)grid96).EndInit();
		Controls children188 = stackPanel63.Children;
		Grid grid99;
		Grid grid98 = (grid99 = new Grid());
		((ISupportInitialize)grid98).BeginInit();
		children188.Add(grid98);
		Grid grid100 = (grid4 = grid99);
		context.PushParent(grid4);
		Grid grid101 = grid4;
		ColumnDefinitions columnDefinitions18 = new ColumnDefinitions();
		columnDefinitions18.Capacity = 5;
		columnDefinitions18.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions18.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions18.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions18.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions18.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid101.ColumnDefinitions = columnDefinitions18;
		grid101.ColumnSpacing = 8.0;
		Controls children189 = grid101.Children;
		StackPanel stackPanel167;
		StackPanel stackPanel166 = (stackPanel167 = new StackPanel());
		((ISupportInitialize)stackPanel166).BeginInit();
		children189.Add(stackPanel166);
		StackPanel stackPanel168 = (stackPanel8 = stackPanel167);
		context.PushParent(stackPanel8);
		StackPanel stackPanel169 = stackPanel8;
		stackPanel169.Spacing = 5.0;
		Controls children190 = stackPanel169.Children;
		TextBlock textBlock151;
		TextBlock textBlock150 = (textBlock151 = new TextBlock());
		((ISupportInitialize)textBlock150).BeginInit();
		children190.Add(textBlock150);
		textBlock151.Text = "Fill red";
		textBlock151.Classes.Add("field-label");
		((ISupportInitialize)textBlock151).EndInit();
		Controls children191 = stackPanel169.Children;
		TextBox textBox91;
		TextBox textBox90 = (textBox91 = new TextBox());
		((ISupportInitialize)textBox90).BeginInit();
		children191.Add(textBox90);
		TextBox textBox92 = (textBox4 = textBox91);
		context.PushParent(textBox4);
		TextBox textBox93 = textBox4;
		textBox93.Classes.Add("editor-input");
		StyledProperty<string?> textProperty28 = TextBox.TextProperty;
		CompiledBindingExtension obj26 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressRed_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding57 = obj26.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox93.Bind(textProperty28, binding57);
		context.PopParent();
		((ISupportInitialize)textBox92).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel168).EndInit();
		Controls children192 = grid101.Children;
		StackPanel stackPanel171;
		StackPanel stackPanel170 = (stackPanel171 = new StackPanel());
		((ISupportInitialize)stackPanel170).BeginInit();
		children192.Add(stackPanel170);
		StackPanel stackPanel172 = (stackPanel8 = stackPanel171);
		context.PushParent(stackPanel8);
		StackPanel stackPanel173 = stackPanel8;
		Grid.SetColumn(stackPanel173, 1);
		stackPanel173.Spacing = 5.0;
		Controls children193 = stackPanel173.Children;
		TextBlock textBlock153;
		TextBlock textBlock152 = (textBlock153 = new TextBlock());
		((ISupportInitialize)textBlock152).BeginInit();
		children193.Add(textBlock152);
		textBlock153.Text = "Green";
		textBlock153.Classes.Add("field-label");
		((ISupportInitialize)textBlock153).EndInit();
		Controls children194 = stackPanel173.Children;
		TextBox textBox95;
		TextBox textBox94 = (textBox95 = new TextBox());
		((ISupportInitialize)textBox94).BeginInit();
		children194.Add(textBox94);
		TextBox textBox96 = (textBox4 = textBox95);
		context.PushParent(textBox4);
		TextBox textBox97 = textBox4;
		textBox97.Classes.Add("editor-input");
		StyledProperty<string?> textProperty29 = TextBox.TextProperty;
		CompiledBindingExtension obj27 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressGreen_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding58 = obj27.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox97.Bind(textProperty29, binding58);
		context.PopParent();
		((ISupportInitialize)textBox96).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel172).EndInit();
		Controls children195 = grid101.Children;
		StackPanel stackPanel175;
		StackPanel stackPanel174 = (stackPanel175 = new StackPanel());
		((ISupportInitialize)stackPanel174).BeginInit();
		children195.Add(stackPanel174);
		StackPanel stackPanel176 = (stackPanel8 = stackPanel175);
		context.PushParent(stackPanel8);
		StackPanel stackPanel177 = stackPanel8;
		Grid.SetColumn(stackPanel177, 2);
		stackPanel177.Spacing = 5.0;
		Controls children196 = stackPanel177.Children;
		TextBlock textBlock155;
		TextBlock textBlock154 = (textBlock155 = new TextBlock());
		((ISupportInitialize)textBlock154).BeginInit();
		children196.Add(textBlock154);
		textBlock155.Text = "Blue";
		textBlock155.Classes.Add("field-label");
		((ISupportInitialize)textBlock155).EndInit();
		Controls children197 = stackPanel177.Children;
		TextBox textBox99;
		TextBox textBox98 = (textBox99 = new TextBox());
		((ISupportInitialize)textBox98).BeginInit();
		children197.Add(textBox98);
		TextBox textBox100 = (textBox4 = textBox99);
		context.PushParent(textBox4);
		TextBox textBox101 = textBox4;
		textBox101.Classes.Add("editor-input");
		StyledProperty<string?> textProperty30 = TextBox.TextProperty;
		CompiledBindingExtension obj28 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressBlue_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding59 = obj28.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox101.Bind(textProperty30, binding59);
		context.PopParent();
		((ISupportInitialize)textBox100).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel176).EndInit();
		Controls children198 = grid101.Children;
		StackPanel stackPanel179;
		StackPanel stackPanel178 = (stackPanel179 = new StackPanel());
		((ISupportInitialize)stackPanel178).BeginInit();
		children198.Add(stackPanel178);
		StackPanel stackPanel180 = (stackPanel8 = stackPanel179);
		context.PushParent(stackPanel8);
		StackPanel stackPanel181 = stackPanel8;
		Grid.SetColumn(stackPanel181, 3);
		stackPanel181.Spacing = 5.0;
		Controls children199 = stackPanel181.Children;
		TextBlock textBlock157;
		TextBlock textBlock156 = (textBlock157 = new TextBlock());
		((ISupportInitialize)textBlock156).BeginInit();
		children199.Add(textBlock156);
		textBlock157.Text = "Tolerance";
		textBlock157.Classes.Add("field-label");
		((ISupportInitialize)textBlock157).EndInit();
		Controls children200 = stackPanel181.Children;
		TextBox textBox103;
		TextBox textBox102 = (textBox103 = new TextBox());
		((ISupportInitialize)textBox102).BeginInit();
		children200.Add(textBox102);
		TextBox textBox104 = (textBox4 = textBox103);
		context.PushParent(textBox4);
		TextBox textBox105 = textBox4;
		textBox105.Classes.Add("editor-input");
		StyledProperty<string?> textProperty31 = TextBox.TextProperty;
		CompiledBindingExtension obj29 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EProgressColorTolerance_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding60 = obj29.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox105.Bind(textProperty31, binding60);
		context.PopParent();
		((ISupportInitialize)textBox104).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel180).EndInit();
		Controls children201 = grid101.Children;
		Button button73;
		Button button72 = (button73 = new Button());
		((ISupportInitialize)button72).BeginInit();
		children201.Add(button72);
		Button button74 = (button3 = button73);
		context.PushParent(button3);
		Button button75 = button3;
		Grid.SetColumn(button75, 4);
		button75.Classes.Add("ghost-button");
		StyledProperty<ICommand?> commandProperty17 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension37 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EPickProgressColorCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding61 = compiledBindingExtension37.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button75.Bind(commandProperty17, binding61);
		button75.VerticalAlignment = VerticalAlignment.Bottom;
		button75.Content = "Pick fill color";
		context.PopParent();
		((ISupportInitialize)button74).EndInit();
		context.PopParent();
		((ISupportInitialize)grid100).EndInit();
		Controls children202 = stackPanel63.Children;
		TextBlock textBlock159;
		TextBlock textBlock158 = (textBlock159 = new TextBlock());
		((ISupportInitialize)textBlock158).BeginInit();
		children202.Add(textBlock158);
		textBlock159.Text = "SHAKE DETECTION";
		textBlock159.Classes.Add("eyebrow");
		textBlock159.Classes.Add("accent");
		((ISupportInitialize)textBlock159).EndInit();
		Controls children203 = stackPanel63.Children;
		Grid grid103;
		Grid grid102 = (grid103 = new Grid());
		((ISupportInitialize)grid102).BeginInit();
		children203.Add(grid102);
		Grid grid104 = (grid4 = grid103);
		context.PushParent(grid4);
		Grid grid105 = grid4;
		ColumnDefinitions columnDefinitions19 = new ColumnDefinitions();
		columnDefinitions19.Capacity = 2;
		columnDefinitions19.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		columnDefinitions19.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		grid105.ColumnDefinitions = columnDefinitions19;
		Controls children204 = grid105.Children;
		CheckBox checkBox15;
		CheckBox checkBox14 = (checkBox15 = new CheckBox());
		((ISupportInitialize)checkBox14).BeginInit();
		children204.Add(checkBox14);
		CheckBox checkBox16 = (checkBox4 = checkBox15);
		context.PushParent(checkBox4);
		CheckBox checkBox17 = checkBox4;
		checkBox17.Content = "Enable shake key spam";
		StyledProperty<bool?> isCheckedProperty4 = ToggleButton.IsCheckedProperty;
		CompiledBindingExtension obj30 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EShakeEnabled_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = ToggleButton.IsCheckedProperty;
		CompiledBinding binding62 = obj30.ProvideValue(context);
		context.ProvideTargetProperty = null;
		checkBox17.Bind(isCheckedProperty4, binding62);
		context.PopParent();
		((ISupportInitialize)checkBox16).EndInit();
		context.PopParent();
		((ISupportInitialize)grid104).EndInit();
		Controls children205 = stackPanel63.Children;
		Grid grid107;
		Grid grid106 = (grid107 = new Grid());
		((ISupportInitialize)grid106).BeginInit();
		children205.Add(grid106);
		Grid grid108 = (grid4 = grid107);
		context.PushParent(grid4);
		Grid grid109 = grid4;
		ColumnDefinitions columnDefinitions20 = new ColumnDefinitions();
		columnDefinitions20.Capacity = 3;
		columnDefinitions20.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions20.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions20.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid109.ColumnDefinitions = columnDefinitions20;
		grid109.ColumnSpacing = 10.0;
		Controls children206 = grid109.Children;
		StackPanel stackPanel183;
		StackPanel stackPanel182 = (stackPanel183 = new StackPanel());
		((ISupportInitialize)stackPanel182).BeginInit();
		children206.Add(stackPanel182);
		StackPanel stackPanel184 = (stackPanel8 = stackPanel183);
		context.PushParent(stackPanel8);
		StackPanel stackPanel185 = stackPanel8;
		stackPanel185.Spacing = 5.0;
		Controls children207 = stackPanel185.Children;
		TextBlock textBlock161;
		TextBlock textBlock160 = (textBlock161 = new TextBlock());
		((ISupportInitialize)textBlock160).BeginInit();
		children207.Add(textBlock160);
		textBlock161.Text = "Shake key (virtual key code)";
		textBlock161.Classes.Add("field-label");
		((ISupportInitialize)textBlock161).EndInit();
		Controls children208 = stackPanel185.Children;
		TextBox textBox107;
		TextBox textBox106 = (textBox107 = new TextBox());
		((ISupportInitialize)textBox106).BeginInit();
		children208.Add(textBox106);
		TextBox textBox108 = (textBox4 = textBox107);
		context.PushParent(textBox4);
		TextBox textBox109 = textBox4;
		textBox109.Classes.Add("editor-input");
		StyledProperty<string?> textProperty32 = TextBox.TextProperty;
		CompiledBindingExtension obj31 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EShakeVirtualKey_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding63 = obj31.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox109.Bind(textProperty32, binding63);
		context.PopParent();
		((ISupportInitialize)textBox108).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel184).EndInit();
		Controls children209 = grid109.Children;
		StackPanel stackPanel187;
		StackPanel stackPanel186 = (stackPanel187 = new StackPanel());
		((ISupportInitialize)stackPanel186).BeginInit();
		children209.Add(stackPanel186);
		StackPanel stackPanel188 = (stackPanel8 = stackPanel187);
		context.PushParent(stackPanel8);
		StackPanel stackPanel189 = stackPanel8;
		Grid.SetColumn(stackPanel189, 1);
		stackPanel189.Spacing = 5.0;
		Controls children210 = stackPanel189.Children;
		TextBlock textBlock163;
		TextBlock textBlock162 = (textBlock163 = new TextBlock());
		((ISupportInitialize)textBlock162).BeginInit();
		children210.Add(textBlock162);
		textBlock163.Text = "Key hold duration ms";
		textBlock163.Classes.Add("field-label");
		((ISupportInitialize)textBlock163).EndInit();
		Controls children211 = stackPanel189.Children;
		TextBox textBox111;
		TextBox textBox110 = (textBox111 = new TextBox());
		((ISupportInitialize)textBox110).BeginInit();
		children211.Add(textBox110);
		TextBox textBox112 = (textBox4 = textBox111);
		context.PushParent(textBox4);
		TextBox textBox113 = textBox4;
		textBox113.Classes.Add("editor-input");
		StyledProperty<string?> textProperty33 = TextBox.TextProperty;
		CompiledBindingExtension obj32 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESelectedConfiguration_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EConfigurationItemViewModel_002CPFMS_002EShakeClickHoldMs_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build())
		{
			Mode = BindingMode.TwoWay
		};
		context.ProvideTargetProperty = TextBox.TextProperty;
		CompiledBinding binding64 = obj32.ProvideValue(context);
		context.ProvideTargetProperty = null;
		textBox113.Bind(textProperty33, binding64);
		context.PopParent();
		((ISupportInitialize)textBox112).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel188).EndInit();
		Controls children212 = grid109.Children;
		Button button77;
		Button button76 = (button77 = new Button());
		((ISupportInitialize)button76).BeginInit();
		children212.Add(button76);
		Grid.SetColumn(button77, 2);
		button77.Classes.Add("ghost-button");
		button77.VerticalAlignment = VerticalAlignment.Bottom;
		ToolTip.SetTip(button77, "Press Enter here");
		button77.Content = "Default (Enter)";
		((ISupportInitialize)button77).EndInit();
		context.PopParent();
		((ISupportInitialize)grid108).EndInit();
		Controls children213 = stackPanel63.Children;
		TextBlock textBlock165;
		TextBlock textBlock164 = (textBlock165 = new TextBlock());
		((ISupportInitialize)textBlock164).BeginInit();
		children213.Add(textBlock164);
		textBlock165.Text = "Spams the configured key each frame while waiting for YOLO detection. No pixel area needed.";
		textBlock165.Classes.Add("meta-label");
		textBlock165.TextWrapping = TextWrapping.Wrap;
		((ISupportInitialize)textBlock165).EndInit();
		context.PopParent();
		((ISupportInitialize)stackPanel62).EndInit();
		context.PopParent();
		((ISupportInitialize)scrollViewer8).EndInit();
		Controls children214 = grid53.Children;
		Grid grid111;
		Grid grid110 = (grid111 = new Grid());
		((ISupportInitialize)grid110).BeginInit();
		children214.Add(grid110);
		Grid grid112 = (grid4 = grid111);
		context.PushParent(grid4);
		Grid grid113 = grid4;
		Grid.SetRow(grid113, 2);
		ColumnDefinitions columnDefinitions21 = new ColumnDefinitions();
		columnDefinitions21.Capacity = 3;
		columnDefinitions21.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		columnDefinitions21.Add(new ColumnDefinition(new GridLength(1.0, GridUnitType.Star)));
		columnDefinitions21.Add(new ColumnDefinition(new GridLength(0.0, GridUnitType.Auto)));
		grid113.ColumnDefinitions = columnDefinitions21;
		Controls children215 = grid113.Children;
		Button button79;
		Button button78 = (button79 = new Button());
		((ISupportInitialize)button78).BeginInit();
		children215.Add(button78);
		Button button80 = (button3 = button79);
		context.PushParent(button3);
		Button button81 = button3;
		button81.Classes.Add("danger-button");
		StyledProperty<ICommand?> commandProperty18 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension38 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002EDeleteConfigurationCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding65 = compiledBindingExtension38.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button81.Bind(commandProperty18, binding65);
		button81.Content = "Delete";
		context.PopParent();
		((ISupportInitialize)button80).EndInit();
		Controls children216 = grid113.Children;
		Button button83;
		Button button82 = (button83 = new Button());
		((ISupportInitialize)button82).BeginInit();
		children216.Add(button82);
		Button button84 = (button3 = button83);
		context.PushParent(button3);
		Button button85 = button3;
		Grid.SetColumn(button85, 2);
		button85.Classes.Add("primary-button");
		StyledProperty<ICommand?> commandProperty19 = Button.CommandProperty;
		CompiledBindingExtension compiledBindingExtension39 = new CompiledBindingExtension(new CompiledBindingPathBuilder().Property(CompiledAvaloniaXaml.XamlIlHelpers.Pfm_002EViewModels_002EMainViewModel_002CPFMS_002ESaveConfigurationCommand_0021Property(), PropertyInfoAccessorFactory.CreateInpcPropertyAccessor).Build());
		context.ProvideTargetProperty = Button.CommandProperty;
		CompiledBinding binding66 = compiledBindingExtension39.ProvideValue(context);
		context.ProvideTargetProperty = null;
		button85.Bind(commandProperty19, binding66);
		button85.Content = "Save configuration";
		context.PopParent();
		((ISupportInitialize)button84).EndInit();
		context.PopParent();
		((ISupportInitialize)grid112).EndInit();
		context.PopParent();
		((ISupportInitialize)grid52).EndInit();
		context.PopParent();
		((ISupportInitialize)border30).EndInit();
		context.PopParent();
		((ISupportInitialize)grid20).EndInit();
		context.PopParent();
		((ISupportInitialize)grid12).EndInit();
		context.PopParent();
		((ISupportInitialize)grid3).EndInit();
		context.PopParent();
		((ISupportInitialize)border3).EndInit();
		context.PopParent();
		((ISupportInitialize)P_1).EndInit();
		if (P_1 is StyledElement styled)
		{
			NameScope.SetNameScope(styled, context.AvaloniaNameScope);
		}
		context.AvaloniaNameScope.Complete();
	}

	[CompilerGenerated]
	private static void _0021XamlIlPopulateTrampoline(MainWindow P_0)
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

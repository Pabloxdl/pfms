using System;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Media;

namespace CompiledAvaloniaXaml;

[CompilerGenerated]
internal class XamlDynamicSetters
{
	public static void _003C_003EXamlDynamicSetter_1(SolidColorBrush P_0, object P_1)
	{
		if (P_1 is UnsetValueType)
		{
			P_0.SetValue(SolidColorBrush.ColorProperty, AvaloniaProperty.UnsetValue);
			return;
		}
		if (P_1 is BindingBase)
		{
			BindingBase binding = (BindingBase)P_1;
			P_0.Bind(SolidColorBrush.ColorProperty, binding);
			return;
		}
		if (P_1 is Color)
		{
			P_0.Color = (Color)P_1;
			return;
		}
		if (P_1 == null)
		{
			throw new NullReferenceException();
		}
		throw new InvalidCastException();
	}

	public static void _003C_003EXamlDynamicSetter_2(Button P_0, CompiledBinding P_1)
	{
		if (P_1 != null)
		{
			BindingBase binding = P_1;
			P_0.Bind(Button.CommandParameterProperty, binding);
		}
		else
		{
			P_0.CommandParameter = P_1;
		}
	}

	public static void _003C_003EXamlDynamicSetter_3(SelectingItemsControl P_0, CompiledBinding P_1)
	{
		if (P_1 != null)
		{
			BindingBase binding = P_1;
			P_0.Bind(SelectingItemsControl.SelectedItemProperty, binding);
		}
		else
		{
			P_0.SelectedItem = P_1;
		}
	}
}

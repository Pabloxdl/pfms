using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Pfm.Services.Vision;

public class HexToColorConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture)
	{
		if (value is string s)
		{
			try
			{
				return Color.Parse(s);
			}
			catch
			{
				return Color.Parse("#808080");
			}
		}
		return Color.Parse("#808080");
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture)
	{
		throw new NotSupportedException();
	}
}

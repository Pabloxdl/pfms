using System;

namespace Pfm.Core.Configuration;

public sealed class ScreenRegion
{
	public bool IsEnabled { get; set; } = true;

	public int X { get; set; }

	public int Y { get; set; }

	public int Width { get; set; }

	public int Height { get; set; }

	public void Validate(string name)
	{
		if (!IsEnabled || (Width > 0 && Height > 0))
		{
			return;
		}
		throw new InvalidOperationException(name + " must have a positive width and height.");
	}
}

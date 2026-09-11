namespace Pfm.Core.Configuration;

public sealed class ColorHint
{
	public byte R { get; set; }

	public byte G { get; set; }

	public byte B { get; set; }

	public byte Tolerance { get; set; } = 30;

	public bool IsEnabled { get; set; }
}

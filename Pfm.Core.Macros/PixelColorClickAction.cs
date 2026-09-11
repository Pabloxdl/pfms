namespace Pfm.Core.Macros;

public sealed class PixelColorClickAction : PixelColorCheckAction
{
	public MacroMouseButton Button { get; set; }

	public int DelayMs { get; set; }

	public int HoldMs { get; set; } = 18;
}

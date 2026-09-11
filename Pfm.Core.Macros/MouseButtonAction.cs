namespace Pfm.Core.Macros;

public sealed class MouseButtonAction : MacroAction
{
	public MacroMouseButton Button { get; set; }

	public MacroMouseActionKind ActionKind { get; set; }

	public bool MoveCursor { get; set; }

	public int X { get; set; }

	public int Y { get; set; }

	public int DelayMs { get; set; }

	public int HoldMs { get; set; } = 20;
}

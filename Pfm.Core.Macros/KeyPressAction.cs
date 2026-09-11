namespace Pfm.Core.Macros;

public sealed class KeyPressAction : MacroAction
{
	public ushort VirtualKey { get; set; } = 32;

	public int DelayMs { get; set; }

	public int HoldMs { get; set; } = 18;
}

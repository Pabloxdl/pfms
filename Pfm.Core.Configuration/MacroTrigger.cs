namespace Pfm.Core.Configuration;

public sealed class MacroTrigger
{
	public string Kind { get; set; } = "Hotkey";

	public string Value { get; set; } = string.Empty;
}

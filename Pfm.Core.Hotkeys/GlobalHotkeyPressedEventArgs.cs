using System;

namespace Pfm.Core.Hotkeys;

public sealed class GlobalHotkeyPressedEventArgs(GlobalHotkeyCommand command) : EventArgs
{
	public GlobalHotkeyCommand Command { get; } = command;
}

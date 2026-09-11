using System;

namespace Pfm.Core.Hotkeys;

public interface IGlobalHotkeyService : IDisposable
{
	event EventHandler<GlobalHotkeyPressedEventArgs>? HotkeyPressed;

	void Start(GlobalHotkeyBinding startBinding, GlobalHotkeyBinding stopBinding);
}

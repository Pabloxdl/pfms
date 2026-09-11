using System;

namespace Pfm.Core.Hotkeys;

[Flags]
public enum HotkeyModifiers : uint
{
	None = 0u,
	Alt = 1u,
	Control = 2u,
	Shift = 4u,
	Windows = 8u
}

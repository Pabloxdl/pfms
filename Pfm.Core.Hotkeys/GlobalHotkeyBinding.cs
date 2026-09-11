namespace Pfm.Core.Hotkeys;

public sealed record GlobalHotkeyBinding(ushort VirtualKey, HotkeyModifiers Modifiers = HotkeyModifiers.None);

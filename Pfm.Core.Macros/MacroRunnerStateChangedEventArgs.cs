using System;

namespace Pfm.Core.Macros;

public sealed class MacroRunnerStateChangedEventArgs(bool isRunning, MacroRunResult? result) : EventArgs
{
	public bool IsRunning { get; } = isRunning;

	public MacroRunResult? Result { get; } = result;
}

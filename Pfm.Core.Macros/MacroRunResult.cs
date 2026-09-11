namespace Pfm.Core.Macros;

public sealed record MacroRunResult(bool Succeeded, bool WasCancelled, string Message, long ExecutedActions)
{
	public static MacroRunResult Stopped(long executedActions)
	{
		return new MacroRunResult(Succeeded: true, WasCancelled: true, "Macro stopped.", executedActions);
	}

	public static MacroRunResult Completed(long executedActions)
	{
		return new MacroRunResult(Succeeded: true, WasCancelled: false, "Macro completed.", executedActions);
	}

	public static MacroRunResult Failed(string message, long executedActions)
	{
		return new MacroRunResult(Succeeded: false, WasCancelled: false, message, executedActions);
	}
}

namespace Pfm.Core.Fishing;

public sealed record FishingProcessResult(bool Succeeded, string Message, string? DiagnosticCode = null)
{
	public static FishingProcessResult NotImplemented(string mechanicId)
	{
		return new FishingProcessResult(Succeeded: false, "The '" + mechanicId + "' fishing mechanic has not been implemented.", "MECHANIC_NOT_IMPLEMENTED");
	}
}

namespace Pfm.Core.Configuration;

public sealed class DetectionClassDefinition
{
	public int Id { get; set; }

	public string Name { get; set; } = "Custom class";

	public DetectionBehavior Behavior { get; set; }

	public double Weight { get; set; } = 1.0;

	public string InfluenceFormula { get; set; } = string.Empty;

	public ColorHint? ColorHint { get; set; }
}

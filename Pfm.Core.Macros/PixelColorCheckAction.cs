using Pfm.Core.Configuration;

namespace Pfm.Core.Macros;

public class PixelColorCheckAction : MacroAction
{
	public ScreenRegion Region { get; set; } = new ScreenRegion();

	public PixelColor ExpectedColor { get; set; } = new PixelColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);

	public byte ColorTolerance { get; set; } = 24;

	public double RequiredMatchRatio { get; set; } = 0.01;

	public int MinimumMatchingPixels { get; set; } = 1;

	public int SampleStride { get; set; } = 1;

	public PixelColorCheckAction()
	{
		base.ConditionRequirement = true;
	}
}

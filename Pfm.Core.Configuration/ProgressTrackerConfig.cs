namespace Pfm.Core.Configuration;

public sealed class ProgressTrackerConfig
{
	public bool IsEnabled { get; set; }

	public PixelColor FillColor { get; set; } = new PixelColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);

	public byte ColorTolerance { get; set; } = 28;

	public int MinimumMatchingPixels { get; set; } = 3;
}

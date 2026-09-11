namespace Pfm.Core.Configuration;

public sealed class SliderTrackerConfig
{
	public PixelColor ControlBarColor { get; set; } = new PixelColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);

	public PixelColor TargetColor { get; set; } = new PixelColor(66, 174, byte.MaxValue);

	public byte ColorTolerance { get; set; } = 28;

	public int MinimumMatchingPixels { get; set; } = 6;

	public double DeadZoneNormalized { get; set; } = 0.025;

	public double Kp { get; set; } = 1.0;

	public double Kd { get; set; } = 0.04;

	public int DeadZonePixels { get; set; } = 4;

	public ushort MoveLeftVirtualKey { get; set; } = 65;

	public ushort MoveRightVirtualKey { get; set; } = 68;
}

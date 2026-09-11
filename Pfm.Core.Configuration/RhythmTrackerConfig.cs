namespace Pfm.Core.Configuration;

public sealed class RhythmTrackerConfig
{
	public bool IsEnabled { get; set; }

	public PixelColor TriggerColor { get; set; } = new PixelColor(byte.MaxValue, 236, 130);

	public byte ColorTolerance { get; set; } = 24;

	public double TriggerPixelRatio { get; set; } = 0.035;

	public double ResetPixelRatio { get; set; } = 0.012;

	public byte MinimumLumaDelta { get; set; } = 20;

	public int DelayMs { get; set; }

	public int KeyHoldMs { get; set; } = 18;

	public int CooldownMs { get; set; } = 120;

	public ushort VirtualKey { get; set; } = 13;
}

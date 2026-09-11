using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Pfm.Core.Configuration;

public sealed class RodConfig
{
	public string Id { get; set; } = "standard";

	public string DisplayName { get; set; } = "Standard rod";

	public ScreenRegion PrimaryRegion { get; set; } = new ScreenRegion();

	public ScreenRegion? SecondaryRegion { get; set; }

	public ScreenRegion? ProgressRegion { get; set; }

	public SliderTrackerConfig Slider { get; set; } = new SliderTrackerConfig();

	public RhythmTrackerConfig Rhythm { get; set; } = new RhythmTrackerConfig();

	public ProgressTrackerConfig Progress { get; set; } = new ProgressTrackerConfig();

	public int TargetFramesPerSecond { get; set; } = 120;

	public Dictionary<string, JsonNode?> Parameters { get; init; } = new Dictionary<string, JsonNode>(StringComparer.OrdinalIgnoreCase);

	public bool HasRhythmTracker
	{
		get
		{
			ScreenRegion secondaryRegion = SecondaryRegion;
			if (secondaryRegion != null && secondaryRegion.IsEnabled)
			{
				return Rhythm.IsEnabled;
			}
			return false;
		}
	}

	public bool HasProgressTracker
	{
		get
		{
			ScreenRegion progressRegion = ProgressRegion;
			if (progressRegion != null && progressRegion.IsEnabled)
			{
				return Progress.IsEnabled;
			}
			return false;
		}
	}

	public void Validate()
	{
		if (!PrimaryRegion.IsEnabled)
		{
			throw new InvalidOperationException("Primary ROI must be enabled.");
		}
		PrimaryRegion.Validate("Primary ROI");
		int targetFramesPerSecond = TargetFramesPerSecond;
		if ((targetFramesPerSecond < 60 || targetFramesPerSecond > 240) ? true : false)
		{
			throw new InvalidOperationException("TargetFramesPerSecond must be between 60 and 240.");
		}
		double deadZoneNormalized = Slider.DeadZoneNormalized;
		if ((deadZoneNormalized < 0.0 || deadZoneNormalized >= 1.0) ? true : false)
		{
			throw new InvalidOperationException("Slider dead zone must be between 0 and 1.");
		}
		if (Slider.MinimumMatchingPixels <= 0)
		{
			throw new InvalidOperationException("Slider minimum matching pixels must be positive.");
		}
		if (!double.IsFinite(Slider.Kp) || Slider.Kp < 0.0 || !double.IsFinite(Slider.Kd) || Slider.Kd < 0.0 || Slider.DeadZonePixels < 0)
		{
			throw new InvalidOperationException("Slider PD settings are invalid.");
		}
		if (!HasRhythmTracker)
		{
			ValidateProgress();
			return;
		}
		if (SecondaryRegion != null)
		{
			SecondaryRegion.Validate("Secondary ROI");
		}
		deadZoneNormalized = Rhythm.TriggerPixelRatio;
		bool flag = ((deadZoneNormalized <= 0.0 || deadZoneNormalized > 1.0) ? true : false);
		bool flag2 = flag;
		if (!flag2)
		{
			double resetPixelRatio = Rhythm.ResetPixelRatio;
			bool flag3 = ((resetPixelRatio < 0.0 || resetPixelRatio > 1.0) ? true : false);
			flag2 = flag3;
		}
		if (flag2 || Rhythm.ResetPixelRatio >= Rhythm.TriggerPixelRatio)
		{
			throw new InvalidOperationException("Rhythm pixel ratios are invalid.");
		}
		if (Rhythm.DelayMs < 0 || Rhythm.KeyHoldMs < 0 || Rhythm.CooldownMs < 0)
		{
			throw new InvalidOperationException("Rhythm timing values cannot be negative.");
		}
		ValidateProgress();
	}

	private void ValidateProgress()
	{
		if (HasProgressTracker)
		{
			ProgressRegion.Validate("Progress ROI");
			if (Progress.MinimumMatchingPixels <= 0)
			{
				throw new InvalidOperationException("Progress minimum matching pixels must be positive.");
			}
		}
	}
}

using System;
using System.Diagnostics;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class ColorRhythmDetector : IRhythmDetector
{
	private bool _armed = true;

	private bool _hasBaseline;

	private double _previousAverageLuma;

	private double _previousMatchRatio;

	private long _lastTriggerTimestamp;

	public bool Evaluate(in PixelFrame frame, RhythmTrackerConfig config, long timestamp)
	{
		int num = 0;
		long num2 = 0L;
		int num3 = frame.Width * frame.Height;
		for (int i = 0; i < frame.Height; i++)
		{
			for (int j = 0; j < frame.Width; j++)
			{
				num += (frame.Matches(j, i, config.TriggerColor, config.ColorTolerance) ? 1 : 0);
				num2 += frame.GetLuma(j, i);
			}
		}
		double num4 = ((num3 == 0) ? 0.0 : ((double)num / (double)num3));
		double num5 = ((num3 == 0) ? 0.0 : ((double)num2 / (double)num3));
		if (!_hasBaseline)
		{
			_hasBaseline = true;
			_previousAverageLuma = num5;
			_previousMatchRatio = num4;
			return false;
		}
		double num6 = Math.Abs(num5 - _previousAverageLuma);
		_previousAverageLuma = num5;
		bool flag = _previousMatchRatio < config.TriggerPixelRatio && num4 >= config.TriggerPixelRatio;
		_previousMatchRatio = num4;
		if (!_armed && num4 <= config.ResetPixelRatio)
		{
			_armed = true;
		}
		long num7 = config.CooldownMs * Stopwatch.Frequency / 1000;
		if (!_armed || num4 < config.TriggerPixelRatio || (!flag && num6 < (double)(int)config.MinimumLumaDelta) || timestamp - _lastTriggerTimestamp < num7)
		{
			return false;
		}
		_armed = false;
		_lastTriggerTimestamp = timestamp;
		return true;
	}

	bool IRhythmDetector.Evaluate(in PixelFrame frame, RhythmTrackerConfig config, long timestamp)
	{
		return Evaluate(in frame, config, timestamp);
	}
}

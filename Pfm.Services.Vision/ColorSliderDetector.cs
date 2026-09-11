using System;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class ColorSliderDetector : ISliderDetector
{
	public SliderObservation Evaluate(in PixelFrame frame, SliderTrackerConfig config)
	{
		int num = -1;
		int targetY = -1;
		for (int i = 0; i < frame.Height; i++)
		{
			for (int j = 0; j < frame.Width; j++)
			{
				if (frame.Matches(j, i, config.TargetColor, config.ColorTolerance))
				{
					num = j;
					targetY = i;
					break;
				}
			}
			if (num >= 0)
			{
				break;
			}
		}
		if (num < 0)
		{
			return SliderObservation.NotDetected;
		}
		int num2 = -1;
		int num3 = -1;
		int num4 = Math.Clamp((int)((double)frame.Height * 0.7), 0, frame.Height - 1);
		for (int num5 = frame.Height - 1; num5 >= num4; num5--)
		{
			int num6 = -1;
			int num7 = -1;
			for (int k = 0; k < frame.Width; k++)
			{
				if (frame.Matches(k, num5, config.ControlBarColor, config.ColorTolerance))
				{
					num6 = ((num6 < 0) ? k : num6);
					num7 = k;
				}
			}
			if (num6 >= 0 && num7 - num6 > num3 - num2)
			{
				num2 = num6;
				num3 = num7;
			}
		}
		if (num2 < 0 || num3 - num2 + 1 < config.MinimumMatchingPixels)
		{
			return SliderObservation.NotDetected with
			{
				TargetDetected = true,
				TargetX = num,
				TargetY = targetY
			};
		}
		int num8 = (num2 + num3) / 2;
		int num9 = num - num8;
		return new SliderObservation(IsDetected: true, (double)num9 / (double)frame.Width)
		{
			TargetDetected = true,
			TargetX = num,
			TargetY = targetY,
			PlayerStartX = num2,
			PlayerEndX = num3,
			PlayerCenterX = num8,
			ErrorPixels = num9
		};
	}

	public int? DetectMetronomeArrow(in PixelFrame frame, int scanY, int darkThreshold, int whiteThreshold)
	{
		if (scanY < 0 || scanY >= frame.Height)
		{
			return null;
		}
		for (int i = 1; i < frame.Width - 1; i++)
		{
			if (frame.GetLuma(i, scanY) < darkThreshold)
			{
				byte luma = frame.GetLuma(i - 1, scanY);
				byte luma2 = frame.GetLuma(i + 1, scanY);
				if (luma >= whiteThreshold || luma2 >= whiteThreshold)
				{
					return i;
				}
			}
		}
		return null;
	}

	SliderObservation ISliderDetector.Evaluate(in PixelFrame frame, SliderTrackerConfig config)
	{
		return Evaluate(in frame, config);
	}
}

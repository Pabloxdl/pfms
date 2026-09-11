using System;
using Pfm.Core.Macros;
using Pfm.Core.Vision;

namespace Pfm.Services.Macros;

internal static class PixelActionEvaluator
{
	public static bool Evaluate(in PixelFrame frame, PixelColorCheckAction action)
	{
		return FindMatch(in frame, action).IsMatch;
	}

	public static PixelMatch FindMatch(in PixelFrame frame, PixelColorCheckAction action)
	{
		int num = 0;
		int num2 = 0;
		long num3 = 0L;
		long num4 = 0L;
		int num5 = Math.Max(1, action.SampleStride);
		for (int i = 0; i < frame.Height; i += num5)
		{
			for (int j = 0; j < frame.Width; j += num5)
			{
				num2++;
				if (frame.Matches(j, i, action.ExpectedColor, action.ColorTolerance))
				{
					num++;
					num3 += j;
					num4 += i;
				}
			}
		}
		if (num < action.MinimumMatchingPixels || num2 <= 0 || !((double)num / (double)num2 >= action.RequiredMatchRatio))
		{
			return PixelMatch.NotFound;
		}
		return new PixelMatch(IsMatch: true, (int)(num3 / num), (int)(num4 / num));
	}
}

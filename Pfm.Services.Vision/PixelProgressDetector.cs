using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class PixelProgressDetector : IProgressDetector
{
	public ProgressObservation Evaluate(in PixelFrame frame, ProgressTrackerConfig config)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < frame.Width; i++)
		{
			bool flag = false;
			for (int j = 0; j < frame.Height; j++)
			{
				if (frame.Matches(i, j, config.FillColor, config.ColorTolerance))
				{
					num++;
					flag = true;
				}
			}
			num2 += (flag ? 1 : 0);
		}
		bool isDetected = num >= config.MinimumMatchingPixels;
		double fillPercent = ((frame.Width == 0) ? 0.0 : ((double)num2 * 100.0 / (double)frame.Width));
		return new ProgressObservation(isDetected, fillPercent, num);
	}

	ProgressObservation IProgressDetector.Evaluate(in PixelFrame frame, ProgressTrackerConfig config)
	{
		return Evaluate(in frame, config);
	}
}

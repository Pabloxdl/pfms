using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IRhythmDetector
{
	bool Evaluate(in PixelFrame frame, RhythmTrackerConfig config, long timestamp);
}

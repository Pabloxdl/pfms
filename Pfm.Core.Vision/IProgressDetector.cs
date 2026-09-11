using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IProgressDetector
{
	ProgressObservation Evaluate(in PixelFrame frame, ProgressTrackerConfig config);
}

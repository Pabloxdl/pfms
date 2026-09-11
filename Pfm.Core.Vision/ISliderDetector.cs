using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface ISliderDetector
{
	SliderObservation Evaluate(in PixelFrame frame, SliderTrackerConfig config);
}

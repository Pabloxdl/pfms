using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IScreenCaptureFactory
{
	IScreenCaptureSession Create(ScreenRegion region);
}

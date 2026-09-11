using System;

namespace Pfm.Core.Vision;

public interface IScreenCaptureSession : IDisposable
{
	PixelFrame Capture();
}

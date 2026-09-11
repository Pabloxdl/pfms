using System;

namespace Pfm.Core.Vision;

public interface IAiObjectDetectionRunner : IDisposable
{
	AiDetectionResult Detect(in PixelFrame frame, string modelFilePath, double confidenceThreshold, int targetClassId = 0, int playerBarClassId = 1, int progressClassId = -1);
}

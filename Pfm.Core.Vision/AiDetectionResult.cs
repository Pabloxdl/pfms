using System.Collections.Generic;

namespace Pfm.Core.Vision;

public readonly record struct AiDetectionResult(AiDetectionBox? FishTarget, AiDetectionBox? PlayerBar, AiDetectionBox? ProgressBar = null, IReadOnlyList<AiDetectionBox>? Boxes = null);

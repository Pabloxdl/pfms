using System.Collections.Generic;

namespace Pfm.Core.Vision;

public sealed record VisionDebugFrame(byte[] PngData, string Summary, int DetectionCount, string? Error = null, IReadOnlyList<DetectionDisplayBox>? Boxes = null, int FrameWidth = 0, int FrameHeight = 0, BarStripFrame? BarStrip = null);

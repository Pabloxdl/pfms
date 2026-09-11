using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public sealed record BarStripBox(double Start, double End, string ColorHex, string Label, DetectionBehavior Behavior);

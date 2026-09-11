using System.Collections.Generic;

namespace Pfm.Core.Vision;

public sealed record BarStripFrame(double ControlStart, double ControlEnd, double TargetCenter, IReadOnlyList<BarStripBox> AllBoxes);

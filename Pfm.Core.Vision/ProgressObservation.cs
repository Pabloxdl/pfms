namespace Pfm.Core.Vision;

public readonly record struct ProgressObservation(bool IsDetected, double FillPercent, int MatchingPixels);

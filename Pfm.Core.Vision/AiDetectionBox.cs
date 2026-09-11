namespace Pfm.Core.Vision;

public readonly record struct AiDetectionBox(int X, int Y, int Width, int Height, double Confidence, int ClassId);

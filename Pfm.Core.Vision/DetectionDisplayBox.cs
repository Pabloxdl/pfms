namespace Pfm.Core.Vision;

public sealed record DetectionDisplayBox(int X, int Y, int Width, int Height, string Label, string ColorHex, double Confidence);

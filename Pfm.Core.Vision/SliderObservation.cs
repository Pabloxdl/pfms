using System;
using System.Collections.Generic;

namespace Pfm.Core.Vision;

public readonly record struct SliderObservation(bool IsDetected, double NormalizedError)
{
	public bool TargetDetected { get; init; } = false;

	public int TargetX { get; init; } = 0;

	public int TargetY { get; init; } = 0;

	public int PlayerStartX { get; init; } = 0;

	public int PlayerEndX { get; init; } = 0;

	public int PlayerCenterX { get; init; } = 0;

	public int ErrorPixels { get; init; } = 0;

	public AiDetectionBox? ProgressBar { get; init; } = null;

	public IReadOnlyList<AiDetectionBox> DetectionBoxes { get; init; } = Array.Empty<AiDetectionBox>();

	public int PursuitCount { get; init; } = 0;

	public int AvoidanceCount { get; init; } = 0;

	public bool UsedCustomSteeringFormula { get; init; } = false;

	public static SliderObservation NotDetected => new SliderObservation(IsDetected: false, 0.0);
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public static class DetectionDisplayFormatter
{
	public static (string Name, Color Color) DescribeClass(int classId, FishingProfile profile)
	{
		DetectionClassDefinition detectionClassDefinition = profile.CustomClasses.FirstOrDefault((DetectionClassDefinition item) => item.Id == classId);
		if (detectionClassDefinition != null && detectionClassDefinition.Behavior == DetectionBehavior.Pursue)
		{
			return (Name: detectionClassDefinition.Name, Color: Color.FromArgb(86, 221, 170));
		}
		if (detectionClassDefinition != null && detectionClassDefinition.Behavior == DetectionBehavior.Control)
		{
			return (Name: detectionClassDefinition.Name, Color: Color.FromArgb(95, 170, 255));
		}
		if (detectionClassDefinition != null && detectionClassDefinition.Behavior == DetectionBehavior.Progress)
		{
			return (Name: detectionClassDefinition.Name, Color: Color.FromArgb(255, 198, 90));
		}
		if (detectionClassDefinition != null && detectionClassDefinition.Behavior == DetectionBehavior.Avoid)
		{
			return (Name: detectionClassDefinition.Name, Color: Color.FromArgb(255, 104, 112));
		}
		return (Name: detectionClassDefinition?.Name ?? $"Class {classId}", Color: Color.FromArgb(225, 110, 190));
	}

	public static DetectionDisplayBox[] BuildDisplayBoxes(IReadOnlyList<AiDetectionBox> boxes, FishingProfile profile)
	{
		return boxes.Select(delegate(AiDetectionBox box)
		{
			var (value, color) = DescribeClass(box.ClassId, profile);
			return new DetectionDisplayBox(box.X, box.Y, box.Width, box.Height, $"{value} {box.Confidence:P0}", $"#{color.R:X2}{color.G:X2}{color.B:X2}", box.Confidence);
		}).ToArray();
	}

	public static string BuildSummary(SliderObservation observation, FishingProfile profile, ProgressObservation? pixelProgress)
	{
		string value = (observation.TargetDetected ? $"Fish x={observation.TargetX}" : "Fish missing");
		string value2 = (observation.IsDetected ? $"Control x={observation.PlayerCenterX}" : "Control missing");
		bool flag = profile.CustomClasses.Any((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Progress);
		object obj;
		if (!flag && pixelProgress.HasValue)
		{
			ProgressObservation valueOrDefault = pixelProgress.GetValueOrDefault();
			obj = (valueOrDefault.IsDetected ? $"Pixel progress {valueOrDefault.FillPercent:F0}%" : "Pixel progress missing");
		}
		else if (flag)
		{
			AiDetectionBox? progressBar = observation.ProgressBar;
			if (progressBar.HasValue)
			{
				AiDetectionBox valueOrDefault2 = progressBar.GetValueOrDefault();
				obj = $"Progress detected ({valueOrDefault2.Confidence:P0})";
			}
			else
			{
				obj = "Progress missing";
			}
		}
		else
		{
			obj = "Progress disabled";
		}
		string value3 = (string)obj;
		string value4 = (observation.UsedCustomSteeringFormula ? "custom formula" : "behavior blend");
		return $"{value} | {value2} | {value3} | pursue {observation.PursuitCount} | avoid {observation.AvoidanceCount} | {value4} | error {observation.ErrorPixels}px";
	}

	public static string BuildClassStatus(SliderObservation observation, FishingProfile profile)
	{
		HashSet<int> detectedIds = observation.DetectionBoxes.Select((AiDetectionBox box) => box.ClassId).ToHashSet();
		return string.Join(" | ", from item in profile.CustomClasses
			orderby item.Id
			select item.Name + ": " + (detectedIds.Contains(item.Id) ? "seen" : "missing"));
	}

	public static BarStripFrame BuildBarStrip(SliderObservation observation, FishingProfile profile, int frameWidth)
	{
		int width = Math.Max(1, frameWidth);
		BarStripBox[] allBoxes = observation.DetectionBoxes.Select(delegate(AiDetectionBox box)
		{
			(string Name, Color Color) tuple = DescribeClass(box.ClassId, profile);
			string item = tuple.Name;
			Color item2 = tuple.Color;
			DetectionBehavior behavior = profile.CustomClasses.FirstOrDefault((DetectionClassDefinition detectionClassDefinition) => detectionClassDefinition.Id == box.ClassId)?.Behavior ?? DetectionBehavior.Observe;
			return new BarStripBox((double)box.X / (double)width, (double)(box.X + box.Width) / (double)width, $"#{item2.R:X2}{item2.G:X2}{item2.B:X2}", $"{item} {box.Confidence:P0}", behavior);
		}).ToArray();
		return new BarStripFrame(observation.IsDetected ? ((double)observation.PlayerStartX / (double)width) : double.NaN, observation.IsDetected ? ((double)observation.PlayerEndX / (double)width) : double.NaN, observation.TargetDetected ? ((double)observation.TargetX / (double)width) : double.NaN, allBoxes);
	}
}

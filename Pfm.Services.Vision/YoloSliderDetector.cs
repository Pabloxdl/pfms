using System;
using System.Collections.Generic;
using System.Linq;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class YoloSliderDetector
{
	private readonly record struct RoleInfluence(double Error, double Weight);

	private readonly IAiObjectDetectionRunner _runner;

	public YoloSliderDetector(IAiObjectDetectionRunner runner)
	{
		_runner = runner;
	}

	public void ResetModelSession(FishingProfile profile)
	{
		if (_runner is IModelSessionResetter modelSessionResetter)
		{
			modelSessionResetter.ResetModelSession(profile.ModelFilePath);
		}
	}

	public SliderObservation Evaluate(in PixelFrame frame, FishingProfile profile)
	{
		profile.EnsureDefaultClasses();
		int id = profile.CustomClasses.First((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Pursue).Id;
		int id2 = profile.CustomClasses.Single((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Control).Id;
		int progressClassId = profile.CustomClasses.FirstOrDefault((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Progress)?.Id ?? (-1);
		AiDetectionResult detections = _runner.Detect(in frame, profile.ModelFilePath, profile.ConfidenceThreshold, id, id2, progressClassId);
		PixelFrame frameCopy = frame;
		AiDetectionBox[] array = (detections.Boxes?.ToArray() ?? BuildLegacyBoxes(detections)).Where(delegate(AiDetectionBox box)
		{
			ColorHint colorHint = profile.CustomClasses.FirstOrDefault((DetectionClassDefinition c) => c.Id == box.ClassId)?.ColorHint;
			return colorHint == null || !colorHint.IsEnabled || BoxMatchesColorHint(frameCopy, box, colorHint);
		}).ToArray();
		HashSet<int> controlIds = (from item in profile.CustomClasses
			where item.Behavior == DetectionBehavior.Control
			select item.Id).ToHashSet();
		AiDetectionBox aiDetectionBox = (from box in array
			where controlIds.Contains(box.ClassId)
			orderby box.Confidence descending
			select box).FirstOrDefault();
		HashSet<int> progressIds = (from item in profile.CustomClasses
			where item.Behavior == DetectionBehavior.Progress
			select item.Id).ToHashSet();
		AiDetectionBox? progressBar = (from box in array
			where progressIds.Contains(box.ClassId)
			orderby box.Confidence descending
			select box).Cast<AiDetectionBox?>().FirstOrDefault();
		Dictionary<int, DetectionClassDefinition> definitions = profile.CustomClasses.Where(delegate(DetectionClassDefinition item)
		{
			DetectionBehavior behavior = item.Behavior;
			return (uint)(behavior - 3) <= 1u;
		}).ToDictionary((DetectionClassDefinition item) => item.Id);
		AiDetectionBox[] source = array.Where((AiDetectionBox box) => definitions.ContainsKey(box.ClassId)).ToArray();
		AiDetectionBox[] array2 = source.Where((AiDetectionBox box) => definitions[box.ClassId].Behavior == DetectionBehavior.Pursue).ToArray();
		AiDetectionBox[] array3 = source.Where((AiDetectionBox box) => definitions[box.ClassId].Behavior == DetectionBehavior.Avoid).ToArray();
		if (array2.Length == 0)
		{
			return SliderObservation.NotDetected with
			{
				ProgressBar = progressBar,
				DetectionBoxes = array,
				AvoidanceCount = array3.Length
			};
		}
		AiDetectionBox aiDetectionBox2 = array2.OrderByDescending((AiDetectionBox box) => box.Confidence).First();
		int num = aiDetectionBox2.X + aiDetectionBox2.Width / 2;
		int targetY = aiDetectionBox2.Y + aiDetectionBox2.Height / 2;
		if (aiDetectionBox == default(AiDetectionBox))
		{
			return new SliderObservation(IsDetected: false, 0.0)
			{
				TargetDetected = true,
				TargetX = num,
				TargetY = targetY,
				ProgressBar = progressBar,
				DetectionBoxes = array,
				PursuitCount = array2.Length,
				AvoidanceCount = array3.Length
			};
		}
		int num2 = aiDetectionBox.X + aiDetectionBox.Width / 2;
		RoleInfluence roleInfluence = CalculateRoleInfluence(array2, definitions, aiDetectionBox, frame.Width, frame.Height, isAvoidance: false);
		RoleInfluence roleInfluence2 = CalculateRoleInfluence(array3, definitions, aiDetectionBox, frame.Width, frame.Height, isAvoidance: true, (double)num2 + roleInfluence.Error);
		int num3 = num - num2;
		double num4 = ((roleInfluence2.Weight <= 0.0) ? 0.0 : (roleInfluence2.Weight / Math.Max(0.001, roleInfluence.Weight + roleInfluence2.Weight)));
		double num5 = Math.Abs(roleInfluence.Error) * 0.3 * num4;
		double num6 = roleInfluence.Error - (double)Math.Sign(roleInfluence.Error) * num5;
		bool flag = !string.IsNullOrWhiteSpace(profile.SteeringFormula);
		double value = num6;
		if (flag)
		{
			try
			{
				value = SafeNumericExpression.Evaluate(profile.SteeringFormula, new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
				{
					["pursuit_error"] = roleInfluence.Error,
					["avoidance_error"] = roleInfluence2.Error,
					["pursuit_weight"] = roleInfluence.Weight,
					["avoidance_weight"] = roleInfluence2.Weight,
					["legacy_error"] = num3,
					["player_x"] = num2,
					["frame_width"] = frame.Width,
					["frame_height"] = frame.Height
				});
			}
			catch (InvalidOperationException)
			{
				value = num6;
				flag = false;
			}
		}
		value = Math.Clamp(value, -frame.Width, frame.Width);
		int errorPixels = (int)Math.Round(value);
		return new SliderObservation(IsDetected: true, value / (double)Math.Max(1, frame.Width))
		{
			TargetDetected = true,
			TargetX = num,
			TargetY = targetY,
			PlayerStartX = aiDetectionBox.X,
			PlayerEndX = aiDetectionBox.X + aiDetectionBox.Width,
			PlayerCenterX = num2,
			ErrorPixels = errorPixels,
			ProgressBar = progressBar,
			DetectionBoxes = array,
			PursuitCount = array2.Length,
			AvoidanceCount = array3.Length,
			UsedCustomSteeringFormula = flag
		};
	}

	private static RoleInfluence CalculateRoleInfluence(IReadOnlyList<AiDetectionBox> boxes, IReadOnlyDictionary<int, DetectionClassDefinition> definitions, AiDetectionBox player, int frameWidth, int frameHeight, bool isAvoidance, double? targetCenterX = null)
	{
		double num = (double)player.X + (double)player.Width / 2.0;
		double num2 = 0.0;
		double num3 = 0.0;
		foreach (AiDetectionBox box in boxes)
		{
			DetectionClassDefinition detectionClassDefinition = definitions[box.ClassId];
			double num4 = (double)box.X + (double)box.Width / 2.0;
			double value = (double)box.Y + (double)box.Height / 2.0;
			double num5 = num4 - num;
			if (isAvoidance && targetCenterX.HasValue)
			{
				double valueOrDefault = targetCenterX.GetValueOrDefault();
				double value2 = valueOrDefault - num;
				if (Math.Sign(num5) != Math.Sign(value2) || !(Math.Abs(num5) <= Math.Abs(value2)))
				{
					continue;
				}
			}
			double num6 = Math.Abs(num5);
			double num7 = num6 / (double)Math.Max(1, frameWidth);
			double value3 = (double)Math.Max(0, Math.Min(box.X + box.Width, player.X + player.Width) - Math.Max(box.X, player.X)) / (double)Math.Max(1, Math.Min(box.Width, player.Width));
			double num8 = detectionClassDefinition.Weight * box.Confidence / Math.Max(0.05, num7);
			double val = num8;
			if (!string.IsNullOrWhiteSpace(detectionClassDefinition.InfluenceFormula))
			{
				try
				{
					val = SafeNumericExpression.Evaluate(detectionClassDefinition.InfluenceFormula, new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
					{
						["x"] = box.X,
						["y"] = box.Y,
						["width"] = box.Width,
						["height"] = box.Height,
						["center_x"] = num4,
						["center_y"] = value,
						["confidence"] = box.Confidence,
						["class_id"] = box.ClassId,
						["frame_width"] = frameWidth,
						["frame_height"] = frameHeight,
						["player_x"] = num,
						["player_width"] = player.Width,
						["distance"] = num6,
						["distance_norm"] = num7,
						["overlap"] = value3,
						["weight"] = detectionClassDefinition.Weight,
						["direction"] = Math.Sign(num5)
					});
				}
				catch (InvalidOperationException)
				{
					val = num8;
				}
			}
			val = Math.Clamp(Math.Max(0.0, val), 0.0, 1000.0);
			num2 += (isAvoidance ? (0.0 - num5) : num5) * val;
			num3 += val;
		}
		if (!(num3 <= 0.0))
		{
			return new RoleInfluence(num2 / num3, num3);
		}
		return new RoleInfluence(0.0, 0.0);
	}

	private static AiDetectionBox[] BuildLegacyBoxes(AiDetectionResult detections)
	{
		return (from box in new AiDetectionBox?[3] { detections.FishTarget, detections.PlayerBar, detections.ProgressBar }
			where box.HasValue
			select box.Value).Distinct().ToArray();
	}

	private unsafe static bool BoxMatchesColorHint(PixelFrame frame, AiDetectionBox box, ColorHint hint)
	{
		int num = Math.Max(0, box.X);
		int num2 = Math.Max(0, box.Y);
		int num3 = Math.Min(frame.Width, box.X + box.Width);
		int num4 = Math.Min(frame.Height, box.Y + box.Height);
		if (num3 <= num || num4 <= num2)
		{
			return false;
		}
		int num5 = 0;
		int num6 = Math.Max(3, (num3 - num) * (num4 - num2) / 200);
		for (int i = num2; i < num4; i++)
		{
			byte* ptr = frame.Pixels + i * frame.Stride;
			for (int j = num; j < num3; j++)
			{
				byte* ptr2 = ptr + j * 4;
				if (Math.Abs(ptr2[2] - hint.R) <= hint.Tolerance && Math.Abs(ptr2[1] - hint.G) <= hint.Tolerance && Math.Abs(*ptr2 - hint.B) <= hint.Tolerance)
				{
					num5++;
					if (num5 >= num6)
					{
						return true;
					}
				}
			}
		}
		return false;
	}
}

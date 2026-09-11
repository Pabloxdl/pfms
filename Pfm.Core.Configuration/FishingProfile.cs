using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;

namespace Pfm.Core.Configuration;

public sealed class FishingProfile
{
	public string MechanicId { get; set; } = "dual-region";

	public bool UseProfileEngine
	{
		get
		{
			return Mode != ProfileMode.CfgBuilder;
		}
		set
		{
			if (!value)
			{
				Mode = ProfileMode.CfgBuilder;
			}
			else if (Mode == ProfileMode.CfgBuilder)
			{
				Mode = ProfileMode.PdPixel;
			}
		}
	}

	public bool UseAiDetectionMode
	{
		get
		{
			return Mode == ProfileMode.YoloAi;
		}
		set
		{
			if (value)
			{
				Mode = ProfileMode.YoloAi;
			}
			else if (Mode == ProfileMode.YoloAi)
			{
				Mode = ProfileMode.PdPixel;
			}
		}
	}

	public ProfileMode Mode { get; set; } = ProfileMode.YoloAi;

	public string ModelFilePath { get; set; } = string.Empty;

	public double ConfidenceThreshold { get; set; } = 0.5;

	public int TargetClassId { get; set; }

	public int PlayerBarClassId { get; set; } = 1;

	public int ProgressClassId { get; set; } = -1;

	public List<DetectionClassDefinition> CustomClasses { get; set; } = new List<DetectionClassDefinition>();

	public string SteeringFormula { get; set; } = string.Empty;

	public FishingMode FishingMode { get; set; }

	public string TriggerFormula { get; set; } = string.Empty;

	public int ClickCooldownMs { get; set; } = 250;

	public int ClickHoldDurationMs { get; set; } = 60;

	public int CastHoldTimeMs { get; set; } = 600;

	public int BiteTimeoutMs { get; set; } = 15000;

	public int RecastDelayMs { get; set; } = 1500;

	public RodConfig Rod { get; set; } = new RodConfig();

	public QuickEventConfig? QuickEvent { get; set; }

	public Dictionary<string, JsonNode?> Parameters { get; init; } = new Dictionary<string, JsonNode>(StringComparer.OrdinalIgnoreCase);

	public static IReadOnlyList<string> ClassFormulaVariables { get; } = new _003C_003Ez__ReadOnlyArray<string>(new string[17]
	{
		"x", "y", "width", "height", "center_x", "center_y", "confidence", "class_id", "frame_width", "frame_height",
		"player_x", "player_width", "distance", "distance_norm", "overlap", "weight", "direction"
	});

	public static IReadOnlyList<string> SteeringFormulaVariables { get; } = new _003C_003Ez__ReadOnlyArray<string>(new string[8] { "pursuit_error", "avoidance_error", "pursuit_weight", "avoidance_weight", "legacy_error", "player_x", "frame_width", "frame_height" });

	public static IReadOnlyList<string> TriggerFormulaVariables { get; } = new _003C_003Ez__ReadOnlyArray<string>(new string[8] { "overlap_max", "overlap_sum", "pursue_count", "control_count", "player_x", "player_width", "frame_width", "frame_height" });

	public void Validate()
	{
		Rod.Validate();
		if (CastHoldTimeMs < 0 || BiteTimeoutMs <= 0 || RecastDelayMs < 0)
		{
			throw new InvalidOperationException("Fishing lifecycle timing values are invalid.");
		}
		if (string.IsNullOrWhiteSpace(ModelFilePath) || !File.Exists(ModelFilePath))
		{
			throw new InvalidOperationException("Select an existing YOLO ONNX model.");
		}
		string extension = Path.GetExtension(ModelFilePath);
		if (!extension.Equals(".onnx", StringComparison.OrdinalIgnoreCase) && !extension.Equals(".pt", StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException("PFMS runtime requires a YOLO .onnx or .pt model.");
		}
		bool flag = !double.IsFinite(ConfidenceThreshold);
		if (!flag)
		{
			double confidenceThreshold = ConfidenceThreshold;
			bool flag2 = ((confidenceThreshold <= 0.0 || confidenceThreshold > 1.0) ? true : false);
			flag = flag2;
		}
		if (flag)
		{
			throw new InvalidOperationException("AI confidence threshold must be greater than 0 and at most 1.");
		}
		ValidateBehaviorRules();
		ValidateQuickEvent();
	}

	public void ValidateQuickEvent()
	{
		QuickEventConfig quickEvent = QuickEvent;
		if (quickEvent == null || !quickEvent.Enabled)
		{
			QuickEvent = null;
			return;
		}
		ScreenRegion signRegion = QuickEvent.SignRegion;
		if (signRegion == null || !signRegion.IsEnabled || QuickEvent.SignClassIds.Count == 0)
		{
			throw new InvalidOperationException("Quick Event requires a sign region and at least one sign class ID.");
		}
		QuickEvent.SignRegion.Validate("Quick Event sign region");
		if (QuickEvent.MemoHoldMs <= 0)
		{
			throw new InvalidOperationException("Quick Event memo hold time must be positive.");
		}
		if (QuickEvent.SelectionTimeoutMs <= 0)
		{
			throw new InvalidOperationException("Quick Event selection timeout must be positive.");
		}
		if (!(QuickEvent.SuccessThresholdPixels <= 0.0))
		{
			return;
		}
		throw new InvalidOperationException("Quick Event success threshold must be positive.");
	}

	public void ValidateBehaviorRules()
	{
		EnsureDefaultClasses();
		if ((from item in CustomClasses
			group item by item.Id).Any((IGrouping<int, DetectionClassDefinition> group) => group.Count() > 1))
		{
			throw new InvalidOperationException("Model class IDs must be unique.");
		}
		if (CustomClasses.Count((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Control) != 1)
		{
			throw new InvalidOperationException("Exactly one model class must use the Control behavior.");
		}
		if (!CustomClasses.Any((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Pursue))
		{
			throw new InvalidOperationException("At least one model class must use the Pursue behavior.");
		}
		foreach (DetectionClassDefinition customClass in CustomClasses)
		{
			if (customClass.Id < 0)
			{
				throw new InvalidOperationException("Class '" + customClass.Name + "' must have a non-negative ID.");
			}
			if (!Enum.IsDefined(customClass.Behavior) || customClass.Behavior == DetectionBehavior.Unassigned)
			{
				throw new InvalidOperationException("Class '" + customClass.Name + "' has an invalid behavior.");
			}
			if (!double.IsFinite(customClass.Weight) || customClass.Weight < 0.0)
			{
				throw new InvalidOperationException("Class '" + customClass.Name + "' has an invalid weight.");
			}
			if (!string.IsNullOrWhiteSpace(customClass.InfluenceFormula))
			{
				try
				{
					SafeNumericExpression.Validate(customClass.InfluenceFormula, ClassFormulaVariables);
				}
				catch (InvalidOperationException ex)
				{
					throw new InvalidOperationException("Class '" + customClass.Name + "' formula is invalid: " + ex.Message);
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(SteeringFormula))
		{
			try
			{
				SafeNumericExpression.Validate(SteeringFormula, SteeringFormulaVariables);
			}
			catch (InvalidOperationException ex2)
			{
				throw new InvalidOperationException("Steering formula is invalid: " + ex2.Message);
			}
		}
		if (!string.IsNullOrWhiteSpace(TriggerFormula))
		{
			try
			{
				SafeNumericExpression.Validate(TriggerFormula, TriggerFormulaVariables);
			}
			catch (InvalidOperationException ex3)
			{
				throw new InvalidOperationException("Trigger formula is invalid: " + ex3.Message);
			}
		}
	}

	public void EnsureDefaultClasses()
	{
		if (CustomClasses == null)
		{
			List<DetectionClassDefinition> list = (CustomClasses = new List<DetectionClassDefinition>());
		}
		if (!CustomClasses.Any((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Pursue) && !CustomClasses.Any((DetectionClassDefinition item) => item.Id == TargetClassId))
		{
			CustomClasses.Add(new DetectionClassDefinition
			{
				Id = TargetClassId,
				Name = "FishTarget",
				Behavior = DetectionBehavior.Pursue
			});
		}
		if (!CustomClasses.Any((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Control) && !CustomClasses.Any((DetectionClassDefinition item) => item.Id == PlayerBarClassId))
		{
			CustomClasses.Add(new DetectionClassDefinition
			{
				Id = PlayerBarClassId,
				Name = "PlayerBar",
				Behavior = DetectionBehavior.Control
			});
		}
		if (!CustomClasses.Any((DetectionClassDefinition item) => item.Id == 2))
		{
			CustomClasses.Add(new DetectionClassDefinition
			{
				Id = 2,
				Name = "ProgressBar",
				Behavior = ((ProgressClassId != 2) ? DetectionBehavior.Observe : DetectionBehavior.Progress)
			});
		}
		foreach (DetectionClassDefinition customClass in CustomClasses)
		{
			customClass.Name = (string.IsNullOrWhiteSpace(customClass.Name) ? $"Class {customClass.Id}" : customClass.Name.Trim());
			if (customClass.Behavior == DetectionBehavior.Unassigned)
			{
				customClass.Behavior = ((customClass.Id == PlayerBarClassId) ? DetectionBehavior.Control : ((customClass.Id == TargetClassId) ? DetectionBehavior.Pursue : ((ProgressClassId < 0 || customClass.Id != ProgressClassId) ? DetectionBehavior.Observe : DetectionBehavior.Progress)));
			}
		}
		DetectionClassDefinition detectionClassDefinition = CustomClasses.FirstOrDefault((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Pursue);
		DetectionClassDefinition detectionClassDefinition2 = CustomClasses.FirstOrDefault((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Control);
		if (detectionClassDefinition != null)
		{
			TargetClassId = detectionClassDefinition.Id;
		}
		if (detectionClassDefinition2 != null)
		{
			PlayerBarClassId = detectionClassDefinition2.Id;
		}
		ProgressClassId = CustomClasses.FirstOrDefault((DetectionClassDefinition item) => item.Behavior == DetectionBehavior.Progress)?.Id ?? (-1);
	}
}

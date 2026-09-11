using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Pfm.Core.Macros;

namespace Pfm.Services.Macros;

internal static class MacroPipelineValidator
{
	public static MacroAction[] ValidateAndSnapshot(IReadOnlyList<MacroAction> actions)
	{
		ArgumentNullException.ThrowIfNull(actions, "actions");
		if (actions.Count == 0)
		{
			throw new InvalidOperationException("The macro pipeline does not contain any actions.");
		}
		MacroAction[] array = (JsonSerializer.Deserialize<List<MacroAction>>(JsonSerializer.Serialize(actions)) ?? throw new InvalidOperationException("The macro pipeline could not be copied.")).OrderBy((MacroAction macroAction3) => macroAction3.ExecutionOrder).ToArray();
		for (int num = 0; num < array.Length; num++)
		{
			MacroAction macroAction = array[num] ?? throw new InvalidOperationException($"Action {num} is null.");
			if (macroAction.ExecutionOrder != num)
			{
				throw new InvalidOperationException("ExecutionOrder values must be unique and contiguous, starting at zero.");
			}
			ValidateTarget(macroAction.OnSuccessTarget, array.Length, macroAction.ExecutionOrder, "OnSuccessTarget");
			ValidateTarget(macroAction.OnFailTarget, array.Length, macroAction.ExecutionOrder, "OnFailTarget");
			MacroAction macroAction2 = macroAction;
			if (!(macroAction2 is PixelColorCheckAction pixelColorCheckAction))
			{
				if (!(macroAction2 is TemplateImageMatchAction action))
				{
					if (!(macroAction2 is KeyPressAction keyPressAction))
					{
						if (!(macroAction2 is MouseButtonAction mouseButtonAction))
						{
							if (!(macroAction2 is DelayAction delayAction))
							{
								if (!(macroAction2 is EndAction))
								{
									throw new InvalidOperationException("Action type '" + macroAction.GetType().Name + "' is not supported by this runner.");
								}
							}
							else if (delayAction.DurationMs < 0)
							{
								throw new InvalidOperationException($"Delay action {num} has a negative duration.");
							}
							continue;
						}
						if (mouseButtonAction.ConditionRequirement)
						{
							throw new InvalidOperationException($"Mouse action {num} cannot require a pixel condition.");
						}
						MouseButtonAction mouseButtonAction2 = mouseButtonAction;
						if (mouseButtonAction2.DelayMs < 0 || mouseButtonAction2.HoldMs < 0)
						{
							throw new InvalidOperationException($"Mouse action {num} has negative timing values.");
						}
					}
					else
					{
						if (keyPressAction.ConditionRequirement)
						{
							throw new InvalidOperationException($"Key action {num} cannot require a pixel condition. Add a PixelColorCheckAction before it.");
						}
						KeyPressAction keyPressAction2 = keyPressAction;
						if (keyPressAction2.DelayMs < 0 || keyPressAction2.HoldMs < 0)
						{
							throw new InvalidOperationException($"Key action {num} has negative timing values.");
						}
					}
				}
				else
				{
					ValidateTemplateAction(action);
				}
			}
			else
			{
				ValidatePixelAction(pixelColorCheckAction);
				if (pixelColorCheckAction is PixelColorClickAction pixelColorClickAction && (pixelColorClickAction.DelayMs < 0 || pixelColorClickAction.HoldMs < 0))
				{
					throw new InvalidOperationException($"Pixel click action {num} has negative timing values.");
				}
			}
		}
		return array;
	}

	private static void ValidatePixelAction(PixelColorCheckAction action)
	{
		action.Region.Validate($"Pixel action {action.ExecutionOrder} ROI");
		if (!action.Region.IsEnabled)
		{
			throw new InvalidOperationException($"Pixel action {action.ExecutionOrder} ROI must be enabled.");
		}
		if (!action.ConditionRequirement)
		{
			throw new InvalidOperationException($"Pixel action {action.ExecutionOrder} must require a condition.");
		}
		double requiredMatchRatio = action.RequiredMatchRatio;
		bool flag = ((requiredMatchRatio < 0.0 || requiredMatchRatio > 1.0) ? true : false);
		if (flag || action.MinimumMatchingPixels <= 0 || action.SampleStride <= 0)
		{
			throw new InvalidOperationException($"Pixel action {action.ExecutionOrder} has invalid matching thresholds.");
		}
	}

	private static void ValidateTemplateAction(TemplateImageMatchAction action)
	{
		action.Region.Validate($"Template action {action.ExecutionOrder} ROI");
		if (!action.Region.IsEnabled || string.IsNullOrWhiteSpace(action.TemplatePath))
		{
			throw new InvalidOperationException($"Template action {action.ExecutionOrder} requires an enabled ROI and an imported image.");
		}
		double similarityThreshold = action.SimilarityThreshold;
		bool flag = ((similarityThreshold <= 0.0 || similarityThreshold > 1.0) ? true : false);
		if (flag || action.SearchStride <= 0 || action.SampleStride <= 0 || action.ClickDelayMs < 0 || action.ClickHoldMs < 0)
		{
			throw new InvalidOperationException($"Template action {action.ExecutionOrder} has invalid matching or timing settings.");
		}
	}

	private static void ValidateTarget(int? target, int actionCount, int actionIndex, string propertyName)
	{
		if ((target.HasValue && target.GetValueOrDefault() < 0) || target >= actionCount)
		{
			throw new InvalidOperationException($"Action {actionIndex} {propertyName} points outside the pipeline.");
		}
	}
}

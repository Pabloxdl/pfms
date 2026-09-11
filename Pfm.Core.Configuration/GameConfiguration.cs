using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Pfm.Core.Configuration;

public sealed class GameConfiguration
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public string Name { get; set; } = "Untitled configuration";

	public string Description { get; set; } = string.Empty;

	public string CoverImagePath { get; set; } = string.Empty;

	public bool IsEnabled { get; set; }

	public DateTimeOffset UpdatedAtUtc { get; set; } = DateTimeOffset.UtcNow;

	public List<MacroDefinition> Macros { get; init; } = new List<MacroDefinition>();

	public FishingProfile Fishing { get; set; } = new FishingProfile();

	public List<UiTemplateAsset> UiTemplates { get; init; } = new List<UiTemplateAsset>();

	public Dictionary<string, JsonNode?> CustomParameters { get; init; } = new Dictionary<string, JsonNode>(StringComparer.OrdinalIgnoreCase);

	public static GameConfiguration CreateStarterProfile()
	{
		return CreateForMode(ProfileMode.YoloAi);
	}

	public static GameConfiguration CreateBlankProfile()
	{
		return CreateForMode(ProfileMode.YoloAi);
	}

	public static GameConfiguration CreateForMode(ProfileMode mode)
	{
		mode = ProfileMode.YoloAi;
		GameConfiguration gameConfiguration = new GameConfiguration();
		GameConfiguration gameConfiguration2 = gameConfiguration;
		gameConfiguration2.Name = mode switch
		{
			ProfileMode.PdPixel => "New PD pixel configuration", 
			ProfileMode.YoloAi => "New YOLO AI configuration", 
			_ => "New CFG configuration", 
		};
		GameConfiguration gameConfiguration3 = gameConfiguration;
		gameConfiguration3.Description = mode switch
		{
			ProfileMode.PdPixel => "State-machine PD engine with pixel color tracking.", 
			ProfileMode.YoloAi => "YOLO AI object detection with PD physics control.", 
			_ => "Configure macros and custom parameters for this scenario.", 
		};
		gameConfiguration.Fishing.Mode = mode;
		gameConfiguration.Fishing.TargetClassId = 0;
		gameConfiguration.Fishing.PlayerBarClassId = 1;
		gameConfiguration.Fishing.ProgressClassId = 2;
		gameConfiguration.Fishing.EnsureDefaultClasses();
		return gameConfiguration;
	}
}

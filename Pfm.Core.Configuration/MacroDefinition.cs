using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Pfm.Core.Macros;

namespace Pfm.Core.Configuration;

public sealed class MacroDefinition
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public string Name { get; set; } = "Untitled macro";

	public bool IsEnabled { get; set; } = true;

	public MacroTrigger Trigger { get; set; } = new MacroTrigger();

	public List<MacroAction> Actions { get; init; } = new List<MacroAction>();

	[JsonPropertyName("Steps")]
	public List<MacroStep> LegacySteps { get; init; } = new List<MacroStep>();

	public Dictionary<string, JsonNode?> Parameters { get; init; } = new Dictionary<string, JsonNode>(StringComparer.OrdinalIgnoreCase);
}

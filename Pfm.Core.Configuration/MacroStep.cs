using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Pfm.Core.Configuration;

public sealed class MacroStep
{
	public string Action { get; set; } = string.Empty;

	public Dictionary<string, JsonNode?> Parameters { get; init; } = new Dictionary<string, JsonNode>(StringComparer.OrdinalIgnoreCase);
}

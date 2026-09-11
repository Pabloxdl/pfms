using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Pfm.Core.Configuration;

namespace Pfm.Core.Fishing;

public sealed class FishingProcessContext
{
	public required string ConfigurationId { get; init; }

	public required FishingProfile Profile { get; init; }

	public RodConfig Rod => Profile.Rod;

	public required IReadOnlyDictionary<string, JsonNode?> Parameters { get; init; }

	public required IServiceProvider Services { get; init; }
}

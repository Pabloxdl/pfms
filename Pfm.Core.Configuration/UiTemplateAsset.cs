using System;

namespace Pfm.Core.Configuration;

public sealed class UiTemplateAsset
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public string Name { get; set; } = "Untitled UI template";

	public string FilePath { get; set; } = string.Empty;

	public double SimilarityThreshold { get; set; } = 0.85;
}

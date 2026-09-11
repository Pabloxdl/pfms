using System;
using Pfm.Core.Configuration;

namespace Pfm.Core.Macros;

public sealed class TemplateImageMatchAction : MacroAction
{
	public Guid TemplateId { get; set; }

	public string TemplatePath { get; set; } = string.Empty;

	public ScreenRegion Region { get; set; } = new ScreenRegion();

	public double SimilarityThreshold { get; set; } = 0.85;

	public byte ColorTolerance { get; set; } = 25;

	public int SearchStride { get; set; } = 4;

	public int SampleStride { get; set; } = 4;

	public bool ClickOnMatch { get; set; } = true;

	public int ClickDelayMs { get; set; }

	public int ClickHoldMs { get; set; } = 18;
}

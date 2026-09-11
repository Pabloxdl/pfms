using System;
using System.Text.Json.Serialization;

namespace Pfm.Core.Macros;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(PixelColorCheckAction), "pixelColorCheck")]
[JsonDerivedType(typeof(PixelColorClickAction), "pixelColorClick")]
[JsonDerivedType(typeof(TemplateImageMatchAction), "templateImageMatch")]
[JsonDerivedType(typeof(KeyPressAction), "keyPress")]
[JsonDerivedType(typeof(MouseButtonAction), "mouseButton")]
[JsonDerivedType(typeof(DelayAction), "delay")]
[JsonDerivedType(typeof(EndAction), "end")]
public abstract class MacroAction
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public string Name { get; set; } = string.Empty;

	public MacroPhase Phase { get; set; } = MacroPhase.Custom;

	public int ExecutionOrder { get; set; }

	public bool ConditionRequirement { get; set; }

	public int? OnSuccessTarget { get; set; }

	public int? OnFailTarget { get; set; }
}

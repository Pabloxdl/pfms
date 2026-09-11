namespace Pfm.Services.Macros;

internal readonly record struct TemplateMatch(bool IsMatch, int X, int Y, double Similarity)
{
	public static TemplateMatch NotFound => new TemplateMatch(IsMatch: false, 0, 0, 0.0);
}

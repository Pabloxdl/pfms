namespace Pfm.Services.Macros;

internal readonly record struct PixelMatch(bool IsMatch, int X, int Y)
{
	public static PixelMatch NotFound => new PixelMatch(IsMatch: false, 0, 0);
}

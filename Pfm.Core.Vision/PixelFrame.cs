using System;
using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public unsafe readonly struct PixelFrame(byte* pixels, int width, int height, int stride)
{
	public unsafe byte* Pixels { get; } = pixels;

	public int Width { get; } = width;

	public int Height { get; } = height;

	public int Stride { get; } = stride;

	public unsafe bool Matches(int x, int y, PixelColor expected, byte tolerance)
	{
		byte* ptr = Pixels + y * Stride + x * 4;
		if (Math.Abs(ptr[2] - expected.R) <= tolerance && Math.Abs(ptr[1] - expected.G) <= tolerance)
		{
			return Math.Abs(*ptr - expected.B) <= tolerance;
		}
		return false;
	}

	public unsafe byte GetLuma(int x, int y)
	{
		byte* ptr = Pixels + y * Stride + x * 4;
		return (byte)(ptr[2] * 77 + ptr[1] * 150 + *ptr * 29 >> 8);
	}
}

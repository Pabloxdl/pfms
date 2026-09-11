using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Pfm.Core.Macros;
using Pfm.Core.Vision;

namespace Pfm.Services.Macros;

internal sealed class TemplateImageMatcher
{
	private sealed record TemplatePixels(int Width, int Height, int Stride, byte[] Bgra);

	private readonly Dictionary<string, TemplatePixels> _templates = new Dictionary<string, TemplatePixels>(StringComparer.OrdinalIgnoreCase);

	public TemplateMatch Find(in PixelFrame frame, TemplateImageMatchAction action)
	{
		TemplatePixels template = GetTemplate(action.TemplatePath);
		if (template.Width > frame.Width || template.Height > frame.Height)
		{
			return TemplateMatch.NotFound;
		}
		double num = 0.0;
		int num2 = 0;
		int num3 = 0;
		int num4 = Math.Max(1, action.SearchStride);
		int sampleStride = Math.Max(1, action.SampleStride);
		for (int i = 0; i <= frame.Height - template.Height; i += num4)
		{
			for (int j = 0; j <= frame.Width - template.Width; j += num4)
			{
				double num5 = CalculateSimilarity(in frame, template, j, i, sampleStride, action.SimilarityThreshold, action.ColorTolerance);
				if (!(num5 <= num))
				{
					num = num5;
					num2 = j;
					num3 = i;
				}
			}
		}
		if (!(num >= action.SimilarityThreshold))
		{
			return TemplateMatch.NotFound;
		}
		return new TemplateMatch(IsMatch: true, num2 + template.Width / 2, num3 + template.Height / 2, num);
	}

	private unsafe static double CalculateSimilarity(in PixelFrame frame, TemplatePixels template, int offsetX, int offsetY, int sampleStride, double minimumSimilarity, byte colorTolerance)
	{
		int num = 0;
		int num2 = ((template.Width - 1) / sampleStride + 1) * ((template.Height - 1) / sampleStride + 1);
		int num3 = (int)Math.Ceiling(minimumSimilarity * (double)num2);
		int num4 = 0;
		for (int i = 0; i < template.Height; i += sampleStride)
		{
			for (int j = 0; j < template.Width; j += sampleStride)
			{
				byte* ptr = frame.Pixels + (offsetY + i) * frame.Stride + (offsetX + j) * 4;
				int num5 = i * template.Stride + j * 4;
				if (Math.Abs(ptr[2] - template.Bgra[num5 + 2]) <= colorTolerance && Math.Abs(ptr[1] - template.Bgra[num5 + 1]) <= colorTolerance && Math.Abs(*ptr - template.Bgra[num5]) <= colorTolerance)
				{
					num4++;
				}
				num++;
				if (num4 + (num2 - num) < num3)
				{
					return 0.0;
				}
			}
		}
		if (num != 0)
		{
			return (double)num4 / (double)num;
		}
		return 0.0;
	}

	private TemplatePixels GetTemplate(string path)
	{
		if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
		{
			throw new FileNotFoundException("The imported UI template image is unavailable.", path);
		}
		if (_templates.TryGetValue(path, out TemplatePixels value))
		{
			return value;
		}
		using Bitmap bitmap = new Bitmap(path);
		using Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(bitmap2))
		{
			graphics.DrawImageUnscaled(bitmap, 0, 0);
		}
		Rectangle rect = new Rectangle(0, 0, bitmap2.Width, bitmap2.Height);
		BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		try
		{
			byte[] array = new byte[Math.Abs(bitmapData.Stride) * bitmapData.Height];
			Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			value = new TemplatePixels(bitmap2.Width, bitmap2.Height, Math.Abs(bitmapData.Stride), array);
			_templates.Add(path, value);
			return value;
		}
		finally
		{
			bitmap2.UnlockBits(bitmapData);
		}
	}
}

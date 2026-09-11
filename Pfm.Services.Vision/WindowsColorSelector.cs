using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class WindowsColorSelector : IColorSelector
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct ChooseColor
	{
		public int Size;

		public nint OwnerWindow;

		public nint Instance;

		public uint ResultColor;

		public nint CustomColors;

		public uint Flags;

		public nint CustomData;

		public nint Hook;

		public nint TemplateName;
	}

	private static class NativeMethods
	{
		[DllImport("comdlg32.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ChooseColor(ref ChooseColor chooseColor);
	}

	private const uint ColorRgbInit = 1u;

	private const uint ColorFullOpen = 2u;

	public Task<PixelColor?> SelectAsync(PixelColor initialColor, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (!OperatingSystem.IsWindows())
		{
			return Task.FromResult<PixelColor>(null);
		}
		GCHandle gCHandle = GCHandle.Alloc(new uint[16], GCHandleType.Pinned);
		try
		{
			ChooseColor chooseColor = new ChooseColor
			{
				Size = Marshal.SizeOf<ChooseColor>(),
				ResultColor = ToColorRef(initialColor),
				CustomColors = gCHandle.AddrOfPinnedObject(),
				Flags = 3u
			};
			if (!NativeMethods.ChooseColor(ref chooseColor))
			{
				return Task.FromResult<PixelColor>(null);
			}
			return Task.FromResult(FromColorRef(chooseColor.ResultColor));
		}
		finally
		{
			gCHandle.Free();
		}
	}

	private static uint ToColorRef(PixelColor color)
	{
		return (uint)(color.R | (color.G << 8) | (color.B << 16));
	}

	private static PixelColor FromColorRef(uint color)
	{
		return new PixelColor((byte)(color & 0xFF), (byte)((color >> 8) & 0xFF), (byte)((color >> 16) & 0xFF));
	}
}

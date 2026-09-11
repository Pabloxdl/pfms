using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class GdiScreenCaptureFactory : IScreenCaptureFactory
{
	private sealed class GdiScreenCaptureSession : IScreenCaptureSession, IDisposable
	{
		private const int BiRgb = 0;

		private const uint DibRgbColors = 0u;

		private const uint SourceCopy = 13369376u;

		private readonly int _x;

		private readonly int _y;

		private readonly int _width;

		private readonly int _height;

		private readonly nint _screenDc;

		private readonly nint _memoryDc;

		private readonly nint _bitmap;

		private readonly nint _previousObject;

		private unsafe readonly byte* _pixels;

		private bool _disposed;

		public unsafe GdiScreenCaptureSession(ScreenRegion region)
		{
			_x = region.X;
			_y = region.Y;
			_width = region.Width;
			_height = region.Height;
			_screenDc = NativeMethods.GetDC(0);
			_memoryDc = NativeMethods.CreateCompatibleDC(_screenDc);
			BitmapInfo bitmapInfo = new BitmapInfo
			{
				Header = new BitmapInfoHeader
				{
					Size = (uint)Marshal.SizeOf<BitmapInfoHeader>(),
					Width = _width,
					Height = -_height,
					Planes = 1,
					BitCount = 32,
					Compression = 0
				}
			};
			_bitmap = NativeMethods.CreateDIBSection(_screenDc, ref bitmapInfo, 0u, out var bits, 0, 0u);
			if (_screenDc == 0 || _memoryDc == 0 || _bitmap == 0 || bits == 0)
			{
				Dispose();
				throw new Win32Exception(Marshal.GetLastWin32Error(), "Unable to initialize the GDI screen capture session.");
			}
			_pixels = (byte*)bits;
			_previousObject = NativeMethods.SelectObject(_memoryDc, _bitmap);
			if (_previousObject == 0 || _previousObject == -1)
			{
				Dispose();
				throw new Win32Exception(Marshal.GetLastWin32Error(), "Unable to select the capture bitmap into the GDI device context.");
			}
		}

		public unsafe PixelFrame Capture()
		{
			ObjectDisposedException.ThrowIf(_disposed, this);
			if (!NativeMethods.BitBlt(_memoryDc, 0, 0, _width, _height, _screenDc, _x, _y, 13369376u))
			{
				throw new Win32Exception(Marshal.GetLastWin32Error(), "Screen region capture failed.");
			}
			return new PixelFrame(_pixels, _width, _height, _width * 4);
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				if (_previousObject != 0 && _previousObject != -1 && _memoryDc != 0)
				{
					NativeMethods.SelectObject(_memoryDc, _previousObject);
				}
				if (_bitmap != 0)
				{
					NativeMethods.DeleteObject(_bitmap);
				}
				if (_memoryDc != 0)
				{
					NativeMethods.DeleteDC(_memoryDc);
				}
				if (_screenDc != 0)
				{
					NativeMethods.ReleaseDC(0, _screenDc);
				}
			}
		}
	}

	private struct BitmapInfoHeader
	{
		public uint Size;

		public int Width;

		public int Height;

		public ushort Planes;

		public ushort BitCount;

		public int Compression;

		public uint SizeImage;

		public int XPelsPerMeter;

		public int YPelsPerMeter;

		public uint ColorsUsed;

		public uint ColorsImportant;
	}

	private struct BitmapInfo
	{
		public BitmapInfoHeader Header;

		public uint Colors;
	}

	private static class NativeMethods
	{
		[DllImport("user32.dll", SetLastError = true)]
		public static extern nint GetDC(nint windowHandle);

		[DllImport("user32.dll")]
		public static extern int ReleaseDC(nint windowHandle, nint deviceContext);

		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern nint CreateCompatibleDC(nint deviceContext);

		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern nint CreateDIBSection(nint deviceContext, ref BitmapInfo bitmapInfo, uint usage, out nint bits, nint section, uint offset);

		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern nint SelectObject(nint deviceContext, nint graphicsObject);

		[DllImport("gdi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BitBlt(nint destination, int x, int y, int width, int height, nint source, int sourceX, int sourceY, uint operation);

		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject(nint graphicsObject);

		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteDC(nint deviceContext);
	}

	public IScreenCaptureSession Create(ScreenRegion region)
	{
		region.Validate("Screen region");
		return new GdiScreenCaptureSession(region);
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using Pfm.Core.Hotkeys;

namespace Pfm.Services.Hotkeys;

public sealed class WindowsGlobalHotkeyService : IGlobalHotkeyService, IDisposable
{
	private struct NativeMessage
	{
		public nint WindowHandle;

		public uint Message;

		public nint WParam;

		public nint LParam;

		public uint Time;

		public NativePoint Point;

		public uint Private;
	}

	private struct NativePoint
	{
		public int X;

		public int Y;
	}

	private static class NativeMethods
	{
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RegisterHotKey(nint windowHandle, int id, uint modifiers, uint virtualKey);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnregisterHotKey(nint windowHandle, int id);

		[DllImport("user32.dll")]
		public static extern int GetMessage(out NativeMessage message, nint windowHandle, uint minimumFilter, uint maximumFilter);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PeekMessage(out NativeMessage message, nint windowHandle, uint minimumFilter, uint maximumFilter, uint removeMessage);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PostThreadMessage(uint threadId, uint message, nint wParam, nint lParam);

		[DllImport("kernel32.dll")]
		public static extern uint GetCurrentThreadId();
	}

	private const int StartHotkeyId = 1;

	private const int StopHotkeyId = 2;

	private const uint ModifierNoRepeat = 16384u;

	private const uint WmHotkey = 786u;

	private const uint WmQuit = 18u;

	private readonly object _stateLock = new object();

	private Thread? _messageThread;

	private uint _messageThreadId;

	private ManualResetEventSlim? _startupSignal;

	private Exception? _startupError;

	private GlobalHotkeyBinding? _startBinding;

	private GlobalHotkeyBinding? _stopBinding;

	private bool _disposed;

	public event EventHandler<GlobalHotkeyPressedEventArgs>? HotkeyPressed;

	public void Start(GlobalHotkeyBinding startBinding, GlobalHotkeyBinding stopBinding)
	{
		lock (_stateLock)
		{
			ObjectDisposedException.ThrowIf(_disposed, this);
			if (_messageThread != null)
			{
				throw new InvalidOperationException("Global hotkeys are already running.");
			}
			_startBinding = startBinding;
			_stopBinding = stopBinding;
			_startupSignal = new ManualResetEventSlim();
			_startupError = null;
			_messageThread = new Thread(RunMessageLoop)
			{
				IsBackground = true,
				Name = "PFMS Global Hotkeys"
			};
			_messageThread.Start();
		}
		_startupSignal.Wait();
		if (_startupError != null)
		{
			Dispose();
			throw new InvalidOperationException("Unable to register the PFMS global hotkeys.", _startupError);
		}
	}

	public void Dispose()
	{
		Thread messageThread;
		uint messageThreadId;
		lock (_stateLock)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			messageThread = _messageThread;
			messageThreadId = _messageThreadId;
		}
		if (messageThreadId != 0)
		{
			NativeMethods.PostThreadMessage(messageThreadId, 18u, 0, 0);
		}
		if (messageThread != null && messageThread != Thread.CurrentThread)
		{
			messageThread.Join(TimeSpan.FromSeconds(2L));
		}
		_startupSignal?.Dispose();
	}

	private void RunMessageLoop()
	{
		bool flag = false;
		bool flag2 = false;
		try
		{
			_messageThreadId = NativeMethods.GetCurrentThreadId();
			NativeMethods.PeekMessage(out var _, 0, 0u, 0u, 0u);
			flag = Register(1, _startBinding);
			flag2 = Register(2, _stopBinding);
			_startupSignal.Set();
			while (true)
			{
				int message2 = NativeMethods.GetMessage(out var message3, 0, 0u, 0u);
				if (message2 == 0)
				{
					break;
				}
				if (message2 < 0)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error(), "The global hotkey message loop failed.");
				}
				if (message3.Message == 786)
				{
					GlobalHotkeyCommand? globalHotkeyCommand = (long)message3.WParam switch
					{
						1L => GlobalHotkeyCommand.Start, 
						2L => GlobalHotkeyCommand.Stop, 
						_ => null, 
					};
					if (globalHotkeyCommand.HasValue)
					{
						PublishHotkey(globalHotkeyCommand.Value);
					}
				}
			}
		}
		catch (Exception startupError)
		{
			_startupError = startupError;
			_startupSignal?.Set();
		}
		finally
		{
			if (flag)
			{
				NativeMethods.UnregisterHotKey(0, 1);
			}
			if (flag2)
			{
				NativeMethods.UnregisterHotKey(0, 2);
			}
			lock (_stateLock)
			{
				if (_messageThread == Thread.CurrentThread)
				{
					_messageThread = null;
					_messageThreadId = 0u;
				}
			}
		}
	}

	private void PublishHotkey(GlobalHotkeyCommand command)
	{
		EventHandler<GlobalHotkeyPressedEventArgs> eventHandler = HotkeyPressed;
		if (eventHandler == null)
		{
			return;
		}
		Delegate[] invocationList = eventHandler.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			EventHandler<GlobalHotkeyPressedEventArgs> eventHandler2 = (EventHandler<GlobalHotkeyPressedEventArgs>)invocationList[i];
			try
			{
				eventHandler2(this, new GlobalHotkeyPressedEventArgs(command));
			}
			catch
			{
			}
		}
	}

	private static bool Register(int id, GlobalHotkeyBinding binding)
	{
		if (!NativeMethods.RegisterHotKey(0, id, (uint)(binding.Modifiers | (HotkeyModifiers)0x4000u), binding.VirtualKey))
		{
			throw new Win32Exception(Marshal.GetLastWin32Error(), $"RegisterHotKey failed for virtual key 0x{binding.VirtualKey:X2}.");
		}
		return true;
	}
}

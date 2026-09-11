using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Input;
using Pfm.Core.Macros;

namespace Pfm.Services.Input;

public sealed class SendInputManager : IPriorityInputManager, IDisposable
{
	private struct Input
	{
		public uint Type;

		public InputUnion Union;
	}

	[StructLayout(LayoutKind.Explicit)]
	private struct InputUnion
	{
		[FieldOffset(0)]
		public MouseInput Mouse;

		[FieldOffset(0)]
		public KeyboardInput Keyboard;

		[FieldOffset(0)]
		public HardwareInput Hardware;
	}

	private struct KeyboardInput
	{
		public ushort VirtualKey;

		public ushort ScanCode;

		public uint Flags;

		public uint Time;

		public nuint ExtraInfo;
	}

	private struct MouseInput
	{
		public int X;

		public int Y;

		public uint MouseData;

		public uint Flags;

		public uint Time;

		public nuint ExtraInfo;
	}

	private struct HardwareInput
	{
		public uint Message;

		public ushort ParameterLow;

		public ushort ParameterHigh;
	}

	private static class NativeMethods
	{
		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint SendInput(uint inputCount, Input[] inputs, int inputSize);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCursorPos(int x, int y);
	}

	private readonly object _stateLock = new object();

	private readonly SemaphoreSlim _pulseGate = new SemaphoreSlim(1, 1);

	private SliderDirection _desiredDirection;

	private SliderDirection _appliedDirection;

	private ushort _appliedVirtualKey;

	private ushort _leftVirtualKey;

	private ushort _rightVirtualKey;

	private bool _priorityActive;

	private bool _leftMouseDown;

	private bool _rightMouseDown;

	private bool _disposed;

	public void SetDirection(SliderDirection direction, ushort leftVirtualKey, ushort rightVirtualKey)
	{
		lock (_stateLock)
		{
			ObjectDisposedException.ThrowIf(_disposed, this);
			_desiredDirection = direction;
			_leftVirtualKey = leftVirtualKey;
			_rightVirtualKey = rightVirtualKey;
			if (!_priorityActive)
			{
				ApplyDesiredDirection();
			}
		}
	}

	public async Task PulseAsync(ushort virtualKey, int delayMs, int holdMs, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentOutOfRangeException.ThrowIfNegative(delayMs, "delayMs");
		ArgumentOutOfRangeException.ThrowIfNegative(holdMs, "holdMs");
		await _pulseGate.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		bool keyIsDown = false;
		Exception operationError = null;
		try
		{
			lock (_stateLock)
			{
				ObjectDisposedException.ThrowIf(_disposed, this);
				_priorityActive = true;
				ReleaseAppliedDirection();
			}
			if (delayMs > 0)
			{
				await Task.Delay(delayMs, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			SendKey(virtualKey, isKeyUp: false);
			keyIsDown = true;
			if (holdMs > 0)
			{
				await Task.Delay(holdMs, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		catch (Exception ex)
		{
			operationError = ex;
			throw;
		}
		finally
		{
			Exception ex2 = null;
			try
			{
				if (keyIsDown)
				{
					SendKey(virtualKey, isKeyUp: true);
				}
			}
			catch (Exception ex3)
			{
				ex2 = ex3;
			}
			try
			{
				lock (_stateLock)
				{
					_priorityActive = false;
					if (!_disposed)
					{
						ApplyDesiredDirection();
					}
				}
			}
			catch (Exception ex4)
			{
				if (ex2 == null)
				{
					ex2 = ex4;
				}
			}
			_pulseGate.Release();
			if (ex2 != null && operationError == null)
			{
				throw ex2;
			}
		}
	}

	public async Task ClickAsync(MacroMouseButton button, int? x, int? y, int delayMs, int holdMs, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentOutOfRangeException.ThrowIfNegative(delayMs, "delayMs");
		ArgumentOutOfRangeException.ThrowIfNegative(holdMs, "holdMs");
		await _pulseGate.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		bool isDown = false;
		bool restoreHeldState = false;
		try
		{
			if (delayMs > 0)
			{
				await Task.Delay(delayMs, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			lock (_stateLock)
			{
				ObjectDisposedException.ThrowIf(_disposed, this);
				MoveCursorIfRequested(x, y);
				restoreHeldState = ((button == MacroMouseButton.Left) ? _leftMouseDown : _rightMouseDown);
				if (restoreHeldState)
				{
					SendMouseButton(button, isButtonUp: true);
					SetMouseState(button, isDown: false);
				}
				SendMouseButton(button, isButtonUp: false);
				isDown = true;
			}
			if (holdMs > 0)
			{
				await Task.Delay(holdMs, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		finally
		{
			Exception ex = null;
			if (isDown)
			{
				try
				{
					lock (_stateLock)
					{
						SendMouseButton(button, isButtonUp: true);
						if (restoreHeldState && !_disposed)
						{
							SendMouseButton(button, isButtonUp: false);
							SetMouseState(button, isDown: true);
						}
					}
				}
				catch (Exception ex2)
				{
					lock (_stateLock)
					{
						SetMouseState(button, isDown: true);
					}
					ex = ex2;
				}
			}
			_pulseGate.Release();
			if (ex != null)
			{
				throw ex;
			}
		}
	}

	public void SetMouseButton(MacroMouseButton button, bool isDown, int? x = null, int? y = null)
	{
		_pulseGate.Wait();
		try
		{
			lock (_stateLock)
			{
				ObjectDisposedException.ThrowIf(_disposed, this);
				MoveCursorIfRequested(x, y);
				if (((button == MacroMouseButton.Left) ? _leftMouseDown : _rightMouseDown) != isDown)
				{
					SendMouseButton(button, !isDown);
					SetMouseState(button, isDown);
				}
			}
		}
		finally
		{
			_pulseGate.Release();
		}
	}

	public void ReleaseAll()
	{
		lock (_stateLock)
		{
			_desiredDirection = SliderDirection.None;
			ReleaseAllCore();
		}
	}

	public void Dispose()
	{
		lock (_stateLock)
		{
			if (_disposed)
			{
				return;
			}
			_desiredDirection = SliderDirection.None;
			try
			{
				ReleaseAllCore();
			}
			finally
			{
				_disposed = true;
			}
		}
	}

	private void ApplyDesiredDirection()
	{
		ushort num = _desiredDirection switch
		{
			SliderDirection.Left => _leftVirtualKey, 
			SliderDirection.Right => _rightVirtualKey, 
			_ => 0, 
		};
		if (_desiredDirection != _appliedDirection || num != _appliedVirtualKey)
		{
			ReleaseAppliedDirection();
			if (num != 0)
			{
				SendKey(num, isKeyUp: false);
				_appliedDirection = _desiredDirection;
				_appliedVirtualKey = num;
			}
		}
	}

	private void ReleaseAppliedDirection()
	{
		if (_appliedVirtualKey != 0)
		{
			SendKey(_appliedVirtualKey, isKeyUp: true);
		}
		_appliedDirection = SliderDirection.None;
		_appliedVirtualKey = 0;
	}

	private static void SendKey(ushort virtualKey, bool isKeyUp)
	{
		Input input = new Input
		{
			Type = 1u,
			Union = new InputUnion
			{
				Keyboard = new KeyboardInput
				{
					VirtualKey = virtualKey,
					Flags = (isKeyUp ? 2u : 0u)
				}
			}
		};
		if (NativeMethods.SendInput(1u, new Input[1] { input }, Marshal.SizeOf<Input>()) != 1)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error(), "SendInput failed.");
		}
	}

	private void ReleaseMouseButtons()
	{
		Exception ex = null;
		if (_leftMouseDown)
		{
			try
			{
				SendMouseButton(MacroMouseButton.Left, isButtonUp: true);
				_leftMouseDown = false;
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
		}
		if (_rightMouseDown)
		{
			try
			{
				SendMouseButton(MacroMouseButton.Right, isButtonUp: true);
				_rightMouseDown = false;
			}
			catch (Exception ex3)
			{
				if (ex == null)
				{
					ex = ex3;
				}
			}
		}
		if (ex != null)
		{
			throw ex;
		}
	}

	private void ReleaseAllCore()
	{
		Exception ex = null;
		try
		{
			ReleaseAppliedDirection();
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		try
		{
			ReleaseMouseButtons();
		}
		catch (Exception ex3)
		{
			if (ex == null)
			{
				ex = ex3;
			}
		}
		if (ex != null)
		{
			throw ex;
		}
	}

	private void SetMouseState(MacroMouseButton button, bool isDown)
	{
		if (button == MacroMouseButton.Left)
		{
			_leftMouseDown = isDown;
		}
		else
		{
			_rightMouseDown = isDown;
		}
	}

	private static void MoveCursorIfRequested(int? x, int? y)
	{
		if (x.HasValue && y.HasValue && !NativeMethods.SetCursorPos(x.Value, y.Value))
		{
			throw new Win32Exception(Marshal.GetLastWin32Error(), "SetCursorPos failed.");
		}
	}

	private static void SendMouseButton(MacroMouseButton button, bool isButtonUp)
	{
		uint flags = button switch
		{
			MacroMouseButton.Left => isButtonUp ? 4u : 2u, 
			MacroMouseButton.Right => isButtonUp ? 16u : 8u, 
			_ => throw new ArgumentOutOfRangeException("button"), 
		};
		Input input = new Input
		{
			Type = 0u,
			Union = new InputUnion
			{
				Mouse = new MouseInput
				{
					Flags = flags
				}
			}
		};
		if (NativeMethods.SendInput(1u, new Input[1] { input }, Marshal.SizeOf<Input>()) != 1)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error(), "Mouse SendInput failed.");
		}
	}
}

using System;
using System.Diagnostics;
using System.Threading;

namespace Pfm.Services.Fishing;

internal sealed class HighResolutionFramePacer
{
	private readonly long _periodTicks;

	private long _nextTimestamp;

	public HighResolutionFramePacer(int framesPerSecond)
	{
		_periodTicks = Stopwatch.Frequency / Math.Clamp(framesPerSecond, 60, 240);
		_nextTimestamp = Stopwatch.GetTimestamp();
	}

	public void WaitForNextFrame(CancellationToken cancellationToken)
	{
		_nextTimestamp += _periodTicks;
		long timestamp = Stopwatch.GetTimestamp();
		if (timestamp > _nextTimestamp + _periodTicks)
		{
			_nextTimestamp = timestamp;
			return;
		}
		while (timestamp < _nextTimestamp)
		{
			cancellationToken.ThrowIfCancellationRequested();
			long num = (_nextTimestamp - timestamp) * 1000 / Stopwatch.Frequency;
			if (num > 1)
			{
				cancellationToken.WaitHandle.WaitOne((int)num - 1);
			}
			else
			{
				Thread.SpinWait(64);
			}
			timestamp = Stopwatch.GetTimestamp();
		}
	}
}

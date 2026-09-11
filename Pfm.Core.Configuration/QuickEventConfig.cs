using System.Collections.Generic;

namespace Pfm.Core.Configuration;

public sealed class QuickEventConfig
{
	public bool Enabled { get; set; }

	public ScreenRegion? SignRegion { get; set; }

	public List<int> SignClassIds { get; set; } = new List<int>();

	public int MemoHoldMs { get; set; } = 1000;

	public int SelectionTimeoutMs { get; set; } = 5000;

	public double SuccessThresholdPixels { get; set; } = 10.0;
}

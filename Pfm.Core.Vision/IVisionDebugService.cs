using System;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IVisionDebugService : IAsyncDisposable
{
	bool IsRunning { get; }

	event EventHandler<VisionDebugFrame>? FrameReady;

	Task StartAsync(FishingProfile profile, CancellationToken cancellationToken = default(CancellationToken));

	Task StopAsync();
}

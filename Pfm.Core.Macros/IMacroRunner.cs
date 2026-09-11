using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pfm.Core.Macros;

public interface IMacroRunner : IAsyncDisposable
{
	bool IsRunning { get; }

	MacroRunResult? LastResult { get; }

	event EventHandler<MacroRunnerStateChangedEventArgs>? StateChanged;

	Task StartAsync(IReadOnlyList<MacroAction> actions, CancellationToken cancellationToken = default(CancellationToken));

	Task<MacroRunResult> StopAsync();
}

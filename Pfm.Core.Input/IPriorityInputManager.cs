using System;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Macros;

namespace Pfm.Core.Input;

public interface IPriorityInputManager : IDisposable
{
	void SetDirection(SliderDirection direction, ushort leftVirtualKey, ushort rightVirtualKey);

	Task PulseAsync(ushort virtualKey, int delayMs, int holdMs, CancellationToken cancellationToken = default(CancellationToken));

	Task ClickAsync(MacroMouseButton button, int? x, int? y, int delayMs, int holdMs, CancellationToken cancellationToken = default(CancellationToken));

	void SetMouseButton(MacroMouseButton button, bool isDown, int? x = null, int? y = null);

	void ReleaseAll();
}

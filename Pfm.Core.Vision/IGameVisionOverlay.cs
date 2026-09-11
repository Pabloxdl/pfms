using System;
using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IGameVisionOverlay : IDisposable
{
	bool IsVisible { get; }

	void Show(FishingProfile profile);

	void Hide();

	void Update(VisionDebugFrame frame);
}

using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IColorSelector
{
	Task<PixelColor?> SelectAsync(PixelColor initialColor, CancellationToken cancellationToken = default(CancellationToken));
}

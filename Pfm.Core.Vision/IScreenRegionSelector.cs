using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IScreenRegionSelector
{
	Task<ScreenRegion?> SelectAsync(ScreenRegion initialRegion, CancellationToken cancellationToken = default(CancellationToken));
}

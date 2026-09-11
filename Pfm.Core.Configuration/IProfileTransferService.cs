using System.Threading;
using System.Threading.Tasks;

namespace Pfm.Core.Configuration;

public interface IProfileTransferService
{
	Task ExportAsync(GameConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken));

	Task<GameConfiguration?> ImportAsync(CancellationToken cancellationToken = default(CancellationToken));
}

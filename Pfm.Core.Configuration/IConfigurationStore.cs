using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pfm.Core.Configuration;

public interface IConfigurationStore
{
	Task<IReadOnlyList<GameConfiguration>> LoadAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task SaveAsync(IEnumerable<GameConfiguration> configurations, CancellationToken cancellationToken = default(CancellationToken));
}

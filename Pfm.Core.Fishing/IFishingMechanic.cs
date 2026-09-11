using System.Threading;
using System.Threading.Tasks;

namespace Pfm.Core.Fishing;

public interface IFishingMechanic
{
	string Id { get; }

	string DisplayName { get; }

	Task<FishingProcessResult> ExecuteAsync(FishingProcessContext context, CancellationToken cancellationToken = default(CancellationToken));
}

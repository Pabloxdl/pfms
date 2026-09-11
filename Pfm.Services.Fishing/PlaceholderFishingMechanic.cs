using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Fishing;

namespace Pfm.Services.Fishing;

public sealed class PlaceholderFishingMechanic : IFishingMechanic
{
	public string Id => "placeholder";

	public string DisplayName => "Fishing adapter";

	public Task<FishingProcessResult> ExecuteAsync(FishingProcessContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Task.FromResult(FishingProcessResult.NotImplemented(Id));
	}
}

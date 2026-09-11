using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;

namespace Pfm.Core.Vision;

public interface IUiTemplateLibrary
{
	Task<UiTemplateAsset?> ImportAsync(CancellationToken cancellationToken = default(CancellationToken));
}

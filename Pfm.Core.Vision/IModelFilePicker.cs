using System.Threading;
using System.Threading.Tasks;

namespace Pfm.Core.Vision;

public interface IModelFilePicker
{
	Task<string?> PickAsync(CancellationToken cancellationToken = default(CancellationToken));
}

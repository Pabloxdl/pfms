using System.Threading;
using System.Threading.Tasks;

namespace Pfm.Core.Vision;

public interface IImageFilePicker
{
	Task<string?> PickPngAsync(CancellationToken cancellationToken = default(CancellationToken));
}

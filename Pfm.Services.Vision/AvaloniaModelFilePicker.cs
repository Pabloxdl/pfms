using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class AvaloniaModelFilePicker : IModelFilePicker
{
	public async Task<string?> PickAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!(Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime { MainWindow: not null } classicDesktopStyleApplicationLifetime))
		{
			return null;
		}
		IReadOnlyList<IStorageFile> source = await classicDesktopStyleApplicationLifetime.MainWindow.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Select YOLO detection model",
			AllowMultiple = false,
			FileTypeFilter = new global::_003C_003Ez__ReadOnlySingleElementList<FilePickerFileType>(new FilePickerFileType("YOLO model files")
			{
				Patterns = new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "*.onnx", "*.pt" })
			})
		});
		cancellationToken.ThrowIfCancellationRequested();
		return source.FirstOrDefault()?.TryGetLocalPath();
	}
}

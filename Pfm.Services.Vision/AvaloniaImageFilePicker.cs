using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class AvaloniaImageFilePicker : IImageFilePicker
{
	public async Task<string?> PickPngAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!(Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime { MainWindow: not null } classicDesktopStyleApplicationLifetime))
		{
			return null;
		}
		IReadOnlyList<IStorageFile> source = await classicDesktopStyleApplicationLifetime.MainWindow.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Select configuration cover",
			AllowMultiple = false,
			FileTypeFilter = new global::_003C_003Ez__ReadOnlySingleElementList<FilePickerFileType>(new FilePickerFileType("PNG images")
			{
				Patterns = new global::_003C_003Ez__ReadOnlySingleElementList<string>("*.png")
			})
		});
		cancellationToken.ThrowIfCancellationRequested();
		return source.FirstOrDefault()?.TryGetLocalPath();
	}
}

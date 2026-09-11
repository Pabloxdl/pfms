using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class AvaloniaUiTemplateLibrary : IUiTemplateLibrary
{
	private readonly string _templateDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pfm", "Templates");

	public async Task<UiTemplateAsset?> ImportAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!(Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime { MainWindow: not null } classicDesktopStyleApplicationLifetime))
		{
			return null;
		}
		IReadOnlyList<IStorageFile> source = await classicDesktopStyleApplicationLifetime.MainWindow.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Import UI image template",
			AllowMultiple = false,
			FileTypeFilter = new global::_003C_003Ez__ReadOnlySingleElementList<FilePickerFileType>(new FilePickerFileType("Image files")
			{
				Patterns = new _003C_003Ez__ReadOnlyArray<string>(new string[4] { "*.png", "*.jpg", "*.jpeg", "*.bmp" })
			})
		});
		cancellationToken.ThrowIfCancellationRequested();
		IStorageFile source2 = source.FirstOrDefault();
		if (source2 == null)
		{
			return null;
		}
		Directory.CreateDirectory(_templateDirectory);
		string extension = Path.GetExtension(source2.Name);
		string destination = Path.Combine(_templateDirectory, $"{Guid.NewGuid():N}{extension}");
		UiTemplateAsset result;
		await using (Stream input = await source2.OpenReadAsync())
		{
			UiTemplateAsset uiTemplateAsset;
			await using (FileStream output = File.Create(destination))
			{
				await input.CopyToAsync(output, cancellationToken);
				uiTemplateAsset = new UiTemplateAsset
				{
					Name = Path.GetFileNameWithoutExtension(source2.Name),
					FilePath = destination
				};
			}
			result = uiTemplateAsset;
		}
		return result;
	}
}

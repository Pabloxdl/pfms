using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Pfm.Core.Configuration;

namespace Pfm.Services.Configuration;

public sealed class AvaloniaProfileTransferService : IProfileTransferService
{
	public async Task ExportAsync(GameConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
	{
		Window window = GetWindow();
		if (window == null)
		{
			return;
		}
		IStorageFile storageFile = await window.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
		{
			Title = "Export PFMS configuration",
			SuggestedFileName = SanitizeFileName(configuration.Name) + ".pfms-configuration.zip",
			FileTypeChoices = new global::_003C_003Ez__ReadOnlySingleElementList<FilePickerFileType>(new FilePickerFileType("PFMS configuration bundle")
			{
				Patterns = new global::_003C_003Ez__ReadOnlySingleElementList<string>("*.zip")
			})
		});
		if (storageFile == null)
		{
			return;
		}
		cancellationToken.ThrowIfCancellationRequested();
		await using Stream stream = await storageFile.OpenWriteAsync();
		await ConfigurationBundle.ExportAsync(stream, configuration, cancellationToken);
	}

	public async Task<GameConfiguration?> ImportAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		Window window = GetWindow();
		if (window == null)
		{
			return null;
		}
		IStorageFile file = (await window.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Import PFMS configuration",
			AllowMultiple = false,
			FileTypeFilter = new _003C_003Ez__ReadOnlyArray<FilePickerFileType>(new FilePickerFileType[2]
			{
				new FilePickerFileType("PFMS configuration bundle")
				{
					Patterns = new global::_003C_003Ez__ReadOnlySingleElementList<string>("*.zip")
				},
				new FilePickerFileType("Legacy PFMS configuration")
				{
					Patterns = new global::_003C_003Ez__ReadOnlySingleElementList<string>("*.json")
				}
			})
		})).FirstOrDefault();
		if (file == null)
		{
			return null;
		}
		cancellationToken.ThrowIfCancellationRequested();
		GameConfiguration result;
		await using (Stream stream = await file.OpenReadAsync())
		{
			GameConfiguration gameConfiguration = ((!Path.GetExtension(file.Name).Equals(".zip", StringComparison.OrdinalIgnoreCase)) ? (await JsonSerializer.DeserializeAsync<GameConfiguration>(stream, (JsonSerializerOptions?)null, cancellationToken)) : (await ConfigurationBundle.ImportAsync(stream, cancellationToken)));
			result = gameConfiguration;
		}
		return result;
	}

	private static Window? GetWindow()
	{
		return (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
	}

	private static string SanitizeFileName(string name)
	{
		char[] invalid = Path.GetInvalidFileNameChars();
		string text = new string(name.Select((char character) => (!invalid.Contains(character)) ? character : '_').ToArray());
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "pfms-configuration";
	}
}

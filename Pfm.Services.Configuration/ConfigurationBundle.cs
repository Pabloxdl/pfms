using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;

namespace Pfm.Services.Configuration;

public static class ConfigurationBundle
{
	private const string ConfigurationEntryName = "configuration.json";

	private const string ModelsEntryDirectory = "models/";

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		WriteIndented = true
	};

	public static string StoreModel(string sourcePath)
	{
		string fullPath = Path.GetFullPath(sourcePath);
		string modelsDirectory = GetModelsDirectory();
		if (fullPath.StartsWith(modelsDirectory + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
		{
			return fullPath;
		}
		string text = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(fullPath))).Substring(0, 12);
		string text2 = Path.Combine(modelsDirectory, Path.GetFileNameWithoutExtension(fullPath) + "-" + text + Path.GetExtension(fullPath));
		if (!File.Exists(text2) || File.GetLastWriteTimeUtc(fullPath) > File.GetLastWriteTimeUtc(text2) || new FileInfo(fullPath).Length != new FileInfo(text2).Length)
		{
			File.Copy(fullPath, text2, overwrite: true);
		}
		return text2;
	}

	public static async Task ExportAsync(Stream destination, GameConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
	{
		using ZipArchive archive = new ZipArchive(destination, ZipArchiveMode.Create, leaveOpen: true);
		JsonObject json = JsonNode.Parse(JsonSerializer.Serialize(configuration, JsonOptions)).AsObject();
		string modelFilePath = configuration.Fishing.ModelFilePath;
		if (!string.IsNullOrWhiteSpace(modelFilePath) && File.Exists(modelFilePath))
		{
			string modelName = Path.GetFileName(modelFilePath);
			ZipArchiveEntry zipArchiveEntry = archive.CreateEntry("models/" + modelName, CompressionLevel.Optimal);
			await using Stream modelStream = zipArchiveEntry.Open();
			await using FileStream sourceStream = File.OpenRead(modelFilePath);
			await sourceStream.CopyToAsync(modelStream, cancellationToken);
			json["Fishing"]["ModelFilePath"] = "models/" + modelName;
		}
		ZipArchiveEntry zipArchiveEntry2 = archive.CreateEntry("configuration.json", CompressionLevel.Optimal);
		await using Stream configurationStream = zipArchiveEntry2.Open();
		await JsonSerializer.SerializeAsync(configurationStream, json, JsonOptions, cancellationToken);
	}

	public static async Task<GameConfiguration?> ImportAsync(Stream source, CancellationToken cancellationToken = default(CancellationToken))
	{
		using ZipArchive archive = new ZipArchive(source, ZipArchiveMode.Read, leaveOpen: true);
		ZipArchiveEntry zipArchiveEntry = archive.GetEntry("configuration.json") ?? throw new InvalidOperationException("The configuration bundle does not contain configuration.json.");
		GameConfiguration result;
		await using (Stream configurationStream = zipArchiveEntry.Open())
		{
			GameConfiguration configuration = await JsonSerializer.DeserializeAsync<GameConfiguration>(configurationStream, (JsonSerializerOptions?)null, cancellationToken);
			if (configuration == null)
			{
				result = null;
			}
			else
			{
				string text = configuration.Fishing.ModelFilePath.Replace('\\', '/');
				if (text.StartsWith("models/", StringComparison.Ordinal) && Path.GetFileName(text) == text.Substring("models/".Length))
				{
					ZipArchiveEntry zipArchiveEntry2 = archive.GetEntry(text) ?? throw new InvalidOperationException("The configuration bundle model is missing.");
					string temporaryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + Path.GetExtension(text));
					try
					{
						await using (Stream modelStream = zipArchiveEntry2.Open())
						{
							await using FileStream temporaryStream = File.Create(temporaryPath);
							await modelStream.CopyToAsync(temporaryStream, cancellationToken);
						}
						configuration.Fishing.ModelFilePath = StoreModel(temporaryPath);
					}
					finally
					{
						File.Delete(temporaryPath);
					}
				}
				result = configuration;
			}
		}
		return result;
	}

	private static string GetModelsDirectory()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pfm", "Templates", "Models");
		Directory.CreateDirectory(text);
		return text;
	}
}

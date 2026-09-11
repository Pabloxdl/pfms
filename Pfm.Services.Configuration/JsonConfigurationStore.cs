using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Pfm.Core.Configuration;
using Pfm.Core.Macros;

namespace Pfm.Services.Configuration;

public sealed class JsonConfigurationStore : IConfigurationStore
{
	private readonly string _filePath;

	private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
	{
		WriteIndented = true
	};

	public JsonConfigurationStore(string dataDirectory)
	{
		_filePath = Path.Combine(dataDirectory, "configurations.json");
	}

	public async Task<IReadOnlyList<GameConfiguration>> LoadAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!File.Exists(_filePath))
		{
			return Array.Empty<GameConfiguration>();
		}
		IReadOnlyList<GameConfiguration> result;
		await using (FileStream stream = File.OpenRead(_filePath))
		{
			List<GameConfiguration> list = (await JsonSerializer.DeserializeAsync<List<GameConfiguration>>((Stream)stream, _serializerOptions, cancellationToken)) ?? new List<GameConfiguration>();
			foreach (TemplateImageMatchAction item in list.SelectMany((GameConfiguration configuration) => configuration.Macros).SelectMany((MacroDefinition macro) => macro.Actions).OfType<TemplateImageMatchAction>())
			{
				double similarityThreshold = item.SimilarityThreshold;
				if ((similarityThreshold <= 0.0 || similarityThreshold > 1.0) ? true : false)
				{
					item.SimilarityThreshold = 0.85;
				}
			}
			result = list;
		}
		return result;
	}

	public async Task SaveAsync(IEnumerable<GameConfiguration> configurations, CancellationToken cancellationToken = default(CancellationToken))
	{
		string directoryName = Path.GetDirectoryName(_filePath);
		Directory.CreateDirectory(directoryName);
		string temporaryPath = Path.Combine(directoryName, $".{Path.GetFileName(_filePath)}.{Guid.NewGuid():N}.tmp");
		try
		{
			await using (FileStream stream = File.Create(temporaryPath))
			{
				await JsonSerializer.SerializeAsync((Stream)stream, configurations, _serializerOptions, cancellationToken);
			}
			File.Move(temporaryPath, _filePath, overwrite: true);
		}
		finally
		{
			if (File.Exists(temporaryPath))
			{
				File.Delete(temporaryPath);
			}
		}
	}
}

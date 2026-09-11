using System;
using System.IO;

namespace Pfm.Services;

public static class RuntimeDiagnostics
{
	private static readonly object Sync = new object();

	private static readonly string LogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pfm", "runtime.log");

	public static void Write(string message)
	{
		try
		{
			lock (Sync)
			{
				Directory.CreateDirectory(Path.GetDirectoryName(LogPath));
				File.AppendAllText(LogPath, $"{DateTimeOffset.Now:O} {message}{Environment.NewLine}");
			}
		}
		catch
		{
		}
	}
}

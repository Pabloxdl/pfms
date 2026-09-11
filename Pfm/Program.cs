using System;
using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Logging;

namespace Pfm;

[SupportedOSPlatform("windows")]
internal sealed class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
	}

	public static AppBuilder BuildAvaloniaApp()
	{
		return AppBuilder.Configure<App>().UsePlatformDetect().WithInterFont()
			.LogToTrace(LogEventLevel.Warning);
	}
}

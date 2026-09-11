using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using Pfm;
using Pfm.Views;

namespace CompiledAvaloniaXaml;

[EditorBrowsable(EditorBrowsableState.Never)]
[CompilerGenerated]
public class _0021XamlLoader
{
	public static object TryLoad(IServiceProvider P_0, string P_1)
	{
		if (string.Equals(P_1, "avares://PFMS/App.axaml", StringComparison.OrdinalIgnoreCase))
		{
			return new App();
		}
		if (string.Equals(P_1, "avares://PFMS/Styles/GlassTheme.axaml", StringComparison.OrdinalIgnoreCase))
		{
			return _0021AvaloniaResources.Build_003A_002FStyles_002FGlassTheme_002Eaxaml(XamlIlRuntimeHelpers.CreateRootServiceProviderV3(P_0));
		}
		if (string.Equals(P_1, "avares://PFMS/Views/GameVisionOverlay.axaml", StringComparison.OrdinalIgnoreCase))
		{
			return new GameVisionOverlay();
		}
		if (string.Equals(P_1, "avares://PFMS/Views/HelpWindow.axaml", StringComparison.OrdinalIgnoreCase))
		{
			return new HelpWindow();
		}
		if (string.Equals(P_1, "avares://PFMS/Views/MainWindow.axaml", StringComparison.OrdinalIgnoreCase))
		{
			return new MainWindow();
		}
		if (string.Equals(P_1, "avares://PFMS/Views/ScreenRegionSelectionWindow.axaml", StringComparison.OrdinalIgnoreCase))
		{
			return new ScreenRegionSelectionWindow();
		}
		return null;
	}

	public static object TryLoad(string P_0)
	{
		return TryLoad(null, P_0);
	}
}

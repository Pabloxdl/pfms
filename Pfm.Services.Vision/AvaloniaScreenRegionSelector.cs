using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;
using Pfm.Views;

namespace Pfm.Services.Vision;

public sealed class AvaloniaScreenRegionSelector : IScreenRegionSelector
{
	public async Task<ScreenRegion?> SelectAsync(ScreenRegion initialRegion, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (!(Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime { MainWindow: not null } classicDesktopStyleApplicationLifetime))
		{
			return null;
		}
		ScreenRegionSelectionWindow selector = new ScreenRegionSelectionWindow();
		Window mainWindow = classicDesktopStyleApplicationLifetime.MainWindow;
		bool restoreMainWindow = mainWindow.IsVisible;
		TaskCompletionSource<ScreenRegion?> completed = new TaskCompletionSource<ScreenRegion>(TaskCreationOptions.RunContinuationsAsynchronously);
		selector.Closed += delegate
		{
			completed.TrySetResult(selector.SelectedRegion);
		};
		using (cancellationToken.Register(delegate
		{
			Dispatcher.UIThread.Post(selector.Close);
		}))
		{
			try
			{
				if (restoreMainWindow)
				{
					mainWindow.Hide();
				}
				selector.Show();
				return await completed.Task;
			}
			finally
			{
				selector.Close();
				if (restoreMainWindow)
				{
					mainWindow.Show();
					mainWindow.Activate();
				}
			}
		}
	}
}

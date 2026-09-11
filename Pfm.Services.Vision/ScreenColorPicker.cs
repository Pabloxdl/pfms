using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class ScreenColorPicker : IColorSelector
{
	public async Task<PixelColor?> SelectAsync(PixelColor initialColor, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (!OperatingSystem.IsWindows())
		{
			return null;
		}
		TaskCompletionSource<PixelColor?> tcs = new TaskCompletionSource<PixelColor>(TaskCreationOptions.RunContinuationsAsynchronously);
		ScreenColorPickerWindow pickerWindow = new ScreenColorPickerWindow(initialColor, delegate(PixelColor color)
		{
			tcs.SetResult(color);
		});
		pickerWindow.Closed += delegate
		{
			tcs.TrySetResult(null);
		};
		using (cancellationToken.Register(delegate
		{
			Dispatcher.UIThread.Post(pickerWindow.Close);
		}))
		{
			Window mainWindow = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
			bool restoreMainWindow = mainWindow?.IsVisible ?? false;
			try
			{
				if (restoreMainWindow)
				{
					mainWindow.Hide();
				}
				pickerWindow.Show();
				return await tcs.Task;
			}
			finally
			{
				pickerWindow.Close();
				if (restoreMainWindow)
				{
					mainWindow.Show();
					mainWindow.Activate();
				}
			}
		}
	}
}

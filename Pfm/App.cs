using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Avalonia.Threading;
using CompiledAvaloniaXaml;
using Pfm.Core.Configuration;
using Pfm.Core.Hotkeys;
using Pfm.Core.Vision;
using Pfm.Services.Configuration;
using Pfm.Services.Fishing;
using Pfm.Services.Hotkeys;
using Pfm.Services.Input;
using Pfm.Services.Macros;
using Pfm.Services.Vision;
using Pfm.ViewModels;
using Pfm.Views;

namespace Pfm;

[SupportedOSPlatform("windows")]
public class App : Application
{
	[CompilerGenerated]
	private class XamlClosure_1
	{
		public static object Build_1(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<App> context = CreateContext(P_0);
			return new HexToColorConverter();
		}

		public static CompiledAvaloniaXaml.XamlIlContext.Context<App> CreateContext(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<App> context = new CompiledAvaloniaXaml.XamlIlContext.Context<App>(P_0, new object[1] { _0021AvaloniaResources.NamespaceInfo_003A_002FApp_002Eaxaml.Singleton }, "avares://PFMS/App.axaml");
			if (P_0 != null)
			{
				object service = P_0.GetService(typeof(IRootObjectProvider));
				if (service != null)
				{
					service = ((IRootObjectProvider)service).RootObject;
					context.RootObject = (App)service;
				}
			}
			return context;
		}
	}

	[CompilerGenerated]
	private static Action<object> _0021XamlIlPopulateOverride;

	public override void Initialize()
	{
		_0021XamlIlPopulateTrampoline(this);
	}

	public override void OnFrameworkInitializationCompleted()
	{
		WindowsGlobalHotkeyService hotkeys;
		MainViewModel mainViewModel;
		if (base.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime classicDesktopStyleApplicationLifetime)
		{
			string dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pfm");
			SendInputManager inputManager = new SendInputManager();
			OnnxYoloObjectDetectionRunner yoloRunner = new OnnxYoloObjectDetectionRunner();
			GdiScreenCaptureFactory captureFactory = new GdiScreenCaptureFactory();
			YoloSliderDetector yoloSliderDetector = new YoloSliderDetector(yoloRunner);
			DualRegionFishingMechanic dualRegionFishingMechanic = new DualRegionFishingMechanic(captureFactory, inputManager, () => new ColorRhythmDetector(), yoloSliderDetector);
			VisionDebugService visionDebugService = new VisionDebugService(captureFactory, yoloSliderDetector);
			AvaloniaGameVisionOverlay gameVisionOverlay = new AvaloniaGameVisionOverlay();
			MainViewModel overlayHost = null;
			dualRegionFishingMechanic.LiveObservationReported = delegate(FishingProfile profile, SliderObservation observation, int frameWidth, int frameHeight)
			{
				MainViewModel mainViewModel2 = overlayHost;
				if (mainViewModel2 == null || !mainViewModel2.ShowGameVisionOverlay)
				{
					gameVisionOverlay.Hide();
				}
				else
				{
					gameVisionOverlay.Show(profile);
					DetectionDisplayBox[] boxes = DetectionDisplayFormatter.BuildDisplayBoxes(observation.DetectionBoxes, profile);
					string summary = DetectionDisplayFormatter.BuildClassStatus(observation, profile);
					BarStripFrame barStrip = DetectionDisplayFormatter.BuildBarStrip(observation, profile, frameWidth);
					gameVisionOverlay.Update(new VisionDebugFrame(Array.Empty<byte>(), summary, observation.DetectionBoxes.Count, null, boxes, frameWidth, frameHeight, barStrip));
				}
			};
			MacroRunner macroRunner = new MacroRunner(new GdiScreenCaptureFactory(), inputManager);
			hotkeys = null;
			mainViewModel = null;
			mainViewModel = new MainViewModel(new JsonConfigurationStore(dataDirectory), dualRegionFishingMechanic, macroRunner, new AvaloniaScreenRegionSelector(), new ScreenColorPicker(), new AvaloniaUiTemplateLibrary(), new AvaloniaModelFilePicker(), new AvaloniaImageFilePicker(), visionDebugService, gameVisionOverlay, RegisterHotkeys, new AvaloniaProfileTransferService());
			overlayHost = mainViewModel;
			MainWindow mainWindow = new MainWindow
			{
				DataContext = mainViewModel
			};
			Task initializationTask = null;
			mainWindow.Opened += async delegate
			{
				if (initializationTask == null)
				{
					initializationTask = mainViewModel.InitializeAsync();
				}
				await initializationTask;
			};
			mainWindow.Closed += delegate
			{
				hotkeys?.Dispose();
				try
				{
					mainViewModel.StopActiveMacroAsync().GetAwaiter().GetResult();
					visionDebugService.StopAsync().GetAwaiter().GetResult();
					gameVisionOverlay.Dispose();
				}
				finally
				{
					try
					{
						yoloRunner.Dispose();
					}
					finally
					{
						try
						{
							macroRunner.DisposeAsync().AsTask().GetAwaiter()
								.GetResult();
						}
						finally
						{
							try
							{
								inputManager.Dispose();
							}
							catch
							{
							}
						}
					}
				}
			};
			try
			{
				(GlobalHotkeyBinding, GlobalHotkeyBinding) configuredHotkeys = mainViewModel.GetConfiguredHotkeys();
				RegisterHotkeys(configuredHotkeys.Item1, configuredHotkeys.Item2);
			}
			catch (Exception ex)
			{
				mainViewModel.StatusMessage = "Global hotkeys unavailable: " + ex.Message;
			}
			classicDesktopStyleApplicationLifetime.MainWindow = mainWindow;
		}
		base.OnFrameworkInitializationCompleted();
		void RegisterHotkeys(GlobalHotkeyBinding start, GlobalHotkeyBinding stop)
		{
			hotkeys?.Dispose();
			hotkeys = new WindowsGlobalHotkeyService();
			hotkeys.HotkeyPressed += delegate(object? _, GlobalHotkeyPressedEventArgs args)
			{
				Avalonia.Threading.Dispatcher.UIThread.Post(async delegate
				{
					_ = 1;
					try
					{
						if (args.Command == GlobalHotkeyCommand.Start)
						{
							await mainViewModel.StartActiveMacroAsync();
						}
						else
						{
							await mainViewModel.StopActiveMacroAsync();
						}
					}
					catch (Exception ex2)
					{
						mainViewModel.StatusMessage = "Hotkey command failed: " + ex2.Message;
					}
				});
			};
			hotkeys.Start(start, stop);
		}
	}

	[CompilerGenerated]
	private unsafe static void _0021XamlIlPopulate(IServiceProvider P_0, App P_1)
	{
		CompiledAvaloniaXaml.XamlIlContext.Context<App> context = new CompiledAvaloniaXaml.XamlIlContext.Context<App>(P_0, new object[1] { _0021AvaloniaResources.NamespaceInfo_003A_002FApp_002Eaxaml.Singleton }, "avares://PFMS/App.axaml")
		{
			RootObject = P_1,
			IntermediateRoot = P_1
		};
		App app2;
		App app = (app2 = P_1);
		context.PushParent(app2);
		app2.RequestedThemeVariant = ThemeVariant.Dark;
		((ResourceDictionary)app2.Resources).AddDeferred((object)"HexToColorConverter", XamlIlRuntimeHelpers.DeferredTransformationFactoryV3<object>((nint)(delegate*<IServiceProvider, object>)(&XamlClosure_1.Build_1), context));
		app2.Styles.Add(new FluentTheme(context));
		app2.Styles.Add(_0021AvaloniaResources.Build_003A_002FStyles_002FGlassTheme_002Eaxaml(XamlIlRuntimeHelpers.CreateRootServiceProviderV3(context)));
		context.PopParent();
		if ((object)app is StyledElement styled)
		{
			NameScope.SetNameScope(styled, context.AvaloniaNameScope);
		}
		context.AvaloniaNameScope.Complete();
	}

	[CompilerGenerated]
	private static void _0021XamlIlPopulateTrampoline(App P_0)
	{
		if (_0021XamlIlPopulateOverride != null)
		{
			_0021XamlIlPopulateOverride(P_0);
		}
		else
		{
			_0021XamlIlPopulate(XamlIlRuntimeHelpers.CreateRootServiceProviderV3(null), P_0);
		}
	}
}

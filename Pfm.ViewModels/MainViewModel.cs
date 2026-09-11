using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pfm.Core.Configuration;
using Pfm.Core.Fishing;
using Pfm.Core.Hotkeys;
using Pfm.Core.Macros;
using Pfm.Core.Vision;
using Pfm.Services;
using Pfm.Services.Configuration;

namespace Pfm.ViewModels;

public class MainViewModel : ViewModelBase
{
	private sealed record HotkeySettings(string StartHotkey, string StopHotkey);

	private sealed class InMemoryConfigurationStore : IConfigurationStore
	{
		public Task<IReadOnlyList<GameConfiguration>> LoadAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.FromResult((IReadOnlyList<GameConfiguration>)Array.Empty<GameConfiguration>());
		}

		public Task SaveAsync(IEnumerable<GameConfiguration> configurations, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.CompletedTask;
		}
	}

	private sealed class DesignFishingMechanic : IFishingMechanic
	{
		public string Id => "design";

		public string DisplayName => "Fishing adapter";

		public Task<FishingProcessResult> ExecuteAsync(FishingProcessContext context, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.FromResult(FishingProcessResult.NotImplemented(Id));
		}
	}

	private sealed class EmptyServiceProvider : IServiceProvider
	{
		public static EmptyServiceProvider Instance { get; } = new EmptyServiceProvider();

		public object? GetService(Type serviceType)
		{
			return null;
		}
	}

	private readonly IConfigurationStore _configurationStore;

	private readonly IFishingMechanic _fishingMechanic;

	private readonly IMacroRunner? _macroRunner;

	private readonly IScreenRegionSelector? _regionSelector;

	private readonly IColorSelector? _colorSelector;

	private readonly IModelFilePicker? _modelFilePicker;

	private readonly IImageFilePicker? _imageFilePicker;

	private readonly IVisionDebugService? _visionDebugService;

	private readonly IGameVisionOverlay? _gameVisionOverlay;

	private readonly Action<GlobalHotkeyBinding, GlobalHotkeyBinding>? _rebindHotkeys;

	private readonly IProfileTransferService? _profileTransferService;

	private readonly SynchronizationContext? _uiContext;

	private readonly SemaphoreSlim _fishingLifecycleGate = new SemaphoreSlim(1, 1);

	private readonly SemaphoreSlim _configurationSaveGate = new SemaphoreSlim(1, 1);

	private CancellationTokenSource? _fishingCancellation;

	private Task<FishingProcessResult>? _fishingTask;

	[ObservableProperty]
	private string _activeMechanicName = string.Empty;

	[ObservableProperty]
	private string _currentSection = "Configurations";

	[ObservableProperty]
	private string _statusMessage = "Ready";

	[ObservableProperty]
	private int _newConfigurationModeIndex;

	[ObservableProperty]
	private ConfigurationItemViewModel? _selectedConfiguration;

	[ObservableProperty]
	private bool _isEditorOpen;

	[ObservableProperty]
	private bool _isMacroRunning;

	[ObservableProperty]
	private bool _isDebugVisionRunning;

	[ObservableProperty]
	private Bitmap? _visionPreview;

	[ObservableProperty]
	private string _visionSummary = "Select a profile and start preview.";

	[ObservableProperty]
	private int _visionDetectionCount;

	[ObservableProperty]
	private BarStripFrame? _visionBarStrip;

	[ObservableProperty]
	private bool _showGameVisionOverlay = true;

	[ObservableProperty]
	private string _startHotkey = "F6";

	[ObservableProperty]
	private string _stopHotkey = "F7";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? navigateCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openTemplatesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? applyHotkeysCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? createConfigurationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ConfigurationItemViewModel?>? exportProfileCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? importProfileCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? saveConfigurationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? deleteConfigurationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? closeEditorCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? startMacroCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? stopMacroCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? startVisionDebugCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? stopVisionDebugCommand;

	public ObservableCollection<ConfigurationItemViewModel> Configurations { get; }

	public CfgBuilderViewModel CfgBuilder { get; }

	public int ConfigurationCount => Configurations.Count;

	public bool IsOverview => CurrentSection == "Overview";

	public bool IsConfigurations => CurrentSection == "Configurations";

	public bool IsBuilder => CurrentSection == "Builder";

	public bool IsVision => CurrentSection == "Vision";

	public bool IsSettings => CurrentSection == "Settings";

	public string ConfigurationPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pfm", "configurations.json");

	public string DataDirectory => Path.GetDirectoryName(ConfigurationPath);

	public IReadOnlyList<string> HotkeyOptions { get; } = (from value in Enumerable.Range(1, 12)
		select $"F{value}").ToArray();

	private string HotkeySettingsPath => Path.Combine(DataDirectory, "settings.json");

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ActiveMechanicName
	{
		get
		{
			return _activeMechanicName;
		}
		[MemberNotNull("_activeMechanicName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_activeMechanicName, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveMechanicName);
				_activeMechanicName = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveMechanicName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string CurrentSection
	{
		get
		{
			return _currentSection;
		}
		[MemberNotNull("_currentSection")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentSection, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentSection);
				_currentSection = value;
				OnCurrentSectionChanged(value);
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentSection);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string StatusMessage
	{
		get
		{
			return _statusMessage;
		}
		[MemberNotNull("_statusMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_statusMessage, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StatusMessage);
				_statusMessage = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StatusMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int NewConfigurationModeIndex
	{
		get
		{
			return _newConfigurationModeIndex;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_newConfigurationModeIndex, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NewConfigurationModeIndex);
				_newConfigurationModeIndex = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NewConfigurationModeIndex);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ConfigurationItemViewModel? SelectedConfiguration
	{
		get
		{
			return _selectedConfiguration;
		}
		set
		{
			if (!EqualityComparer<ConfigurationItemViewModel>.Default.Equals(_selectedConfiguration, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedConfiguration);
				_selectedConfiguration = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedConfiguration);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsEditorOpen
	{
		get
		{
			return _isEditorOpen;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isEditorOpen, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsEditorOpen);
				_isEditorOpen = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsEditorOpen);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsMacroRunning
	{
		get
		{
			return _isMacroRunning;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isMacroRunning, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsMacroRunning);
				_isMacroRunning = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsMacroRunning);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDebugVisionRunning
	{
		get
		{
			return _isDebugVisionRunning;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDebugVisionRunning, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsDebugVisionRunning);
				_isDebugVisionRunning = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsDebugVisionRunning);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Bitmap? VisionPreview
	{
		get
		{
			return _visionPreview;
		}
		set
		{
			if (!EqualityComparer<Bitmap>.Default.Equals(_visionPreview, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.VisionPreview);
				_visionPreview = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.VisionPreview);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string VisionSummary
	{
		get
		{
			return _visionSummary;
		}
		[MemberNotNull("_visionSummary")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_visionSummary, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.VisionSummary);
				_visionSummary = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.VisionSummary);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int VisionDetectionCount
	{
		get
		{
			return _visionDetectionCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_visionDetectionCount, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.VisionDetectionCount);
				_visionDetectionCount = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.VisionDetectionCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BarStripFrame? VisionBarStrip
	{
		get
		{
			return _visionBarStrip;
		}
		set
		{
			if (!EqualityComparer<BarStripFrame>.Default.Equals(_visionBarStrip, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.VisionBarStrip);
				_visionBarStrip = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.VisionBarStrip);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowGameVisionOverlay
	{
		get
		{
			return _showGameVisionOverlay;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showGameVisionOverlay, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowGameVisionOverlay);
				_showGameVisionOverlay = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowGameVisionOverlay);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string StartHotkey
	{
		get
		{
			return _startHotkey;
		}
		[MemberNotNull("_startHotkey")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_startHotkey, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StartHotkey);
				_startHotkey = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StartHotkey);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string StopHotkey
	{
		get
		{
			return _stopHotkey;
		}
		[MemberNotNull("_stopHotkey")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_stopHotkey, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StopHotkey);
				_stopHotkey = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StopHotkey);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> NavigateCommand => navigateCommand ?? (navigateCommand = new RelayCommand<string>(Navigate));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenTemplatesCommand => openTemplatesCommand ?? (openTemplatesCommand = new RelayCommand(OpenTemplates));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ApplyHotkeysCommand => applyHotkeysCommand ?? (applyHotkeysCommand = new RelayCommand(ApplyHotkeys));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CreateConfigurationCommand => createConfigurationCommand ?? (createConfigurationCommand = new AsyncRelayCommand(CreateConfigurationAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ConfigurationItemViewModel?> ExportProfileCommand => exportProfileCommand ?? (exportProfileCommand = new AsyncRelayCommand<ConfigurationItemViewModel>(ExportProfileAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ImportProfileCommand => importProfileCommand ?? (importProfileCommand = new AsyncRelayCommand(ImportProfileAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SaveConfigurationCommand => saveConfigurationCommand ?? (saveConfigurationCommand = new AsyncRelayCommand(SaveConfigurationAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand DeleteConfigurationCommand => deleteConfigurationCommand ?? (deleteConfigurationCommand = new AsyncRelayCommand(DeleteConfigurationAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CloseEditorCommand => closeEditorCommand ?? (closeEditorCommand = new RelayCommand(CloseEditor));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand StartMacroCommand => startMacroCommand ?? (startMacroCommand = new AsyncRelayCommand(StartMacroAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand StopMacroCommand => stopMacroCommand ?? (stopMacroCommand = new AsyncRelayCommand(StopMacroAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand StartVisionDebugCommand => startVisionDebugCommand ?? (startVisionDebugCommand = new AsyncRelayCommand(StartVisionDebugAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand StopVisionDebugCommand => stopVisionDebugCommand ?? (stopVisionDebugCommand = new AsyncRelayCommand(StopVisionDebugAsync));

	public MainViewModel()
		: this(new InMemoryConfigurationStore(), new DesignFishingMechanic())
	{
	}

	public MainViewModel(IConfigurationStore configurationStore, IFishingMechanic fishingMechanic, IMacroRunner? macroRunner = null, IScreenRegionSelector? regionSelector = null, IColorSelector? colorSelector = null, IUiTemplateLibrary? templateLibrary = null, IModelFilePicker? modelFilePicker = null, IImageFilePicker? imageFilePicker = null, IVisionDebugService? visionDebugService = null, IGameVisionOverlay? gameVisionOverlay = null, Action<GlobalHotkeyBinding, GlobalHotkeyBinding>? rebindHotkeys = null, IProfileTransferService? profileTransferService = null)
	{
		_configurationStore = configurationStore;
		_fishingMechanic = fishingMechanic;
		_macroRunner = macroRunner;
		_regionSelector = regionSelector;
		_colorSelector = colorSelector;
		_modelFilePicker = modelFilePicker;
		_imageFilePicker = imageFilePicker;
		_visionDebugService = visionDebugService;
		_gameVisionOverlay = gameVisionOverlay;
		_rebindHotkeys = rebindHotkeys;
		_profileTransferService = profileTransferService;
		_uiContext = SynchronizationContext.Current;
		LoadHotkeySettings();
		ActiveMechanicName = fishingMechanic.DisplayName;
		Configurations = new ObservableCollection<ConfigurationItemViewModel> { CreateItem(GameConfiguration.CreateStarterProfile()) };
		CfgBuilder = new CfgBuilderViewModel(Configurations, SaveAllAsync, regionSelector, colorSelector, templateLibrary);
		CfgBuilder.Refresh();
		if (_macroRunner != null)
		{
			_macroRunner.StateChanged += OnMacroRunnerStateChanged;
		}
		if (_visionDebugService != null)
		{
			_visionDebugService.FrameReady += OnVisionFrameReady;
		}
	}

	public (GlobalHotkeyBinding Start, GlobalHotkeyBinding Stop) GetConfiguredHotkeys()
	{
		int virtualKey = (TryParseFunctionKey(StartHotkey, out var key) ? key : 117);
		ushort key2;
		return new ValueTuple<GlobalHotkeyBinding, GlobalHotkeyBinding>(item2: new GlobalHotkeyBinding((ushort)(TryParseFunctionKey(StopHotkey, out key2) ? key2 : 118)), item1: new GlobalHotkeyBinding((ushort)virtualKey));
	}

	[RelayCommand]
	private void Navigate(string section)
	{
		CurrentSection = section;
		if (section == "Builder")
		{
			CfgBuilder.Refresh();
		}
		IsEditorOpen = false;
		StatusMessage = section + " opened";
	}

	[RelayCommand]
	private void OpenTemplates()
	{
		Directory.CreateDirectory(DataDirectory);
		Process.Start(new ProcessStartInfo
		{
			FileName = DataDirectory,
			UseShellExecute = true
		});
		StatusMessage = "Opened the PFMS configurations and templates folder";
	}

	[RelayCommand]
	private void ApplyHotkeys()
	{
		if (!TryParseFunctionKey(StartHotkey, out var key) || !TryParseFunctionKey(StopHotkey, out var key2) || key == key2)
		{
			StatusMessage = "Choose two different function keys from F1 through F12.";
			return;
		}
		try
		{
			_rebindHotkeys?.Invoke(new GlobalHotkeyBinding(key), new GlobalHotkeyBinding(key2));
			SaveHotkeySettings();
			StatusMessage = $"Hotkeys updated: {StartHotkey} start, {StopHotkey} stop.";
		}
		catch (Exception ex)
		{
			StatusMessage = "Hotkey update failed: " + ex.Message;
		}
	}

	public async Task InitializeAsync()
	{
		IReadOnlyList<GameConfiguration> readOnlyList;
		try
		{
			readOnlyList = await _configurationStore.LoadAsync();
		}
		catch (Exception ex)
		{
			RuntimeDiagnostics.Write($"Configuration load failed: {ex}");
			StatusMessage = "Could not load saved configurations: " + ex.Message;
			return;
		}
		if (readOnlyList.Count == 0)
		{
			return;
		}
		Configurations.Clear();
		foreach (GameConfiguration item in readOnlyList)
		{
			item.Fishing.Mode = ProfileMode.YoloAi;
			item.Fishing.EnsureDefaultClasses();
			Configurations.Add(CreateItem(item));
		}
		OnPropertyChanged("ConfigurationCount");
		CfgBuilder.Refresh();
		StatusMessage = $"Loaded {ConfigurationCount} saved configurations";
	}

	[RelayCommand]
	private async Task CreateConfigurationAsync()
	{
		ConfigurationItemViewModel configuration = CreateItem(GameConfiguration.CreateForMode(ProfileMode.YoloAi));
		Configurations.Add(configuration);
		OnPropertyChanged("ConfigurationCount");
		try
		{
			await SaveAllAsync();
			EditConfiguration(configuration);
			StatusMessage = "Created " + configuration.Name;
		}
		catch (Exception ex)
		{
			RuntimeDiagnostics.Write($"Configuration creation failed: {ex}");
			Configurations.Remove(configuration);
			SelectedConfiguration = null;
			IsEditorOpen = false;
			OnPropertyChanged("ConfigurationCount");
			StatusMessage = "Configuration creation failed: " + ex.Message;
		}
	}

	[RelayCommand]
	private async Task ExportProfileAsync(ConfigurationItemViewModel? configuration)
	{
		if (_profileTransferService == null || configuration == null)
		{
			StatusMessage = "Select a configuration to export.";
			return;
		}
		await _profileTransferService.ExportAsync(configuration.Model);
		StatusMessage = "Exported " + configuration.Name;
	}

	[RelayCommand]
	private async Task ImportProfileAsync()
	{
		if (_profileTransferService == null)
		{
			StatusMessage = "Configuration import is unavailable.";
			return;
		}
		try
		{
			GameConfiguration gameConfiguration = await _profileTransferService.ImportAsync();
			if (gameConfiguration != null)
			{
				gameConfiguration.Fishing.Mode = ProfileMode.YoloAi;
				gameConfiguration.Fishing.EnsureDefaultClasses();
				gameConfiguration.IsEnabled = false;
				gameConfiguration.UpdatedAtUtc = DateTimeOffset.UtcNow;
				gameConfiguration.Name = (string.IsNullOrWhiteSpace(gameConfiguration.Name) ? "Imported configuration" : gameConfiguration.Name);
				ConfigurationItemViewModel item = CreateItem(gameConfiguration);
				Configurations.Add(item);
				OnPropertyChanged("ConfigurationCount");
				await SaveAllAsync();
				EditConfiguration(item);
				StatusMessage = "Imported configuration " + item.Name + " as disabled";
			}
		}
		catch (Exception ex)
		{
			StatusMessage = "Import failed: " + ex.Message;
		}
	}

	private void EditConfiguration(ConfigurationItemViewModel configuration)
	{
		SelectedConfiguration = configuration;
		IsEditorOpen = true;
		StatusMessage = "Editing " + configuration.Name;
	}

	[RelayCommand]
	private async Task SaveConfigurationAsync()
	{
		if (SelectedConfiguration == null)
		{
			return;
		}
		try
		{
			SelectedConfiguration.Model.Fishing.ValidateBehaviorRules();
			string modelFilePath = SelectedConfiguration.Model.Fishing.ModelFilePath;
			if (File.Exists(modelFilePath))
			{
				SelectedConfiguration.ModelFilePath = ConfigurationBundle.StoreModel(modelFilePath);
			}
		}
		catch (InvalidOperationException ex)
		{
			StatusMessage = "Configuration rules are invalid: " + ex.Message;
			return;
		}
		SelectedConfiguration.Model.UpdatedAtUtc = DateTimeOffset.UtcNow;
		try
		{
			await SaveAllAsync();
		}
		catch (Exception ex2)
		{
			RuntimeDiagnostics.Write($"Configuration save failed: {ex2}");
			StatusMessage = "Configuration save failed: " + ex2.Message;
			return;
		}
		StatusMessage = "Saved " + SelectedConfiguration.Name;
		IsEditorOpen = false;
	}

	[RelayCommand]
	private async Task DeleteConfigurationAsync()
	{
		if (SelectedConfiguration != null)
		{
			string name = SelectedConfiguration.Name;
			Configurations.Remove(SelectedConfiguration);
			SelectedConfiguration = null;
			IsEditorOpen = false;
			OnPropertyChanged("ConfigurationCount");
			await SaveAllAsync();
			StatusMessage = "Deleted " + name;
		}
	}

	[RelayCommand]
	private void CloseEditor()
	{
		IsEditorOpen = false;
	}

	[RelayCommand]
	private Task StartMacroAsync()
	{
		return StartActiveMacroAsync();
	}

	[RelayCommand]
	private Task StopMacroAsync()
	{
		return StopActiveMacroAsync();
	}

	public async Task StartActiveMacroAsync()
	{
		await _fishingLifecycleGate.WaitAsync();
		try
		{
			if (!(_macroRunner?.IsRunning ?? false))
			{
				Task<FishingProcessResult> fishingTask = _fishingTask;
				if (fishingTask == null || fishingTask.IsCompleted)
				{
					ConfigurationItemViewModel configuration = Configurations.FirstOrDefault((ConfigurationItemViewModel candidate) => candidate.IsEnabled);
					if (configuration == null)
					{
						StatusMessage = "No configuration is enabled";
						return;
					}
					try
					{
						RuntimeDiagnostics.Write($"Run requested configuration='{configuration.Name}' model='{configuration.Model.Fishing.ModelFilePath}'");
						if (_visionDebugService?.IsRunning ?? false)
						{
							await StopVisionDebugAsync();
						}
						_fishingCancellation?.Dispose();
						_fishingCancellation = new CancellationTokenSource();
						_fishingTask = _fishingMechanic.ExecuteAsync(new FishingProcessContext
						{
							ConfigurationId = configuration.Model.Id.ToString(),
							Profile = configuration.Model.Fishing,
							Parameters = configuration.Model.Fishing.Parameters,
							Services = EmptyServiceProvider.Instance
						}, _fishingCancellation.Token);
						IsMacroRunning = true;
						StatusMessage = "Running " + configuration.Name + " YOLO engine (F7 to stop)";
						ObserveFishingCompletionAsync(_fishingTask);
					}
					catch (Exception ex)
					{
						IsMacroRunning = false;
						StatusMessage = "YOLO engine start failed: " + ex.Message;
					}
					return;
				}
			}
			StatusMessage = "A macro is already running";
		}
		finally
		{
			_fishingLifecycleGate.Release();
		}
	}

	[RelayCommand]
	private async Task StartVisionDebugAsync()
	{
		Task<FishingProcessResult> fishingTask = _fishingTask;
		if (fishingTask != null && !fishingTask.IsCompleted)
		{
			VisionSummary = "Stop the running profile before starting Debug Vision.";
			return;
		}
		if (_visionDebugService == null)
		{
			VisionSummary = "Vision preview service is unavailable.";
			return;
		}
		ConfigurationItemViewModel configuration = SelectedConfiguration ?? Configurations.FirstOrDefault((ConfigurationItemViewModel candidate) => candidate.IsEnabled) ?? Configurations.FirstOrDefault();
		if (configuration == null)
		{
			VisionSummary = "Create a configuration first.";
			return;
		}
		try
		{
			await _visionDebugService.StartAsync(configuration.Model.Fishing);
			if (ShowGameVisionOverlay)
			{
				_gameVisionOverlay?.Show(configuration.Model.Fishing);
			}
			IsDebugVisionRunning = true;
			VisionSummary = "Previewing " + configuration.Name;
			StatusMessage = "Vision preview started for " + configuration.Name;
		}
		catch (Exception ex)
		{
			IsDebugVisionRunning = false;
			VisionSummary = "Preview failed: " + ex.Message;
		}
	}

	[RelayCommand]
	private async Task StopVisionDebugAsync()
	{
		if (_visionDebugService != null)
		{
			await _visionDebugService.StopAsync();
		}
		_gameVisionOverlay?.Hide();
		IsDebugVisionRunning = false;
		StatusMessage = "Vision preview stopped";
	}

	public async Task StopActiveMacroAsync()
	{
		await _fishingLifecycleGate.WaitAsync();
		try
		{
			Task<FishingProcessResult> fishingTask = _fishingTask;
			if (fishingTask != null && !fishingTask.IsCompleted)
			{
				try
				{
					_fishingCancellation?.Cancel();
					FishingProcessResult fishingProcessResult = await fishingTask.ConfigureAwait(continueOnCapturedContext: true);
					IsMacroRunning = false;
					StatusMessage = fishingProcessResult.Message;
					return;
				}
				catch (Exception ex)
				{
					RuntimeDiagnostics.Write($"Stop failed: {ex}");
					IsMacroRunning = false;
					StatusMessage = "Profile engine stop failed: " + ex.Message;
					return;
				}
				finally
				{
					_gameVisionOverlay?.Hide();
					if (_fishingTask == fishingTask)
					{
						_fishingTask = null;
						_fishingCancellation?.Dispose();
						_fishingCancellation = null;
					}
				}
			}
			if (_macroRunner == null || !_macroRunner.IsRunning)
			{
				IsMacroRunning = false;
				StatusMessage = "No macro is running";
				return;
			}
			try
			{
				MacroRunResult macroRunResult = await _macroRunner.StopAsync();
				IsMacroRunning = false;
				StatusMessage = $"{macroRunResult.Message} {macroRunResult.ExecutedActions} actions executed";
			}
			catch (Exception ex2)
			{
				IsMacroRunning = false;
				StatusMessage = "Macro stop failed: " + ex2.Message;
			}
		}
		finally
		{
			_fishingLifecycleGate.Release();
		}
	}

	private ConfigurationItemViewModel CreateItem(GameConfiguration configuration)
	{
		return new ConfigurationItemViewModel(configuration, EditConfiguration, SaveAllAsync, _regionSelector, _colorSelector, _modelFilePicker, _imageFilePicker, Configurations);
	}

	private async Task SaveAllAsync()
	{
		await _configurationSaveGate.WaitAsync();
		try
		{
			GameConfiguration[] array = Configurations.Select((ConfigurationItemViewModel configuration) => configuration.Model).ToArray();
			GameConfiguration[] array2 = array;
			foreach (GameConfiguration gameConfiguration in array2)
			{
				ScreenRegion primaryRegion = gameConfiguration.Fishing.Rod.PrimaryRegion;
				RuntimeDiagnostics.Write($"SaveAll writing configuration='{gameConfiguration.Name}' id={gameConfiguration.Id} region={primaryRegion.X},{primaryRegion.Y},{primaryRegion.Width}x{primaryRegion.Height}");
			}
			await _configurationStore.SaveAsync(array);
		}
		finally
		{
			_configurationSaveGate.Release();
		}
	}

	private void OnMacroRunnerStateChanged(object? sender, MacroRunnerStateChangedEventArgs args)
	{
		if (_uiContext == null || SynchronizationContext.Current == _uiContext)
		{
			ApplyState();
			return;
		}
		_uiContext.Post(delegate
		{
			ApplyState();
		}, null);
		void ApplyState()
		{
			IsMacroRunning = args.IsRunning;
			if ((object)args.Result != null)
			{
				StatusMessage = $"{args.Result.Message} {args.Result.ExecutedActions} actions executed";
			}
		}
	}

	private async Task ObserveFishingCompletionAsync(Task<FishingProcessResult> task)
	{
		FishingProcessResult result = null;
		Exception error = null;
		try
		{
			result = await task.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			error = ex;
		}
		if (_uiContext == null || SynchronizationContext.Current == _uiContext)
		{
			ApplyState();
			return;
		}
		_uiContext.Post(delegate
		{
			ApplyState();
		}, null);
		void ApplyState()
		{
			if (_fishingTask == task)
			{
				IsMacroRunning = false;
				StatusMessage = ((error != null) ? ("Profile engine failed: " + error.Message) : (result?.Message ?? "Profile fishing engine completed."));
				_gameVisionOverlay?.Hide();
				_fishingTask = null;
				_fishingCancellation?.Dispose();
				_fishingCancellation = null;
			}
		}
	}

	private void OnVisionFrameReady(object? sender, VisionDebugFrame frame)
	{
		if (_uiContext == null || SynchronizationContext.Current == _uiContext)
		{
			ApplyFrame();
			return;
		}
		_uiContext.Post(delegate
		{
			ApplyFrame();
		}, null);
		void ApplyFrame()
		{
			if (frame.PngData.Length != 0)
			{
				using MemoryStream stream = new MemoryStream(frame.PngData);
				Bitmap visionPreview = new Bitmap(stream);
				VisionPreview?.Dispose();
				VisionPreview = visionPreview;
			}
			VisionDetectionCount = frame.DetectionCount;
			VisionSummary = ((frame.Error == null) ? frame.Summary : ("Error: " + frame.Error));
			VisionBarStrip = frame.BarStrip;
			if (frame.Error != null)
			{
				IsDebugVisionRunning = false;
			}
			_gameVisionOverlay?.Update(frame);
		}
	}

	private void LoadHotkeySettings()
	{
		try
		{
			if (File.Exists(HotkeySettingsPath))
			{
				HotkeySettings hotkeySettings = JsonSerializer.Deserialize<HotkeySettings>(File.ReadAllText(HotkeySettingsPath));
				if ((object)hotkeySettings != null)
				{
					StartHotkey = hotkeySettings.StartHotkey;
					StopHotkey = hotkeySettings.StopHotkey;
				}
			}
		}
		catch
		{
		}
	}

	private void SaveHotkeySettings()
	{
		Directory.CreateDirectory(DataDirectory);
		HotkeySettings value = new HotkeySettings(StartHotkey, StopHotkey);
		File.WriteAllText(HotkeySettingsPath, JsonSerializer.Serialize(value));
	}

	private static bool TryParseFunctionKey(string text, out ushort key)
	{
		key = 0;
		int result = default(int);
		bool flag = !text.StartsWith("F", StringComparison.OrdinalIgnoreCase) || !int.TryParse(text.Substring(1), out result);
		if (!flag)
		{
			bool flag2 = ((result < 1 || result > 24) ? true : false);
			flag = flag2;
		}
		if (flag)
		{
			return false;
		}
		key = (ushort)(111 + result);
		return true;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentSectionChanged(string value)
	{
		OnPropertyChanged("IsOverview");
		OnPropertyChanged("IsConfigurations");
		OnPropertyChanged("IsBuilder");
		OnPropertyChanged("IsVision");
		OnPropertyChanged("IsSettings");
	}
}

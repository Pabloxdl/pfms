using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pfm.Core.Configuration;
using Pfm.Core.Macros;
using Pfm.Core.Vision;

namespace Pfm.ViewModels;

public class CfgBuilderViewModel : ViewModelBase
{
	private readonly Func<Task> _save;

	private readonly IScreenRegionSelector? _regionSelector;

	private readonly IColorSelector? _colorSelector;

	private readonly IUiTemplateLibrary? _templateLibrary;

	[ObservableProperty]
	private ConfigurationItemViewModel? _selectedConfiguration;

	[ObservableProperty]
	private MacroBuilderItemViewModel? _selectedMacro;

	[ObservableProperty]
	private ActionNodeViewModel? _selectedAction;

	[ObservableProperty]
	private UiTemplateAsset? _selectedTemplate;

	[ObservableProperty]
	private string _statusMessage = "Select a profile and build its fishing process.";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? newMacroCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? deleteMacroCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? applySimpleRodTemplateCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? applyAdvancedRodTemplateCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addPixelCheckCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addPixelClickCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? importTemplateCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addTemplateMatchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addKeyPressCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addMouseInputCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addDelayCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addEndCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? saveCommand;

	public ObservableCollection<ConfigurationItemViewModel> Configurations { get; }

	public ObservableCollection<MacroBuilderItemViewModel> Macros { get; } = new ObservableCollection<MacroBuilderItemViewModel>();

	public ObservableCollection<UiTemplateAsset> UiTemplates { get; } = new ObservableCollection<UiTemplateAsset>();

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
				OnSelectedConfigurationChanged(value);
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedConfiguration);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public MacroBuilderItemViewModel? SelectedMacro
	{
		get
		{
			return _selectedMacro;
		}
		set
		{
			if (!EqualityComparer<MacroBuilderItemViewModel>.Default.Equals(_selectedMacro, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedMacro);
				_selectedMacro = value;
				OnSelectedMacroChanged(value);
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedMacro);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ActionNodeViewModel? SelectedAction
	{
		get
		{
			return _selectedAction;
		}
		set
		{
			if (!EqualityComparer<ActionNodeViewModel>.Default.Equals(_selectedAction, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedAction);
				_selectedAction = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedAction);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public UiTemplateAsset? SelectedTemplate
	{
		get
		{
			return _selectedTemplate;
		}
		set
		{
			if (!EqualityComparer<UiTemplateAsset>.Default.Equals(_selectedTemplate, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedTemplate);
				_selectedTemplate = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedTemplate);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand NewMacroCommand => newMacroCommand ?? (newMacroCommand = new RelayCommand(NewMacro));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand DeleteMacroCommand => deleteMacroCommand ?? (deleteMacroCommand = new RelayCommand(DeleteMacro));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ApplySimpleRodTemplateCommand => applySimpleRodTemplateCommand ?? (applySimpleRodTemplateCommand = new RelayCommand(ApplySimpleRodTemplate));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ApplyAdvancedRodTemplateCommand => applyAdvancedRodTemplateCommand ?? (applyAdvancedRodTemplateCommand = new RelayCommand(ApplyAdvancedRodTemplate));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddPixelCheckCommand => addPixelCheckCommand ?? (addPixelCheckCommand = new RelayCommand(AddPixelCheck));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddPixelClickCommand => addPixelClickCommand ?? (addPixelClickCommand = new RelayCommand(AddPixelClick));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ImportTemplateCommand => importTemplateCommand ?? (importTemplateCommand = new AsyncRelayCommand(ImportTemplateAsync));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddTemplateMatchCommand => addTemplateMatchCommand ?? (addTemplateMatchCommand = new RelayCommand(AddTemplateMatch));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddKeyPressCommand => addKeyPressCommand ?? (addKeyPressCommand = new RelayCommand(AddKeyPress));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddMouseInputCommand => addMouseInputCommand ?? (addMouseInputCommand = new RelayCommand(AddMouseInput));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddDelayCommand => addDelayCommand ?? (addDelayCommand = new RelayCommand(AddDelay));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddEndCommand => addEndCommand ?? (addEndCommand = new RelayCommand(AddEnd));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SaveCommand => saveCommand ?? (saveCommand = new AsyncRelayCommand(SaveAsync));

	public CfgBuilderViewModel(ObservableCollection<ConfigurationItemViewModel> configurations, Func<Task> save, IScreenRegionSelector? regionSelector, IColorSelector? colorSelector, IUiTemplateLibrary? templateLibrary)
	{
		Configurations = configurations;
		_save = save;
		_regionSelector = regionSelector;
		_colorSelector = colorSelector;
		_templateLibrary = templateLibrary;
	}

	public void Refresh()
	{
		if (SelectedConfiguration == null || !Configurations.Contains(SelectedConfiguration))
		{
			SelectedConfiguration = Configurations.FirstOrDefault();
		}
		LoadMacros();
	}

	public void OpenTemplateLibrary()
	{
		Refresh();
		StatusMessage = "UI image library ready. Import an image, select it, then add a Find image node.";
	}

	[RelayCommand]
	private void NewMacro()
	{
		if (SelectedConfiguration == null)
		{
			StatusMessage = "Create or select a configuration first.";
			return;
		}
		MacroDefinition macroDefinition = new MacroDefinition
		{
			Name = "Custom fishing process",
			IsEnabled = true
		};
		SelectedConfiguration.Model.Macros.Add(macroDefinition);
		SelectedConfiguration.RefreshMetrics();
		MacroBuilderItemViewModel macroBuilderItemViewModel = CreateMacro(macroDefinition);
		Macros.Add(macroBuilderItemViewModel);
		SelectedMacro = macroBuilderItemViewModel;
		StatusMessage = "Created a blank macro pipeline.";
	}

	[RelayCommand]
	private void DeleteMacro()
	{
		if (SelectedConfiguration != null && SelectedMacro != null)
		{
			SelectedConfiguration.Model.Macros.Remove(SelectedMacro.Model);
			SelectedConfiguration.RefreshMetrics();
			Macros.Remove(SelectedMacro);
			SelectedMacro = Macros.FirstOrDefault();
			StatusMessage = "Macro removed. Save the configuration to confirm.";
		}
	}

	[RelayCommand]
	private void ApplySimpleRodTemplate()
	{
		MacroBuilderItemViewModel macroBuilderItemViewModel = EnsureMacro("Simple rod process");
		if (macroBuilderItemViewModel != null)
		{
			macroBuilderItemViewModel.ReplaceWith(CreateSimpleRodActions());
			StatusMessage = "Simple cast → wait for bite → minigame → recast template created. Calibrate its colors and regions.";
		}
	}

	[RelayCommand]
	private void ApplyAdvancedRodTemplate()
	{
		MacroBuilderItemViewModel macroBuilderItemViewModel = EnsureMacro("Advanced rhythm rod process");
		if (macroBuilderItemViewModel != null)
		{
			macroBuilderItemViewModel.ReplaceWith(CreateAdvancedRodActions());
			StatusMessage = "Advanced template created with rhythm detection interleaved in the minigame loop.";
		}
	}

	[RelayCommand]
	private void AddPixelCheck()
	{
		AddAction(new PixelColorCheckAction
		{
			Name = "New pixel rule",
			Phase = MacroPhase.Custom,
			Region = new ScreenRegion
			{
				X = 760,
				Y = 480,
				Width = 400,
				Height = 180
			},
			ExpectedColor = new PixelColor(66, 174, byte.MaxValue),
			ColorTolerance = 28,
			MinimumMatchingPixels = 3
		});
	}

	[RelayCommand]
	private void AddPixelClick()
	{
		AddAction(new PixelColorClickAction
		{
			Name = "Find and click colored target",
			Phase = MacroPhase.Custom,
			Region = new ScreenRegion
			{
				X = 700,
				Y = 400,
				Width = 520,
				Height = 300
			},
			ExpectedColor = new PixelColor(66, 174, byte.MaxValue),
			ColorTolerance = 28,
			MinimumMatchingPixels = 3,
			RequiredMatchRatio = 0.01
		});
	}

	[RelayCommand]
	private async Task ImportTemplateAsync()
	{
		if (SelectedConfiguration == null || _templateLibrary == null)
		{
			StatusMessage = "Select a configuration before importing a UI image.";
			return;
		}
		UiTemplateAsset uiTemplateAsset = await _templateLibrary.ImportAsync();
		if (uiTemplateAsset != null)
		{
			SelectedConfiguration.Model.UiTemplates.Add(uiTemplateAsset);
			UiTemplates.Add(uiTemplateAsset);
			SelectedTemplate = uiTemplateAsset;
			StatusMessage = "Imported " + uiTemplateAsset.Name + ". Add a Find image node to use it.";
		}
	}

	[RelayCommand]
	private void AddTemplateMatch()
	{
		if (SelectedTemplate == null)
		{
			StatusMessage = "Import and select an image template first.";
			return;
		}
		AddAction(new TemplateImageMatchAction
		{
			Name = "Find and click: " + SelectedTemplate.Name,
			Phase = MacroPhase.Custom,
			TemplateId = SelectedTemplate.Id,
			TemplatePath = SelectedTemplate.FilePath,
			SimilarityThreshold = SelectedTemplate.SimilarityThreshold,
			Region = ShakeRegion()
		});
	}

	[RelayCommand]
	private void AddKeyPress()
	{
		AddAction(new KeyPressAction
		{
			Name = "New key press",
			Phase = MacroPhase.Custom
		});
	}

	[RelayCommand]
	private void AddMouseInput()
	{
		AddAction(new MouseButtonAction
		{
			Name = "New mouse input",
			Phase = MacroPhase.Custom
		});
	}

	[RelayCommand]
	private void AddDelay()
	{
		AddAction(new DelayAction
		{
			Name = "New delay",
			Phase = MacroPhase.Custom,
			DurationMs = 100
		});
	}

	[RelayCommand]
	private void AddEnd()
	{
		AddAction(new EndAction
		{
			Name = "Finish process",
			Phase = MacroPhase.Custom
		});
	}

	[RelayCommand]
	private async Task SaveAsync()
	{
		if (SelectedConfiguration == null)
		{
			StatusMessage = "Nothing to save.";
			return;
		}
		SelectedConfiguration.Model.UpdatedAtUtc = DateTimeOffset.UtcNow;
		await _save();
		StatusMessage = "CFG pipeline saved. Use F6 to run the first enabled macro.";
	}

	private void LoadMacros()
	{
		Macros.Clear();
		if (SelectedConfiguration == null)
		{
			SelectedMacro = null;
			UiTemplates.Clear();
			SelectedTemplate = null;
			return;
		}
		foreach (MacroDefinition macro in SelectedConfiguration.Model.Macros)
		{
			Macros.Add(CreateMacro(macro));
		}
		SelectedMacro = Macros.FirstOrDefault();
		UiTemplates.Clear();
		foreach (UiTemplateAsset uiTemplate in SelectedConfiguration.Model.UiTemplates)
		{
			UiTemplates.Add(uiTemplate);
		}
		SelectedTemplate = UiTemplates.FirstOrDefault();
	}

	private MacroBuilderItemViewModel CreateMacro(MacroDefinition model)
	{
		return new MacroBuilderItemViewModel(model, SelectAction, _regionSelector, _colorSelector);
	}

	private MacroBuilderItemViewModel? EnsureMacro(string name)
	{
		if (SelectedMacro != null)
		{
			SelectedMacro.Name = name;
			return SelectedMacro;
		}
		NewMacro();
		if (SelectedMacro == null)
		{
			StatusMessage = "Create or select a configuration before adding a macro.";
			return null;
		}
		SelectedMacro.Name = name;
		return SelectedMacro;
	}

	private void AddAction(MacroAction action)
	{
		MacroBuilderItemViewModel macroBuilderItemViewModel = EnsureMacro("Custom fishing process");
		if (macroBuilderItemViewModel != null)
		{
			macroBuilderItemViewModel.Add(action);
			StatusMessage = "Added " + action.Name + ".";
		}
	}

	private void SelectAction(ActionNodeViewModel? action)
	{
		SelectedAction = action;
	}

	private static IEnumerable<MacroAction> CreateSimpleRodActions()
	{
		return new _003C_003Ez__ReadOnlyArray<MacroAction>(new MacroAction[7]
		{
			new MouseButtonAction
			{
				Name = "Cast: hold left mouse for 600 ms",
				Phase = MacroPhase.Cast,
				ActionKind = MacroMouseActionKind.Click,
				HoldMs = 600,
				OnSuccessTarget = 1
			},
			new PixelColorCheckAction
			{
				Name = "Wait for bite: detect target color",
				Phase = MacroPhase.WaitForBite,
				Region = ShakeRegion(),
				ExpectedColor = new PixelColor(66, 174, byte.MaxValue),
				ColorTolerance = 28,
				MinimumMatchingPixels = 3,
				RequiredMatchRatio = 0.005,
				OnSuccessTarget = 2,
				OnFailTarget = 1
			},
			new DelayAction
			{
				Name = "Minigame entry: brief input lock 200 ms",
				Phase = MacroPhase.Fishing,
				DurationMs = 200,
				OnSuccessTarget = 3
			},
			new PixelColorCheckAction
			{
				Name = "Minigame: detect control bar",
				Phase = MacroPhase.Fishing,
				Region = FishingRegion(),
				ExpectedColor = new PixelColor(byte.MaxValue, byte.MaxValue, byte.MaxValue),
				ColorTolerance = 24,
				MinimumMatchingPixels = 6,
				RequiredMatchRatio = 0.02,
				OnSuccessTarget = 4,
				OnFailTarget = 5
			},
			new MouseButtonAction
			{
				Name = "Hold mouse (track bar)",
				Phase = MacroPhase.Fishing,
				ActionKind = MacroMouseActionKind.Down,
				OnSuccessTarget = 3
			},
			new MouseButtonAction
			{
				Name = "Release mouse",
				Phase = MacroPhase.Fishing,
				ActionKind = MacroMouseActionKind.Up,
				OnSuccessTarget = 6
			},
			new DelayAction
			{
				Name = "Recast delay: 1500 ms",
				Phase = MacroPhase.Cast,
				DurationMs = 1500,
				OnSuccessTarget = 1
			}
		});
	}

	private static IEnumerable<MacroAction> CreateAdvancedRodActions()
	{
		return new _003C_003Ez__ReadOnlyArray<MacroAction>(new MacroAction[9]
		{
			new MouseButtonAction
			{
				Name = "Cast: hold left mouse for 600 ms",
				Phase = MacroPhase.Cast,
				ActionKind = MacroMouseActionKind.Click,
				HoldMs = 600,
				OnSuccessTarget = 1
			},
			new PixelColorCheckAction
			{
				Name = "Wait for bite: detect target color",
				Phase = MacroPhase.WaitForBite,
				Region = ShakeRegion(),
				ExpectedColor = new PixelColor(66, 174, byte.MaxValue),
				ColorTolerance = 28,
				MinimumMatchingPixels = 3,
				RequiredMatchRatio = 0.005,
				OnSuccessTarget = 2,
				OnFailTarget = 1
			},
			new DelayAction
			{
				Name = "Minigame entry: brief input lock 200 ms",
				Phase = MacroPhase.Fishing,
				DurationMs = 200,
				OnSuccessTarget = 3
			},
			new PixelColorCheckAction
			{
				Name = "Minigame: detect control bar",
				Phase = MacroPhase.Fishing,
				Region = FishingRegion(),
				ExpectedColor = new PixelColor(byte.MaxValue, byte.MaxValue, byte.MaxValue),
				ColorTolerance = 24,
				MinimumMatchingPixels = 6,
				RequiredMatchRatio = 0.02,
				OnSuccessTarget = 4,
				OnFailTarget = 7
			},
			new MouseButtonAction
			{
				Name = "Hold mouse (track bar)",
				Phase = MacroPhase.Fishing,
				ActionKind = MacroMouseActionKind.Down,
				OnSuccessTarget = 5
			},
			new PixelColorCheckAction
			{
				Name = "Detect rhythm prompt",
				Phase = MacroPhase.RodMechanic,
				Region = RhythmRegion(),
				ExpectedColor = new PixelColor(byte.MaxValue, 236, 130),
				ColorTolerance = 24,
				RequiredMatchRatio = 0.035,
				OnSuccessTarget = 6,
				OnFailTarget = 3
			},
			new KeyPressAction
			{
				Name = "Hit rhythm key",
				Phase = MacroPhase.RodMechanic,
				VirtualKey = 32,
				DelayMs = 8,
				HoldMs = 16,
				OnSuccessTarget = 3
			},
			new MouseButtonAction
			{
				Name = "Release mouse",
				Phase = MacroPhase.Fishing,
				ActionKind = MacroMouseActionKind.Up,
				OnSuccessTarget = 8
			},
			new DelayAction
			{
				Name = "Recast delay: 1500 ms",
				Phase = MacroPhase.Cast,
				DurationMs = 1500,
				OnSuccessTarget = 1
			}
		});
	}

	private static ScreenRegion ShakeRegion()
	{
		return new ScreenRegion
		{
			X = 700,
			Y = 400,
			Width = 520,
			Height = 300
		};
	}

	private static ScreenRegion FishingRegion()
	{
		return new ScreenRegion
		{
			X = 640,
			Y = 820,
			Width = 640,
			Height = 90
		};
	}

	private static ScreenRegion RhythmRegion()
	{
		return new ScreenRegion
		{
			X = 760,
			Y = 510,
			Width = 400,
			Height = 180
		};
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedConfigurationChanged(ConfigurationItemViewModel? value)
	{
		LoadMacros();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedMacroChanged(MacroBuilderItemViewModel? value)
	{
		if (value == null)
		{
			SelectAction(null);
		}
		else
		{
			value.SelectFirstAction();
		}
	}
}

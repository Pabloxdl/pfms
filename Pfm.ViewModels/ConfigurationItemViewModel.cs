using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;
using Pfm.Services;
using Pfm.Services.Configuration;
using Pfm.Services.Vision;

namespace Pfm.ViewModels;

public sealed class ConfigurationItemViewModel : ViewModelBase
{
	private readonly Func<Task>? _save;

	private readonly IScreenRegionSelector? _regionSelector;

	private readonly IColorSelector? _colorSelector;

	private readonly IModelFilePicker? _modelFilePicker;

	private readonly IImageFilePicker? _imageFilePicker;

	private readonly ObservableCollection<ConfigurationItemViewModel>? _siblings;

	private Bitmap? _coverImage;

	private readonly ObservableCollection<DetectionClassViewModel> _customClassViewModels;

	private string _steeringValidationMessage = "Rules not validated";

	public GameConfiguration Model { get; }

	public IRelayCommand EditCommand { get; }

	public IAsyncRelayCommand ToggleEnabledCommand { get; }

	public IAsyncRelayCommand PickFishingColorCommand { get; }

	public IAsyncRelayCommand SelectFishingScanAreaCommand { get; }

	public IAsyncRelayCommand BrowseModelFileCommand { get; }

	public IRelayCommand RemoveModelCommand { get; }

	public IAsyncRelayCommand BrowseCoverImageCommand { get; }

	public IAsyncRelayCommand SelectShakeScanAreaCommand { get; }

	public IAsyncRelayCommand PickShakeColorCommand { get; }

	public IAsyncRelayCommand SelectProgressScanAreaCommand { get; }

	public IAsyncRelayCommand PickProgressColorCommand { get; }

	public IRelayCommand AddCustomClassCommand { get; }

	public IRelayCommand<DetectionClassViewModel> RemoveCustomClassCommand { get; }

	public IRelayCommand ValidateSteeringCommand { get; }

	public Bitmap? CoverImage => _coverImage;

	public string CoverImagePath
	{
		get
		{
			return Model.CoverImagePath;
		}
		set
		{
			string text = value ?? string.Empty;
			if (!(Model.CoverImagePath == text))
			{
				Model.CoverImagePath = text;
				OnPropertyChanged("CoverImagePath");
				LoadCoverImage();
			}
		}
	}

	public string Name
	{
		get
		{
			return Model.Name;
		}
		set
		{
			if (!(Model.Name == value))
			{
				Model.Name = value;
				OnPropertyChanged("Name");
			}
		}
	}

	public string Description
	{
		get
		{
			return Model.Description;
		}
		set
		{
			if (!(Model.Description == value))
			{
				Model.Description = value;
				OnPropertyChanged("Description");
			}
		}
	}

	public bool IsEnabled
	{
		get
		{
			return Model.IsEnabled;
		}
		set
		{
			if (Model.IsEnabled == value)
			{
				return;
			}
			if (value && _siblings != null)
			{
				foreach (ConfigurationItemViewModel sibling in _siblings)
				{
					if (sibling != this && sibling.IsEnabled)
					{
						sibling.IsEnabled = false;
					}
				}
			}
			Model.IsEnabled = value;
			OnPropertyChanged("IsEnabled");
			OnPropertyChanged("IsDisabled");
		}
	}

	public bool IsDisabled => !IsEnabled;

	public ProfileMode Mode
	{
		get
		{
			return Model.Fishing.Mode;
		}
		set
		{
			if (Model.Fishing.Mode != value)
			{
				Model.Fishing.Mode = value;
				OnPropertyChanged("Mode");
				OnPropertyChanged("UseProfileEngine");
				OnPropertyChanged("UseAiDetectionMode");
			}
		}
	}

	public bool UseProfileEngine
	{
		get
		{
			return Mode != ProfileMode.CfgBuilder;
		}
		set
		{
			if (value && Mode == ProfileMode.CfgBuilder)
			{
				Mode = ProfileMode.PdPixel;
			}
			else if (!value)
			{
				Mode = ProfileMode.CfgBuilder;
			}
		}
	}

	public bool UseAiDetectionMode
	{
		get
		{
			return Mode == ProfileMode.YoloAi;
		}
		set
		{
			if (value)
			{
				Mode = ProfileMode.YoloAi;
			}
			else if (Mode == ProfileMode.YoloAi)
			{
				Mode = ProfileMode.PdPixel;
			}
		}
	}

	public string ModelFilePath
	{
		get
		{
			return Model.Fishing.ModelFilePath;
		}
		set
		{
			string text = value ?? string.Empty;
			if (!(Model.Fishing.ModelFilePath == text))
			{
				Model.Fishing.ModelFilePath = text;
				OnPropertyChanged("ModelFilePath");
				OnPropertyChanged("ManagedModelName");
				OnPropertyChanged("HasModel");
			}
		}
	}

	public string ManagedModelName
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(ModelFilePath))
			{
				return Path.GetFileName(ModelFilePath);
			}
			return "No model loaded";
		}
	}

	public bool HasModel => !string.IsNullOrWhiteSpace(ModelFilePath);

	public double ConfidenceThreshold
	{
		get
		{
			return Model.Fishing.ConfidenceThreshold;
		}
		set
		{
			double num = (double.IsFinite(value) ? Math.Clamp(value, 0.01, 1.0) : 0.5);
			if (Model.Fishing.ConfidenceThreshold != num)
			{
				Model.Fishing.ConfidenceThreshold = num;
				OnPropertyChanged("ConfidenceThreshold");
			}
		}
	}

	public int AiTargetClassId
	{
		get
		{
			return Model.Fishing.TargetClassId;
		}
		set
		{
			int num = Math.Max(0, value);
			if (Model.Fishing.TargetClassId != num)
			{
				Model.Fishing.TargetClassId = num;
				OnPropertyChanged("AiTargetClassId");
			}
		}
	}

	public int AiPlayerBarClassId
	{
		get
		{
			return Model.Fishing.PlayerBarClassId;
		}
		set
		{
			int num = Math.Max(0, value);
			if (Model.Fishing.PlayerBarClassId != num)
			{
				Model.Fishing.PlayerBarClassId = num;
				OnPropertyChanged("AiPlayerBarClassId");
			}
		}
	}

	public int AiProgressClassId
	{
		get
		{
			return Model.Fishing.ProgressClassId;
		}
		set
		{
			int num = Math.Max(-1, value);
			if (Model.Fishing.ProgressClassId != num)
			{
				Model.Fishing.ProgressClassId = num;
				OnPropertyChanged("AiProgressClassId");
			}
		}
	}

	public ObservableCollection<DetectionClassViewModel> CustomClasses => _customClassViewModels;

	public IReadOnlyList<DetectionBehavior> DetectionBehaviorOptions { get; } = (from value in Enum.GetValues<DetectionBehavior>()
		where value != DetectionBehavior.Unassigned
		select value).ToArray();

	public IReadOnlyList<FishingMode> FishingModeOptions { get; } = Enum.GetValues<FishingMode>().ToArray();

	public FishingMode FishingMode
	{
		get
		{
			return Model.Fishing.FishingMode;
		}
		set
		{
			if (Model.Fishing.FishingMode != value)
			{
				Model.Fishing.FishingMode = value;
				OnPropertyChanged("FishingMode");
				OnPropertyChanged("IsTimingClick");
				OnPropertyChanged("IsBarControl");
			}
		}
	}

	public bool IsTimingClick => FishingMode == FishingMode.TimingClick;

	public bool IsBarControl => FishingMode == FishingMode.BarControl;

	public string TriggerFormula
	{
		get
		{
			return Model.Fishing.TriggerFormula;
		}
		set
		{
			string text = value ?? string.Empty;
			if (!(Model.Fishing.TriggerFormula == text))
			{
				Model.Fishing.TriggerFormula = text;
				OnPropertyChanged("TriggerFormula");
			}
		}
	}

	public int ClickCooldownMs
	{
		get
		{
			return Model.Fishing.ClickCooldownMs;
		}
		set
		{
			int num = Math.Max(10, value);
			if (Model.Fishing.ClickCooldownMs != num)
			{
				Model.Fishing.ClickCooldownMs = num;
				OnPropertyChanged("ClickCooldownMs");
			}
		}
	}

	public int ClickHoldDurationMs
	{
		get
		{
			return Model.Fishing.ClickHoldDurationMs;
		}
		set
		{
			int num = Math.Max(10, value);
			if (Model.Fishing.ClickHoldDurationMs != num)
			{
				Model.Fishing.ClickHoldDurationMs = num;
				OnPropertyChanged("ClickHoldDurationMs");
			}
		}
	}

	public string SteeringFormula
	{
		get
		{
			return Model.Fishing.SteeringFormula;
		}
		set
		{
			string text = value ?? string.Empty;
			if (Model.Fishing.SteeringFormula != text)
			{
				Model.Fishing.SteeringFormula = text;
				OnPropertyChanged("SteeringFormula");
			}
		}
	}

	public string SteeringValidationMessage
	{
		get
		{
			return _steeringValidationMessage;
		}
		internal set
		{
			if (!(_steeringValidationMessage == value))
			{
				_steeringValidationMessage = value;
				OnPropertyChanged("SteeringValidationMessage");
			}
		}
	}

	public int FishingRed
	{
		get
		{
			return Model.Fishing.Rod.Slider.TargetColor.R;
		}
		set
		{
			SetTargetColor((byte)Math.Clamp(value, 0, 255), FishingGreen, FishingBlue);
		}
	}

	public int FishingGreen
	{
		get
		{
			return Model.Fishing.Rod.Slider.TargetColor.G;
		}
		set
		{
			SetTargetColor(FishingRed, (byte)Math.Clamp(value, 0, 255), FishingBlue);
		}
	}

	public int FishingBlue
	{
		get
		{
			return Model.Fishing.Rod.Slider.TargetColor.B;
		}
		set
		{
			SetTargetColor(FishingRed, FishingGreen, (byte)Math.Clamp(value, 0, 255));
		}
	}

	public int FishingColorTolerance
	{
		get
		{
			return Model.Fishing.Rod.Slider.ColorTolerance;
		}
		set
		{
			byte b = (byte)Math.Clamp(value, 0, 255);
			if (Model.Fishing.Rod.Slider.ColorTolerance != b)
			{
				Model.Fishing.Rod.Slider.ColorTolerance = b;
				OnPropertyChanged("FishingColorTolerance");
			}
		}
	}

	public double FishingKp
	{
		get
		{
			return Model.Fishing.Rod.Slider.Kp;
		}
		set
		{
			double num = (double.IsFinite(value) ? Math.Max(0.0, value) : 0.0);
			if (Model.Fishing.Rod.Slider.Kp != num)
			{
				Model.Fishing.Rod.Slider.Kp = num;
				OnPropertyChanged("FishingKp");
			}
		}
	}

	public double FishingKd
	{
		get
		{
			return Model.Fishing.Rod.Slider.Kd;
		}
		set
		{
			double num = (double.IsFinite(value) ? Math.Max(0.0, value) : 0.0);
			if (Model.Fishing.Rod.Slider.Kd != num)
			{
				Model.Fishing.Rod.Slider.Kd = num;
				OnPropertyChanged("FishingKd");
			}
		}
	}

	public int FishingDeadZonePixels
	{
		get
		{
			return Model.Fishing.Rod.Slider.DeadZonePixels;
		}
		set
		{
			int num = Math.Max(0, value);
			if (Model.Fishing.Rod.Slider.DeadZonePixels != num)
			{
				Model.Fishing.Rod.Slider.DeadZonePixels = num;
				OnPropertyChanged("FishingDeadZonePixels");
			}
		}
	}

	public int CastHoldTimeMs
	{
		get
		{
			return Model.Fishing.CastHoldTimeMs;
		}
		set
		{
			int num = Math.Max(0, value);
			if (Model.Fishing.CastHoldTimeMs != num)
			{
				Model.Fishing.CastHoldTimeMs = num;
				OnPropertyChanged("CastHoldTimeMs");
			}
		}
	}

	public int BiteTimeoutMs
	{
		get
		{
			return Model.Fishing.BiteTimeoutMs;
		}
		set
		{
			int num = Math.Max(1, value);
			if (Model.Fishing.BiteTimeoutMs != num)
			{
				Model.Fishing.BiteTimeoutMs = num;
				OnPropertyChanged("BiteTimeoutMs");
			}
		}
	}

	public int RecastDelayMs
	{
		get
		{
			return Model.Fishing.RecastDelayMs;
		}
		set
		{
			int num = Math.Max(0, value);
			if (Model.Fishing.RecastDelayMs != num)
			{
				Model.Fishing.RecastDelayMs = num;
				OnPropertyChanged("RecastDelayMs");
			}
		}
	}

	public int ScanAreaX
	{
		get
		{
			return Model.Fishing.Rod.PrimaryRegion.X;
		}
		set
		{
			if (ScanAreaX != value)
			{
				RuntimeDiagnostics.Write($"ScanAreaX setter configuration='{Name}' {ScanAreaX}->{value}");
				Model.Fishing.Rod.PrimaryRegion.X = value;
				OnPropertyChanged("ScanAreaX");
			}
		}
	}

	public int ScanAreaY
	{
		get
		{
			return Model.Fishing.Rod.PrimaryRegion.Y;
		}
		set
		{
			if (ScanAreaY != value)
			{
				RuntimeDiagnostics.Write($"ScanAreaY setter configuration='{Name}' {ScanAreaY}->{value}");
				Model.Fishing.Rod.PrimaryRegion.Y = value;
				OnPropertyChanged("ScanAreaY");
			}
		}
	}

	public int ScanAreaWidth
	{
		get
		{
			return Model.Fishing.Rod.PrimaryRegion.Width;
		}
		set
		{
			int num = Math.Max(0, value);
			if (ScanAreaWidth != num)
			{
				RuntimeDiagnostics.Write($"ScanAreaWidth setter configuration='{Name}' {ScanAreaWidth}->{num}");
				Model.Fishing.Rod.PrimaryRegion.Width = num;
				OnPropertyChanged("ScanAreaWidth");
			}
		}
	}

	public int ScanAreaHeight
	{
		get
		{
			return Model.Fishing.Rod.PrimaryRegion.Height;
		}
		set
		{
			int num = Math.Max(0, value);
			if (ScanAreaHeight != num)
			{
				RuntimeDiagnostics.Write($"ScanAreaHeight setter configuration='{Name}' {ScanAreaHeight}->{num}");
				Model.Fishing.Rod.PrimaryRegion.Height = num;
				OnPropertyChanged("ScanAreaHeight");
			}
		}
	}

	public bool ShakeEnabled
	{
		get
		{
			return Model.Fishing.Rod.Rhythm.IsEnabled;
		}
		set
		{
			if (Model.Fishing.Rod.Rhythm.IsEnabled != value)
			{
				Model.Fishing.Rod.Rhythm.IsEnabled = value;
				OnPropertyChanged("ShakeEnabled");
			}
		}
	}

	public int ShakeVirtualKey
	{
		get
		{
			return Model.Fishing.Rod.Rhythm.VirtualKey;
		}
		set
		{
			ushort num = (ushort)Math.Clamp(value, 1, 255);
			if (Model.Fishing.Rod.Rhythm.VirtualKey != num)
			{
				Model.Fishing.Rod.Rhythm.VirtualKey = num;
				OnPropertyChanged("ShakeVirtualKey");
			}
		}
	}

	public int ShakeAreaX
	{
		get
		{
			return ShakeRegion.X;
		}
		set
		{
			if (ShakeRegion.X != value)
			{
				ShakeRegion.X = value;
				OnPropertyChanged("ShakeAreaX");
			}
		}
	}

	public int ShakeAreaY
	{
		get
		{
			return ShakeRegion.Y;
		}
		set
		{
			if (ShakeRegion.Y != value)
			{
				ShakeRegion.Y = value;
				OnPropertyChanged("ShakeAreaY");
			}
		}
	}

	public int ShakeAreaWidth
	{
		get
		{
			return ShakeRegion.Width;
		}
		set
		{
			int num = Math.Max(0, value);
			if (ShakeRegion.Width != num)
			{
				ShakeRegion.Width = num;
				OnPropertyChanged("ShakeAreaWidth");
			}
		}
	}

	public int ShakeAreaHeight
	{
		get
		{
			return ShakeRegion.Height;
		}
		set
		{
			int num = Math.Max(0, value);
			if (ShakeRegion.Height != num)
			{
				ShakeRegion.Height = num;
				OnPropertyChanged("ShakeAreaHeight");
			}
		}
	}

	public int ShakeRed
	{
		get
		{
			return Model.Fishing.Rod.Rhythm.TriggerColor.R;
		}
		set
		{
			SetShakeColor((byte)Math.Clamp(value, 0, 255), ShakeGreen, ShakeBlue);
		}
	}

	public int ShakeGreen
	{
		get
		{
			return Model.Fishing.Rod.Rhythm.TriggerColor.G;
		}
		set
		{
			SetShakeColor(ShakeRed, (byte)Math.Clamp(value, 0, 255), ShakeBlue);
		}
	}

	public int ShakeBlue
	{
		get
		{
			return Model.Fishing.Rod.Rhythm.TriggerColor.B;
		}
		set
		{
			SetShakeColor(ShakeRed, ShakeGreen, (byte)Math.Clamp(value, 0, 255));
		}
	}

	public int ShakeColorTolerance
	{
		get
		{
			return Model.Fishing.Rod.Rhythm.ColorTolerance;
		}
		set
		{
			byte b = (byte)Math.Clamp(value, 0, 255);
			if (Model.Fishing.Rod.Rhythm.ColorTolerance != b)
			{
				Model.Fishing.Rod.Rhythm.ColorTolerance = b;
				OnPropertyChanged("ShakeColorTolerance");
			}
		}
	}

	public int ShakeClickHoldMs
	{
		get
		{
			return Model.Fishing.Rod.Rhythm.KeyHoldMs;
		}
		set
		{
			int num = Math.Max(1, value);
			if (Model.Fishing.Rod.Rhythm.KeyHoldMs != num)
			{
				Model.Fishing.Rod.Rhythm.KeyHoldMs = num;
				OnPropertyChanged("ShakeClickHoldMs");
			}
		}
	}

	public bool PixelProgressEnabled
	{
		get
		{
			return Model.Fishing.Rod.Progress.IsEnabled;
		}
		set
		{
			if (Model.Fishing.Rod.Progress.IsEnabled == value)
			{
				return;
			}
			Model.Fishing.Rod.Progress.IsEnabled = value;
			RodConfig rod = Model.Fishing.Rod;
			if (rod.ProgressRegion == null)
			{
				ScreenRegion obj = new ScreenRegion
				{
					IsEnabled = true
				};
				ScreenRegion screenRegion = obj;
				rod.ProgressRegion = obj;
			}
			Model.Fishing.Rod.ProgressRegion.IsEnabled = value;
			if (value)
			{
				Model.Fishing.ProgressClassId = -1;
				foreach (DetectionClassViewModel item in _customClassViewModels.Where((DetectionClassViewModel item) => item.Behavior == DetectionBehavior.Progress))
				{
					item.Behavior = DetectionBehavior.Observe;
				}
				OnPropertyChanged("AiProgressClassId");
			}
			OnPropertyChanged("PixelProgressEnabled");
		}
	}

	public int ProgressAreaX
	{
		get
		{
			return ProgressRegion.X;
		}
		set
		{
			if (ProgressRegion.X != value)
			{
				ProgressRegion.X = value;
				OnPropertyChanged("ProgressAreaX");
			}
		}
	}

	public int ProgressAreaY
	{
		get
		{
			return ProgressRegion.Y;
		}
		set
		{
			if (ProgressRegion.Y != value)
			{
				ProgressRegion.Y = value;
				OnPropertyChanged("ProgressAreaY");
			}
		}
	}

	public int ProgressAreaWidth
	{
		get
		{
			return ProgressRegion.Width;
		}
		set
		{
			int num = Math.Max(0, value);
			if (ProgressRegion.Width != num)
			{
				ProgressRegion.Width = num;
				OnPropertyChanged("ProgressAreaWidth");
			}
		}
	}

	public int ProgressAreaHeight
	{
		get
		{
			return ProgressRegion.Height;
		}
		set
		{
			int num = Math.Max(0, value);
			if (ProgressRegion.Height != num)
			{
				ProgressRegion.Height = num;
				OnPropertyChanged("ProgressAreaHeight");
			}
		}
	}

	public int ProgressRed
	{
		get
		{
			return Model.Fishing.Rod.Progress.FillColor.R;
		}
		set
		{
			SetProgressColor((byte)Math.Clamp(value, 0, 255), ProgressGreen, ProgressBlue);
		}
	}

	public int ProgressGreen
	{
		get
		{
			return Model.Fishing.Rod.Progress.FillColor.G;
		}
		set
		{
			SetProgressColor(ProgressRed, (byte)Math.Clamp(value, 0, 255), ProgressBlue);
		}
	}

	public int ProgressBlue
	{
		get
		{
			return Model.Fishing.Rod.Progress.FillColor.B;
		}
		set
		{
			SetProgressColor(ProgressRed, ProgressGreen, (byte)Math.Clamp(value, 0, 255));
		}
	}

	public int ProgressColorTolerance
	{
		get
		{
			return Model.Fishing.Rod.Progress.ColorTolerance;
		}
		set
		{
			byte b = (byte)Math.Clamp(value, 0, 255);
			if (Model.Fishing.Rod.Progress.ColorTolerance != b)
			{
				Model.Fishing.Rod.Progress.ColorTolerance = b;
				OnPropertyChanged("ProgressColorTolerance");
			}
		}
	}

	public string RodName => Model.Fishing.Rod.DisplayName;

	public int MacroCount => Model.Macros.Count;

	public int CustomParameterCount => Model.CustomParameters.Count;

	private ScreenRegion ShakeRegion
	{
		get
		{
			RodConfig rod = Model.Fishing.Rod;
			ScreenRegion screenRegion = rod.SecondaryRegion;
			if (screenRegion == null)
			{
				ScreenRegion obj = new ScreenRegion
				{
					IsEnabled = false
				};
				ScreenRegion screenRegion2 = obj;
				rod.SecondaryRegion = obj;
				screenRegion = screenRegion2;
			}
			return screenRegion;
		}
	}

	private ScreenRegion ProgressRegion
	{
		get
		{
			RodConfig rod = Model.Fishing.Rod;
			ScreenRegion screenRegion = rod.ProgressRegion;
			if (screenRegion == null)
			{
				ScreenRegion obj = new ScreenRegion
				{
					IsEnabled = false
				};
				ScreenRegion screenRegion2 = obj;
				rod.ProgressRegion = obj;
				screenRegion = screenRegion2;
			}
			return screenRegion;
		}
	}

	public ConfigurationItemViewModel(GameConfiguration model, Action<ConfigurationItemViewModel> edit, Func<Task>? save = null, IScreenRegionSelector? regionSelector = null, IColorSelector? colorSelector = null, IModelFilePicker? modelFilePicker = null, IImageFilePicker? imageFilePicker = null, ObservableCollection<ConfigurationItemViewModel>? siblings = null)
	{
		ConfigurationItemViewModel obj = this;
		Model = model;
		_save = save;
		_regionSelector = regionSelector;
		_colorSelector = colorSelector;
		_modelFilePicker = modelFilePicker;
		_imageFilePicker = imageFilePicker;
		_siblings = siblings;
		model.Fishing.EnsureDefaultClasses();
		_customClassViewModels = new ObservableCollection<DetectionClassViewModel>(model.Fishing.CustomClasses.Select((DetectionClassDefinition c) => new DetectionClassViewModel(c, colorSelector)));
		_customClassViewModels.CollectionChanged += OnCustomClassesChanged;
		EditCommand = new RelayCommand(delegate
		{
			edit(obj);
		});
		ToggleEnabledCommand = new AsyncRelayCommand(ToggleEnabledAsync);
		PickFishingColorCommand = new AsyncRelayCommand(PickFishingColorAsync);
		SelectFishingScanAreaCommand = new AsyncRelayCommand(SelectFishingScanAreaAsync);
		BrowseModelFileCommand = new AsyncRelayCommand(BrowseModelFileAsync);
		RemoveModelCommand = new RelayCommand(RemoveModel);
		BrowseCoverImageCommand = new AsyncRelayCommand(BrowseCoverImageAsync);
		SelectShakeScanAreaCommand = new AsyncRelayCommand(SelectShakeScanAreaAsync);
		PickShakeColorCommand = new AsyncRelayCommand(PickShakeColorAsync);
		SelectProgressScanAreaCommand = new AsyncRelayCommand(SelectProgressScanAreaAsync);
		PickProgressColorCommand = new AsyncRelayCommand(PickProgressColorAsync);
		AddCustomClassCommand = new RelayCommand(AddCustomClass);
		RemoveCustomClassCommand = new RelayCommand<DetectionClassViewModel>(RemoveCustomClass);
		ValidateSteeringCommand = new RelayCommand(ValidateSteering);
		LoadCoverImage();
	}

	private async Task ToggleEnabledAsync()
	{
		IsEnabled = !IsEnabled;
		if (_save != null)
		{
			await _save();
		}
	}

	private async Task PickFishingColorAsync()
	{
		if (_colorSelector != null)
		{
			PixelColor pixelColor = await _colorSelector.SelectAsync(Model.Fishing.Rod.Slider.TargetColor);
			if ((object)pixelColor != null)
			{
				Model.Fishing.Rod.Slider.TargetColor = pixelColor;
				OnPropertyChanged("FishingRed");
				OnPropertyChanged("FishingGreen");
				OnPropertyChanged("FishingBlue");
			}
		}
	}

	private async Task SelectFishingScanAreaAsync()
	{
		if (_regionSelector == null)
		{
			return;
		}
		ScreenRegion screenRegion = await _regionSelector.SelectAsync(Model.Fishing.Rod.PrimaryRegion);
		if (screenRegion != null)
		{
			ScreenRegion primaryRegion = Model.Fishing.Rod.PrimaryRegion;
			primaryRegion.IsEnabled = true;
			primaryRegion.X = screenRegion.X;
			primaryRegion.Y = screenRegion.Y;
			primaryRegion.Width = screenRegion.Width;
			primaryRegion.Height = screenRegion.Height;
			OnPropertyChanged("ScanAreaX");
			OnPropertyChanged("ScanAreaY");
			OnPropertyChanged("ScanAreaWidth");
			OnPropertyChanged("ScanAreaHeight");
			RuntimeDiagnostics.Write($"Capture region selected configuration='{Name}' region={primaryRegion.X},{primaryRegion.Y},{primaryRegion.Width}x{primaryRegion.Height}");
			if (_save != null)
			{
				await _save();
				RuntimeDiagnostics.Write($"Capture region saved configuration='{Name}' region={primaryRegion.X},{primaryRegion.Y},{primaryRegion.Width}x{primaryRegion.Height}");
			}
		}
	}

	private async Task BrowseModelFileAsync()
	{
		if (_modelFilePicker == null)
		{
			return;
		}
		string text = await _modelFilePicker.PickAsync();
		if (string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		if (Path.GetExtension(text).Equals(".pt", StringComparison.OrdinalIgnoreCase))
		{
			try
			{
				ModelFilePath = ConfigurationBundle.StoreModel(PtModelConverter.EnsureOnnx(text));
				return;
			}
			catch (InvalidOperationException)
			{
				ModelFilePath = ConfigurationBundle.StoreModel(text);
				return;
			}
		}
		ModelFilePath = ConfigurationBundle.StoreModel(text);
	}

	private void RemoveModel()
	{
		ModelFilePath = string.Empty;
	}

	private async Task BrowseCoverImageAsync()
	{
		if (_imageFilePicker != null)
		{
			string text = await _imageFilePicker.PickPngAsync();
			if (!string.IsNullOrWhiteSpace(text))
			{
				CoverImagePath = text;
			}
		}
	}

	private async Task SelectShakeScanAreaAsync()
	{
		if (_regionSelector != null)
		{
			ScreenRegion screenRegion = await _regionSelector.SelectAsync(ShakeRegion);
			if (screenRegion != null)
			{
				screenRegion.IsEnabled = true;
				Model.Fishing.Rod.SecondaryRegion = screenRegion;
				Model.Fishing.Rod.Rhythm.IsEnabled = true;
				OnPropertyChanged("ShakeEnabled");
				OnPropertyChanged("ShakeAreaX");
				OnPropertyChanged("ShakeAreaY");
				OnPropertyChanged("ShakeAreaWidth");
				OnPropertyChanged("ShakeAreaHeight");
			}
		}
	}

	private async Task PickShakeColorAsync()
	{
		if (_colorSelector != null)
		{
			PixelColor pixelColor = await _colorSelector.SelectAsync(Model.Fishing.Rod.Rhythm.TriggerColor);
			if ((object)pixelColor != null)
			{
				Model.Fishing.Rod.Rhythm.TriggerColor = pixelColor;
				OnPropertyChanged("ShakeRed");
				OnPropertyChanged("ShakeGreen");
				OnPropertyChanged("ShakeBlue");
			}
		}
	}

	private async Task SelectProgressScanAreaAsync()
	{
		if (_regionSelector == null)
		{
			return;
		}
		ScreenRegion screenRegion = await _regionSelector.SelectAsync(ProgressRegion);
		if (screenRegion == null)
		{
			return;
		}
		screenRegion.IsEnabled = true;
		Model.Fishing.Rod.ProgressRegion = screenRegion;
		Model.Fishing.Rod.Progress.IsEnabled = true;
		Model.Fishing.ProgressClassId = -1;
		foreach (DetectionClassViewModel item in _customClassViewModels.Where((DetectionClassViewModel item) => item.Behavior == DetectionBehavior.Progress))
		{
			item.Behavior = DetectionBehavior.Observe;
		}
		OnPropertyChanged("PixelProgressEnabled");
		OnPropertyChanged("AiProgressClassId");
		OnPropertyChanged("ProgressAreaX");
		OnPropertyChanged("ProgressAreaY");
		OnPropertyChanged("ProgressAreaWidth");
		OnPropertyChanged("ProgressAreaHeight");
	}

	private async Task PickProgressColorAsync()
	{
		if (_colorSelector != null)
		{
			PixelColor pixelColor = await _colorSelector.SelectAsync(Model.Fishing.Rod.Progress.FillColor);
			if ((object)pixelColor != null)
			{
				Model.Fishing.Rod.Progress.FillColor = pixelColor;
				OnPropertyChanged("ProgressRed");
				OnPropertyChanged("ProgressGreen");
				OnPropertyChanged("ProgressBlue");
			}
		}
	}

	private void SetShakeColor(int red, int green, int blue)
	{
		PixelColor pixelColor = new PixelColor((byte)red, (byte)green, (byte)blue);
		if (!(Model.Fishing.Rod.Rhythm.TriggerColor == pixelColor))
		{
			Model.Fishing.Rod.Rhythm.TriggerColor = pixelColor;
			OnPropertyChanged("ShakeRed");
			OnPropertyChanged("ShakeGreen");
			OnPropertyChanged("ShakeBlue");
		}
	}

	private void SetProgressColor(int red, int green, int blue)
	{
		PixelColor pixelColor = new PixelColor((byte)red, (byte)green, (byte)blue);
		if (!(Model.Fishing.Rod.Progress.FillColor == pixelColor))
		{
			Model.Fishing.Rod.Progress.FillColor = pixelColor;
			OnPropertyChanged("ProgressRed");
			OnPropertyChanged("ProgressGreen");
			OnPropertyChanged("ProgressBlue");
		}
	}

	private void AddCustomClass()
	{
		int id = ((_customClassViewModels.Count != 0) ? (_customClassViewModels.Max((DetectionClassViewModel item) => item.Id) + 1) : 0);
		DetectionClassDefinition model = new DetectionClassDefinition
		{
			Id = id,
			Name = "Custom class",
			Behavior = DetectionBehavior.Observe
		};
		_customClassViewModels.Add(new DetectionClassViewModel(model, _colorSelector));
	}

	private void RemoveCustomClass(DetectionClassViewModel? vm)
	{
		bool flag = vm == null;
		if (!flag)
		{
			DetectionBehavior behavior = vm.Behavior;
			bool flag2 = (uint)(behavior - 2) <= 1u;
			flag = flag2;
		}
		if (!flag)
		{
			_customClassViewModels.Remove(vm);
		}
	}

	private void ValidateSteering()
	{
		Model.Fishing.CustomClasses = _customClassViewModels.Select((DetectionClassViewModel v) => v.Model).ToList();
		try
		{
			Model.Fishing.ValidateBehaviorRules();
			SteeringValidationMessage = "Behavior and formula rules are valid";
		}
		catch (InvalidOperationException ex)
		{
			SteeringValidationMessage = ex.Message;
		}
	}

	private void OnCustomClassesChanged(object? sender, NotifyCollectionChangedEventArgs args)
	{
		Model.Fishing.CustomClasses = _customClassViewModels.Select((DetectionClassViewModel v) => v.Model).ToList();
	}

	private void LoadCoverImage()
	{
		_coverImage?.Dispose();
		_coverImage = null;
		try
		{
			string coverPath = Model.CoverImagePath;
			if (File.Exists(coverPath))
			{
				using FileStream stream = File.OpenRead(coverPath);
				_coverImage = new Bitmap(stream);
			}
			else
			{
				using Stream? stream = typeof(ConfigurationItemViewModel).Assembly.GetManifestResourceStream("PFMS.Assets.rod-icon.png");
				if (stream != null)
				{
					_coverImage = new Bitmap(stream);
				}
			}
		}
		catch
		{
			_coverImage = null;
		}
		OnPropertyChanged("CoverImage");
	}

	private void SetTargetColor(int red, int green, int blue)
	{
		PixelColor pixelColor = new PixelColor((byte)red, (byte)green, (byte)blue);
		if (!(Model.Fishing.Rod.Slider.TargetColor == pixelColor))
		{
			Model.Fishing.Rod.Slider.TargetColor = pixelColor;
			OnPropertyChanged("FishingRed");
			OnPropertyChanged("FishingGreen");
			OnPropertyChanged("FishingBlue");
		}
	}

	public void RefreshMetrics()
	{
		OnPropertyChanged("MacroCount");
		OnPropertyChanged("CustomParameterCount");
		OnPropertyChanged("RodName");
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pfm.Core.Configuration;
using Pfm.Core.Macros;
using Pfm.Core.Vision;

namespace Pfm.ViewModels;

public class ActionNodeViewModel : ViewModelBase
{
	private enum ColorComponent
	{
		Red,
		Green,
		Blue
	}

	private readonly IScreenRegionSelector? _regionSelector;

	private readonly IColorSelector? _colorSelector;

	[ObservableProperty]
	private bool _isSelected;

	public MacroAction Model { get; }

	public IRelayCommand SelectCommand { get; }

	public IRelayCommand MoveUpCommand { get; }

	public IRelayCommand MoveDownCommand { get; }

	public IRelayCommand DeleteCommand { get; }

	public IAsyncRelayCommand SelectRegionCommand { get; }

	public IAsyncRelayCommand SelectColorCommand { get; }

	public string[] PhaseOptions { get; } = Enum.GetNames<MacroPhase>();

	public string[] MouseButtonOptions { get; } = Enum.GetNames<MacroMouseButton>();

	public string[] MouseActionOptions { get; } = Enum.GetNames<MacroMouseActionKind>();

	public int ExecutionOrder => Model.ExecutionOrder;

	public string TypeName
	{
		get
		{
			MacroAction model = Model;
			if (!(model is PixelColorClickAction))
			{
				if (!(model is TemplateImageMatchAction))
				{
					if (!(model is PixelColorCheckAction))
					{
						if (!(model is KeyPressAction))
						{
							if (!(model is MouseButtonAction))
							{
								if (!(model is DelayAction))
								{
									if (model is EndAction)
									{
										return "End pipeline";
									}
									return Model.GetType().Name;
								}
								return "Delay";
							}
							return "Mouse input";
						}
						return "Key press";
					}
					return "Pixel color check";
				}
				return "Find image and click";
			}
			return "Find and click pixel";
		}
	}

	public bool IsPixel => Model is PixelColorCheckAction;

	public bool IsPixelClick => Model is PixelColorClickAction;

	public bool IsVisualTarget
	{
		get
		{
			MacroAction model = Model;
			if (model is PixelColorCheckAction || model is TemplateImageMatchAction)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsKey => Model is KeyPressAction;

	public bool IsMouse => Model is MouseButtonAction;

	public bool IsDelay => Model is DelayAction;

	public bool IsTemplate => Model is TemplateImageMatchAction;

	public string TemplatePath
	{
		get
		{
			return Template?.TemplatePath ?? string.Empty;
		}
		set
		{
			TemplateImageMatchAction template = Template;
			if (template != null)
			{
				template.TemplatePath = value;
				OnPropertyChanged("TemplatePath");
			}
		}
	}

	public int TemplateSimilarityPercent
	{
		get
		{
			return (int)Math.Round((Template?.SimilarityThreshold ?? 0.9) * 100.0);
		}
		set
		{
			TemplateImageMatchAction template = Template;
			if (template != null)
			{
				template.SimilarityThreshold = (double)Math.Clamp(value, 50, 100) / 100.0;
				OnPropertyChanged("TemplateSimilarityPercent");
			}
		}
	}

	public double TemplateSimilarity
	{
		get
		{
			return Template?.SimilarityThreshold ?? 0.9;
		}
		set
		{
			TemplateImageMatchAction template = Template;
			if (template != null)
			{
				template.SimilarityThreshold = Math.Clamp(value, 0.5, 1.0);
				OnPropertyChanged("TemplateSimilarity");
				OnPropertyChanged("TemplateSimilarityPercent");
			}
		}
	}

	public int TemplateSearchStride
	{
		get
		{
			return Template?.SearchStride ?? 0;
		}
		set
		{
			TemplateImageMatchAction template = Template;
			if (template != null)
			{
				template.SearchStride = value;
				OnPropertyChanged("TemplateSearchStride");
			}
		}
	}

	public int TemplateSampleStride
	{
		get
		{
			return Template?.SampleStride ?? 0;
		}
		set
		{
			TemplateImageMatchAction template = Template;
			if (template != null)
			{
				template.SampleStride = value;
				OnPropertyChanged("TemplateSampleStride");
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

	public string Phase
	{
		get
		{
			return Model.Phase.ToString();
		}
		set
		{
			if (Enum.TryParse<MacroPhase>(value, out var result) && Model.Phase != result)
			{
				Model.Phase = result;
				OnPropertyChanged("Phase");
			}
		}
	}

	public string SuccessTarget
	{
		get
		{
			return Model.OnSuccessTarget?.ToString() ?? string.Empty;
		}
		set
		{
			Model.OnSuccessTarget = ParseTarget(value);
			OnPropertyChanged("SuccessTarget");
		}
	}

	public string FailTarget
	{
		get
		{
			return Model.OnFailTarget?.ToString() ?? string.Empty;
		}
		set
		{
			Model.OnFailTarget = ParseTarget(value);
			OnPropertyChanged("FailTarget");
		}
	}

	public int RegionX
	{
		get
		{
			return VisionRegion?.X ?? 0;
		}
		set
		{
			ScreenRegion visionRegion = VisionRegion;
			if (visionRegion != null)
			{
				visionRegion.X = value;
				OnPropertyChanged("RegionX");
			}
		}
	}

	public int RegionY
	{
		get
		{
			return VisionRegion?.Y ?? 0;
		}
		set
		{
			ScreenRegion visionRegion = VisionRegion;
			if (visionRegion != null)
			{
				visionRegion.Y = value;
				OnPropertyChanged("RegionY");
			}
		}
	}

	public int RegionWidth
	{
		get
		{
			return VisionRegion?.Width ?? 0;
		}
		set
		{
			ScreenRegion visionRegion = VisionRegion;
			if (visionRegion != null)
			{
				visionRegion.Width = value;
				OnPropertyChanged("RegionWidth");
			}
		}
	}

	public int RegionHeight
	{
		get
		{
			return VisionRegion?.Height ?? 0;
		}
		set
		{
			ScreenRegion visionRegion = VisionRegion;
			if (visionRegion != null)
			{
				visionRegion.Height = value;
				OnPropertyChanged("RegionHeight");
			}
		}
	}

	public int ColorTolerance
	{
		get
		{
			return Pixel?.ColorTolerance ?? 0;
		}
		set
		{
			PixelColorCheckAction pixel = Pixel;
			if (pixel != null)
			{
				pixel.ColorTolerance = (byte)Math.Clamp(value, 0, 255);
				OnPropertyChanged("ColorTolerance");
			}
		}
	}

	public double RequiredMatchRatio
	{
		get
		{
			return Pixel?.RequiredMatchRatio ?? 0.0;
		}
		set
		{
			PixelColorCheckAction pixel = Pixel;
			if (pixel != null)
			{
				pixel.RequiredMatchRatio = value;
				OnPropertyChanged("RequiredMatchRatio");
			}
		}
	}

	public int MinimumMatchingPixels
	{
		get
		{
			return Pixel?.MinimumMatchingPixels ?? 0;
		}
		set
		{
			PixelColorCheckAction pixel = Pixel;
			if (pixel != null)
			{
				pixel.MinimumMatchingPixels = value;
				OnPropertyChanged("MinimumMatchingPixels");
			}
		}
	}

	public int SampleStride
	{
		get
		{
			return Pixel?.SampleStride ?? 0;
		}
		set
		{
			PixelColorCheckAction pixel = Pixel;
			if (pixel != null)
			{
				pixel.SampleStride = value;
				OnPropertyChanged("SampleStride");
			}
		}
	}

	public int PixelClickDelayMs
	{
		get
		{
			return PixelClick?.DelayMs ?? 0;
		}
		set
		{
			PixelColorClickAction pixelClick = PixelClick;
			if (pixelClick != null)
			{
				pixelClick.DelayMs = value;
				OnPropertyChanged("PixelClickDelayMs");
			}
		}
	}

	public int PixelClickHoldMs
	{
		get
		{
			return PixelClick?.HoldMs ?? 0;
		}
		set
		{
			PixelColorClickAction pixelClick = PixelClick;
			if (pixelClick != null)
			{
				pixelClick.HoldMs = value;
				OnPropertyChanged("PixelClickHoldMs");
			}
		}
	}

	public string ColorHex
	{
		get
		{
			PixelColorCheckAction pixel = Pixel;
			if (pixel == null)
			{
				return "#FFFFFF";
			}
			return $"#{pixel.ExpectedColor.R:X2}{pixel.ExpectedColor.G:X2}{pixel.ExpectedColor.B:X2}";
		}
		set
		{
			if (TryParseColor(value, out PixelColor color))
			{
				SetPixelColor(color);
			}
		}
	}

	public int ColorRed
	{
		get
		{
			return Pixel?.ExpectedColor.R ?? 0;
		}
		set
		{
			SetColorComponent(value, ColorComponent.Red);
		}
	}

	public int ColorGreen
	{
		get
		{
			return Pixel?.ExpectedColor.G ?? 0;
		}
		set
		{
			SetColorComponent(value, ColorComponent.Green);
		}
	}

	public int ColorBlue
	{
		get
		{
			return Pixel?.ExpectedColor.B ?? 0;
		}
		set
		{
			SetColorComponent(value, ColorComponent.Blue);
		}
	}

	public int VirtualKey
	{
		get
		{
			return Key?.VirtualKey ?? 0;
		}
		set
		{
			KeyPressAction key = Key;
			if (key != null)
			{
				key.VirtualKey = (ushort)Math.Clamp(value, 0, 65535);
				OnPropertyChanged("VirtualKey");
			}
		}
	}

	public int KeyDelayMs
	{
		get
		{
			return Key?.DelayMs ?? 0;
		}
		set
		{
			KeyPressAction key = Key;
			if (key != null)
			{
				key.DelayMs = value;
				OnPropertyChanged("KeyDelayMs");
			}
		}
	}

	public int KeyHoldMs
	{
		get
		{
			return Key?.HoldMs ?? 0;
		}
		set
		{
			KeyPressAction key = Key;
			if (key != null)
			{
				key.HoldMs = value;
				OnPropertyChanged("KeyHoldMs");
			}
		}
	}

	public int DelayDurationMs
	{
		get
		{
			return Delay?.DurationMs ?? 0;
		}
		set
		{
			DelayAction delay = Delay;
			if (delay != null)
			{
				delay.DurationMs = value;
				OnPropertyChanged("DelayDurationMs");
			}
		}
	}

	public string MouseButton
	{
		get
		{
			return Mouse?.Button.ToString() ?? MacroMouseButton.Left.ToString();
		}
		set
		{
			MouseButtonAction mouse = Mouse;
			if (mouse != null && Enum.TryParse<MacroMouseButton>(value, out var result))
			{
				mouse.Button = result;
				OnPropertyChanged("MouseButton");
			}
		}
	}

	public string MouseAction
	{
		get
		{
			return Mouse?.ActionKind.ToString() ?? MacroMouseActionKind.Click.ToString();
		}
		set
		{
			MouseButtonAction mouse = Mouse;
			if (mouse != null && Enum.TryParse<MacroMouseActionKind>(value, out var result))
			{
				mouse.ActionKind = result;
				OnPropertyChanged("MouseAction");
			}
		}
	}

	public bool MoveCursor
	{
		get
		{
			return Mouse?.MoveCursor ?? false;
		}
		set
		{
			MouseButtonAction mouse = Mouse;
			if (mouse != null)
			{
				mouse.MoveCursor = value;
				OnPropertyChanged("MoveCursor");
			}
		}
	}

	public int MouseX
	{
		get
		{
			return Mouse?.X ?? 0;
		}
		set
		{
			MouseButtonAction mouse = Mouse;
			if (mouse != null)
			{
				mouse.X = value;
				OnPropertyChanged("MouseX");
			}
		}
	}

	public int MouseY
	{
		get
		{
			return Mouse?.Y ?? 0;
		}
		set
		{
			MouseButtonAction mouse = Mouse;
			if (mouse != null)
			{
				mouse.Y = value;
				OnPropertyChanged("MouseY");
			}
		}
	}

	public int MouseDelayMs
	{
		get
		{
			return Mouse?.DelayMs ?? 0;
		}
		set
		{
			MouseButtonAction mouse = Mouse;
			if (mouse != null)
			{
				mouse.DelayMs = value;
				OnPropertyChanged("MouseDelayMs");
			}
		}
	}

	public int MouseHoldMs
	{
		get
		{
			return Mouse?.HoldMs ?? 0;
		}
		set
		{
			MouseButtonAction mouse = Mouse;
			if (mouse != null)
			{
				mouse.HoldMs = value;
				OnPropertyChanged("MouseHoldMs");
			}
		}
	}

	private PixelColorCheckAction? Pixel => Model as PixelColorCheckAction;

	private PixelColorClickAction? PixelClick => Model as PixelColorClickAction;

	private KeyPressAction? Key => Model as KeyPressAction;

	private MouseButtonAction? Mouse => Model as MouseButtonAction;

	private DelayAction? Delay => Model as DelayAction;

	private TemplateImageMatchAction? Template => Model as TemplateImageMatchAction;

	private ScreenRegion? VisionRegion
	{
		get
		{
			object obj = Pixel?.Region;
			if (obj == null)
			{
				TemplateImageMatchAction? template = Template;
				if (template == null)
				{
					return null;
				}
				obj = template.Region;
			}
			return (ScreenRegion?)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSelected, value))
			{
				OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSelected);
				_isSelected = value;
				OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSelected);
			}
		}
	}

	public ActionNodeViewModel(MacroAction model, Action<ActionNodeViewModel> select, Action<ActionNodeViewModel> moveUp, Action<ActionNodeViewModel> moveDown, Action<ActionNodeViewModel> delete, IScreenRegionSelector? regionSelector, IColorSelector? colorSelector)
	{
		ActionNodeViewModel actionNodeViewModel = this;
		Model = model;
		_regionSelector = regionSelector;
		_colorSelector = colorSelector;
		SelectCommand = new RelayCommand(delegate
		{
			select(actionNodeViewModel);
		});
		MoveUpCommand = new RelayCommand(delegate
		{
			moveUp(actionNodeViewModel);
		});
		MoveDownCommand = new RelayCommand(delegate
		{
			moveDown(actionNodeViewModel);
		});
		DeleteCommand = new RelayCommand(delegate
		{
			delete(actionNodeViewModel);
		});
		SelectRegionCommand = new AsyncRelayCommand(SelectRegionAsync, () => actionNodeViewModel.IsVisualTarget && actionNodeViewModel._regionSelector != null);
		SelectColorCommand = new AsyncRelayCommand(SelectColorAsync, () => actionNodeViewModel.IsPixel && actionNodeViewModel._colorSelector != null);
	}

	public void RefreshOrder()
	{
		OnPropertyChanged("ExecutionOrder");
	}

	public void RefreshTargets()
	{
		OnPropertyChanged("SuccessTarget");
		OnPropertyChanged("FailTarget");
	}

	private async Task SelectRegionAsync()
	{
		if (_regionSelector == null || VisionRegion == null)
		{
			return;
		}
		ScreenRegion screenRegion = await _regionSelector.SelectAsync(VisionRegion);
		if (screenRegion == null)
		{
			return;
		}
		PixelColorCheckAction pixel = Pixel;
		if (pixel != null)
		{
			pixel.Region = screenRegion;
		}
		else
		{
			TemplateImageMatchAction template = Template;
			if (template != null)
			{
				template.Region = screenRegion;
			}
		}
		OnPropertyChanged("RegionX");
		OnPropertyChanged("RegionY");
		OnPropertyChanged("RegionWidth");
		OnPropertyChanged("RegionHeight");
	}

	private async Task SelectColorAsync()
	{
		if (_colorSelector == null)
		{
			return;
		}
		PixelColorCheckAction pixel = Pixel;
		if (pixel != null)
		{
			PixelColor pixelColor = await _colorSelector.SelectAsync(pixel.ExpectedColor);
			if ((object)pixelColor != null)
			{
				PixelColor pixelColor2 = pixelColor;
				SetPixelColor(pixelColor2);
			}
		}
	}

	private void SetColorComponent(int value, ColorComponent component)
	{
		PixelColorCheckAction pixel = Pixel;
		if (pixel != null)
		{
			byte b = (byte)Math.Clamp(value, 0, 255);
			PixelColor expectedColor = pixel.ExpectedColor;
			SetPixelColor(component switch
			{
				ColorComponent.Red => new PixelColor(b, expectedColor.G, expectedColor.B), 
				ColorComponent.Green => new PixelColor(expectedColor.R, b, expectedColor.B), 
				ColorComponent.Blue => new PixelColor(expectedColor.R, expectedColor.G, b), 
				_ => expectedColor, 
			});
		}
	}

	private void SetPixelColor(PixelColor color)
	{
		PixelColorCheckAction pixel = Pixel;
		if (pixel != null)
		{
			pixel.ExpectedColor = color;
			OnPropertyChanged("ColorHex");
			OnPropertyChanged("ColorRed");
			OnPropertyChanged("ColorGreen");
			OnPropertyChanged("ColorBlue");
		}
	}

	private static int? ParseTarget(string value)
	{
		if (!string.IsNullOrWhiteSpace(value))
		{
			if (!int.TryParse(value, out var result))
			{
				return null;
			}
			return result;
		}
		return null;
	}

	private static bool TryParseColor(string value, out PixelColor color)
	{
		string text = value.Trim().TrimStart('#');
		if (text.Length == 6 && byte.TryParse(text.Substring(0, 2), NumberStyles.HexNumber, null, out var result) && byte.TryParse(text.Substring(2, 2), NumberStyles.HexNumber, null, out var result2) && byte.TryParse(text.Substring(4, 2), NumberStyles.HexNumber, null, out var result3))
		{
			color = new PixelColor(result, result2, result3);
			return true;
		}
		color = new PixelColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
		return false;
	}
}

using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Pfm.Core.Configuration;
using Pfm.Core.Vision;

namespace Pfm.ViewModels;

public sealed class DetectionClassViewModel : ViewModelBase
{
	private readonly IColorSelector? _colorSelector;

	public DetectionClassDefinition Model { get; }

	public IAsyncRelayCommand PickColorCommand { get; }

	public IRelayCommand ClearColorCommand { get; }

	public int Id
	{
		get
		{
			return Model.Id;
		}
		set
		{
			if (Model.Id != value)
			{
				Model.Id = value;
				OnPropertyChanged("Id");
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
			string text = value ?? string.Empty;
			if (Model.Name != text)
			{
				Model.Name = text;
				OnPropertyChanged("Name");
			}
		}
	}

	public DetectionBehavior Behavior
	{
		get
		{
			return Model.Behavior;
		}
		set
		{
			if (Model.Behavior != value)
			{
				Model.Behavior = value;
				OnPropertyChanged("Behavior");
			}
		}
	}

	public double Weight
	{
		get
		{
			return Model.Weight;
		}
		set
		{
			double num = (double.IsFinite(value) ? Math.Max(0.0, value) : 1.0);
			if (Model.Weight != num)
			{
				Model.Weight = num;
				OnPropertyChanged("Weight");
			}
		}
	}

	public string InfluenceFormula
	{
		get
		{
			return Model.InfluenceFormula;
		}
		set
		{
			string text = value ?? string.Empty;
			if (Model.InfluenceFormula != text)
			{
				Model.InfluenceFormula = text;
				OnPropertyChanged("InfluenceFormula");
			}
		}
	}

	public bool HasColorHint => Model.ColorHint?.IsEnabled ?? false;

	public string ColorHintSwatch
	{
		get
		{
			ColorHint? colorHint = Model.ColorHint;
			if (colorHint == null || !colorHint.IsEnabled)
			{
				return "None";
			}
			return $"#{Model.ColorHint.R:X2}{Model.ColorHint.G:X2}{Model.ColorHint.B:X2}";
		}
	}

	public DetectionClassViewModel(DetectionClassDefinition model, IColorSelector? colorSelector)
	{
		Model = model;
		_colorSelector = colorSelector;
		PickColorCommand = new AsyncRelayCommand(PickColorAsync);
		ClearColorCommand = new RelayCommand(ClearColor);
	}

	private async Task PickColorAsync()
	{
		if (_colorSelector != null)
		{
			ColorHint colorHint = Model.ColorHint;
			PixelColor initialColor = ((colorHint != null && colorHint.IsEnabled) ? new PixelColor(colorHint.R, colorHint.G, colorHint.B) : new PixelColor(128, 128, 128));
			PixelColor pixelColor = await _colorSelector.SelectAsync(initialColor);
			if ((object)pixelColor != null)
			{
				Model.ColorHint = new ColorHint
				{
					R = pixelColor.R,
					G = pixelColor.G,
					B = pixelColor.B,
					Tolerance = (Model.ColorHint?.Tolerance ?? 30),
					IsEnabled = true
				};
				OnPropertyChanged("HasColorHint");
				OnPropertyChanged("ColorHintSwatch");
			}
		}
	}

	private void ClearColor()
	{
		if (Model.ColorHint != null)
		{
			Model.ColorHint.IsEnabled = false;
		}
		OnPropertyChanged("HasColorHint");
		OnPropertyChanged("ColorHintSwatch");
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pfm.Core.Configuration;
using Pfm.Core.Macros;
using Pfm.Core.Vision;

namespace Pfm.ViewModels;

public sealed class MacroBuilderItemViewModel : ViewModelBase
{
	private readonly Action<ActionNodeViewModel?> _selectAction;

	private readonly IScreenRegionSelector? _regionSelector;

	private readonly IColorSelector? _colorSelector;

	public MacroDefinition Model { get; }

	public ObservableCollection<ActionNodeViewModel> Actions { get; }

	public int ActionCount => Actions.Count;

	public string Name
	{
		get
		{
			return Model.Name;
		}
		set
		{
			if (Model.Name != value)
			{
				Model.Name = value;
				OnPropertyChanged("Name");
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
			if (Model.IsEnabled != value)
			{
				Model.IsEnabled = value;
				OnPropertyChanged("IsEnabled");
			}
		}
	}

	public MacroBuilderItemViewModel(MacroDefinition model, Action<ActionNodeViewModel?> selectAction, IScreenRegionSelector? regionSelector, IColorSelector? colorSelector)
	{
		Model = model;
		_selectAction = selectAction;
		_regionSelector = regionSelector;
		_colorSelector = colorSelector;
		Actions = new ObservableCollection<ActionNodeViewModel>(model.Actions.Select(CreateNode));
	}

	public ActionNodeViewModel Add(MacroAction action)
	{
		action.ExecutionOrder = Actions.Count;
		Model.Actions.Add(action);
		ActionNodeViewModel actionNodeViewModel = CreateNode(action);
		Actions.Add(actionNodeViewModel);
		OnPropertyChanged("ActionCount");
		Select(actionNodeViewModel);
		return actionNodeViewModel;
	}

	public void ReplaceWith(IEnumerable<MacroAction> actions)
	{
		Model.Actions.Clear();
		Actions.Clear();
		foreach (MacroAction action in actions)
		{
			action.ExecutionOrder = Actions.Count;
			Model.Actions.Add(action);
			Actions.Add(CreateNode(action));
		}
		OnPropertyChanged("ActionCount");
		Select(Actions.FirstOrDefault());
	}

	public void SelectFirstAction()
	{
		Select(Actions.FirstOrDefault());
	}

	private ActionNodeViewModel CreateNode(MacroAction action)
	{
		return new ActionNodeViewModel(action, Select, delegate(ActionNodeViewModel node)
		{
			Move(node, -1);
		}, delegate(ActionNodeViewModel node)
		{
			Move(node, 1);
		}, Delete, _regionSelector, _colorSelector);
	}

	private void Select(ActionNodeViewModel? node)
	{
		foreach (ActionNodeViewModel action in Actions)
		{
			action.IsSelected = action == node;
		}
		_selectAction(node);
	}

	private void Move(ActionNodeViewModel node, int offset)
	{
		int num = Actions.IndexOf(node);
		int num2 = num + offset;
		if (num >= 0 && num2 >= 0 && num2 < Actions.Count)
		{
			Dictionary<Guid, (Guid?, Guid?)> targets = CaptureTargetIds();
			Actions.Move(num, num2);
			Model.Actions.RemoveAt(num);
			Model.Actions.Insert(num2, node.Model);
			RestoreTargets(targets);
			Select(node);
		}
	}

	private void Delete(ActionNodeViewModel node)
	{
		ActionNodeViewModel actionNodeViewModel = Actions.FirstOrDefault((ActionNodeViewModel action) => action.IsSelected);
		int val = Actions.IndexOf(node);
		Dictionary<Guid, (Guid?, Guid?)> targets = CaptureTargetIds();
		Actions.Remove(node);
		Model.Actions.Remove(node.Model);
		RestoreTargets(targets);
		OnPropertyChanged("ActionCount");
		ActionNodeViewModel node2 = ((actionNodeViewModel != node) ? actionNodeViewModel : ((Actions.Count == 0) ? null : Actions[Math.Min(val, Actions.Count - 1)]));
		Select(node2);
	}

	private Dictionary<Guid, (Guid? Success, Guid? Fail)> CaptureTargetIds()
	{
		return Actions.ToDictionary((ActionNodeViewModel node) => node.Model.Id, (ActionNodeViewModel node) => (ResolveTargetId(node.Model.OnSuccessTarget), ResolveTargetId(node.Model.OnFailTarget)));
	}

	private Guid? ResolveTargetId(int? target)
	{
		if (!target.HasValue || target.GetValueOrDefault() < 0 || !(target < Actions.Count))
		{
			return null;
		}
		return Actions[target.Value].Model.Id;
	}

	private void RestoreTargets(Dictionary<Guid, (Guid? Success, Guid? Fail)> targets)
	{
		Dictionary<Guid, int> dictionary = Actions.Select((ActionNodeViewModel node, int index) => (Id: node.Model.Id, index: index)).ToDictionary(((Guid Id, int index) pair) => pair.Id, ((Guid Id, int index) pair) => pair.index);
		ActionNodeViewModel actionNodeViewModel;
		for (int num = 0; num < Actions.Count; actionNodeViewModel.RefreshOrder(), actionNodeViewModel.RefreshTargets(), num++)
		{
			actionNodeViewModel = Actions[num];
			actionNodeViewModel.Model.ExecutionOrder = num;
			if (!targets.TryGetValue(actionNodeViewModel.Model.Id, out (Guid?, Guid?) value))
			{
				continue;
			}
			MacroAction model = actionNodeViewModel.Model;
			Guid? guid;
			(guid, _) = value;
			int? onSuccessTarget;
			if (guid.HasValue)
			{
				Guid valueOrDefault = guid.GetValueOrDefault();
				if (dictionary.TryGetValue(valueOrDefault, out var value2))
				{
					onSuccessTarget = value2;
					goto IL_00e5;
				}
			}
			onSuccessTarget = null;
			goto IL_00e5;
			IL_00e5:
			model.OnSuccessTarget = onSuccessTarget;
			MacroAction model2 = actionNodeViewModel.Model;
			guid = value.Item2;
			int? onFailTarget;
			if (guid.HasValue)
			{
				Guid valueOrDefault2 = guid.GetValueOrDefault();
				if (dictionary.TryGetValue(valueOrDefault2, out var value3))
				{
					onFailTarget = value3;
					goto IL_0129;
				}
			}
			onFailTarget = null;
			goto IL_0129;
			IL_0129:
			model2.OnFailTarget = onFailTarget;
		}
	}
}

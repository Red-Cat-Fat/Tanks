using System;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.Utility.LogSystem.TimeLogSystem
{
	[Serializable]
	public class Task
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private DeltaTime _currentDeltaTime;

		[SerializeField]
		private List<DeltaTime> _taskDeltaTimes = new List<DeltaTime>();

		[SerializeField]
		private bool _isFinal = false;

		public string GetName()
		{
			return _name;
		}

		public bool IsInProgress()
		{
			return _currentDeltaTime != null && _currentDeltaTime.IsInProgress();
		}

		public bool IsFinal()
		{
			return _isFinal && !IsInProgress();
		}

		public Task(string name)//TODO: set notNull name
		{
			_name = name;
		}

		public GUIStyle GetGuiLabelStyle()//TODO: Separate to new class-factory
		{
			GUIStyle style = new GUIStyle
			{
				richText = true,
				fontStyle = !IsFinal()
					? FontStyle.Bold
					: FontStyle.Normal
			};
			return style;
		}

		public string GetGuiLabelString()
		{
			var color = IsFinal()
				? "green"
				: IsInProgress()
					? "black"
					: "yellow";
			return $"<color={color}>{ToString()}</color>";
		}
		
		private LogDateTime GetEndTaskTime()
		{
			return !IsFinal()
				? DateTime.Now
				: _taskDeltaTimes[_taskDeltaTimes.Count-1].GetEndTime();
		}

		private LogDateTime GetStartTaskTime()
		{
			return _taskDeltaTimes.Count == 0 
				? _currentDeltaTime.GetStartTime() 
				: _taskDeltaTimes[0].GetStartTime();
		}
		
		public void Start()
		{
			if (!IsInProgress())
			{
				_currentDeltaTime = new DeltaTime();
				_currentDeltaTime.Start();
				_isFinal = false;
			}
		}

		public void Pasuse()
		{
			if (_currentDeltaTime != null)
			{
				_currentDeltaTime.Stop();
				AddTime(_currentDeltaTime);
				_currentDeltaTime = null;
			}
		}

		public void Finish()
		{
			if (!_isFinal)
			{
				Pasuse();
				_isFinal = true;
			}
		}

		private void AddTime(DeltaTime deltaTime)
		{
			_taskDeltaTimes.Add(deltaTime);
		}

		public LogDateTime GetWorkFromTask()
		{
			LogDateTime time = new LogDateTime();
			foreach (var deltaTime in _taskDeltaTimes)
			{
				time += deltaTime.GetWorkTime();
			}

			return time;
		}

		public override string ToString()//TODO: Create regions
		{
			return GetName() + "\n(" + GetStartTaskTime() + " - " + GetEndTaskTime() + ") " +
			       (IsInProgress()
				       ? ""
				       : (IsFinal() ? "\nFinal, total work: " : "\nPause, total work: ") +
				         GetWorkFromTask());
		}
	}
}

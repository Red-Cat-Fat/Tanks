using System;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.Utility.LogSystem.TimeLogSystem
{
	public class Task
	{
		private string _name;
		private DeltaTime _currentDeltaTime;
		private List<DeltaTime> _taskDeltaTimes = new List<DeltaTime>();
		private bool _isFinal = false;

		public string GetName()
		{
			return _name;
		}

		public bool IsInProgress()
		{
			return _currentDeltaTime != null;
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
				fontStyle = IsInProgress()
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
					? "yellow"
					: "black";
			return $"<color={color}>{ToString()}</color>";
		}
		
		private DateTime GetEndTaskTime()
		{
			return !IsFinal()
				? DateTime.Now
				: _taskDeltaTimes[_taskDeltaTimes.Count-1].GetEndTime();
		}

		private DateTime GetStartTaskTime()
		{
			return _taskDeltaTimes.Count == 0 
				? _currentDeltaTime.GetStartTime() 
				: _taskDeltaTimes[0].GetStartTime();
		}
		
		public void Start()
		{
			if (_currentDeltaTime == null)
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
			Pasuse();
			_isFinal = true;
		}

		private void AddTime(DeltaTime deltaTime)
		{
			_taskDeltaTimes.Add(deltaTime);
		}

		public TimeSpan GetWorkFromTask()
		{
			TimeSpan time = new TimeSpan(0);
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
				         +GetWorkFromTask()
			       );
		}
	}
}

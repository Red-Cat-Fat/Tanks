using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.Utility.Logger.TimeLogSystem
{
	public class Task : ICloneable
	{
		private string _name;
		private DeltaTime _currentDeltaTime;
		private List<DeltaTime> _taskTimes = new List<DeltaTime>();

		public override string ToString()
		{
			var returnValue = _name + " (" + GetStartTaskTime() + ") ";
			if (!IsInProgress())
			{
				returnValue += " - Pause";
			}
			else
			{
				returnValue += " - " + _currentDeltaTime.GetWorkTime(DateTime.Now);
			}

			return returnValue;
		}

		private DateTime GetStartTaskTime()
		{
			if (_taskTimes.Count == 0)
			{
				return _currentDeltaTime.GetStartTime();
			}
			else
			{
				return _taskTimes[0].GetStartTime();
			}
		}

		private List<DeltaTime> GetTaskTimes()
		{
			return _taskTimes;
		}

		public Task(string name)
		{
			_name = name;
		}

		private Task(Task clone)
		{
			_name = clone.GetName();
			_taskTimes = clone.GetTaskTimes();
		}

		public void Start()
		{
			if (_currentDeltaTime == null)
			{
				_currentDeltaTime = new DeltaTime();
				_currentDeltaTime.Start();
			}
		}

		public void Stop()
		{
			if (_currentDeltaTime != null)
			{
				_currentDeltaTime.Stop();
				AddTime(_currentDeltaTime);
				_currentDeltaTime = null;
			}
		}

		private void AddTime(DeltaTime deltaTime)
		{
			_taskTimes.Add(deltaTime);
		}

		public TimeSpan GetWorkFromTask()
		{
			TimeSpan time = new TimeSpan(0);
			foreach (var deltaTime in _taskTimes)
			{
				time += deltaTime.GetWorkTime();
			}

			return time;
		}

		public string GetName()
		{
			return _name;
		}

		public bool IsInProgress()
		{
			return _currentDeltaTime != null
			       && _currentDeltaTime.InProgress();
		}

		public object Clone()
		{
			return new Task(this);
		}
	}
}

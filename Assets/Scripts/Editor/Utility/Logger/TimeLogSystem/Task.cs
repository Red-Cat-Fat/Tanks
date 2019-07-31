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

		private List<DeltaTime> GetTaskTimes()
		{
			return _taskTimes;
		}

		public Task(string name)
		{
			_currentDeltaTime = new DeltaTime();
			_name = name;
		}

		private Task(Task clone)
		{
			_name = clone.GetName();
			_taskTimes = clone.GetTaskTimes();
		}

		public void Start()
		{
			_currentDeltaTime.Start();
		}

		public void Stop()
		{
			_currentDeltaTime.Stop();
			AddTime(_currentDeltaTime);
			_currentDeltaTime = null;
		}

		public void Pause()
		{
			_currentDeltaTime.Stop();
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

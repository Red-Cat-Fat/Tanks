using System.Collections;
using System.Collections.Generic;
using Editor.Utility.Logger.TimeLogSystem;
using UnityEngine;

namespace Editor.Utility.Logger.TimeLogSystem
{
	public class TimeLoggerUtility
	{
		private List<Task> _tasks = new List<Task>();
		private static Task _currentTask;

		public Task GetCurrentTask()
		{
			return _currentTask;
		}

		public List<Task> GetTasksList()
		{
			return _tasks;
		}

		public void TryStartNewTask(string taskName)
		{
			if (_currentTask != null)
			{
				if (_currentTask.GetName() == taskName
				    && !_currentTask.IsInProgress())
				{
					_currentTask.Start();
				}
			}
			else
			{
				_currentTask = new Task(taskName);
				_currentTask.Start();
			}
		}

		public void TryPausedTask()
		{
			_currentTask.Stop();
		}

		public void TryStopedTask()
		{
			_currentTask.Stop();
			_tasks.Add((Task)_currentTask.Clone());
			_currentTask = null;
		}
	}
}
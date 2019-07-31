using System.Collections;
using System.Collections.Generic;
using Editor.Utility.Logger.TimeLogSystem;
using UnityEngine;

namespace Editor.Utility.Logger.TimeLogSystem
{
	public class TimeLoggerUtility
	{
		private List<Task> _tasks = new List<Task>();
		
		public List<Task> GetTasksList()
		{
			return _tasks;
		}

		public void TryStartNewTask(string taskName)
		{
			foreach (var task in _tasks)
			{
				if (task.GetName() == taskName)
				{
					return;
				}
			}
			var currentTask = new Task(taskName);
			currentTask.Start();
			_tasks.Add(currentTask);
		}


		public void TryStartTask(Task task)
		{
			task?.Start();
		}

		public void TryPausedTask(Task task)
		{
			task?.Pasuse();
		}

		public void TryStopedTask(Task task)
		{
			task?.Stop();
		}
	}
}
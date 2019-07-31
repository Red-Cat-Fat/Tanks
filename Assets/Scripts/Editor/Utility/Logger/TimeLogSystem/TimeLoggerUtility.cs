using System.Collections.Generic;

namespace Editor.Utility.Logger.TimeLogSystem
{
	public class TimeLoggerUtility
	{
		private List<Task> _tasks = new List<Task>();
		
		public List<Task> GetTasksList()
		{
			return _tasks;
		}

		public bool TryAddNewTask(string taskName)
		{
			foreach (var task in _tasks)
			{
				if (task.GetName() == taskName)
				{
					return false;
				}
			}
			var currentTask = new Task(taskName);
			currentTask.Start();
			_tasks.Add(currentTask);
			return true;
		}

		public bool TryStartTask(Task task)
		{
			task?.Start();
			return task != null;
		}

		public bool TryPausedTask(Task task)
		{
			task?.Pasuse();
			return task != null;
		}

		public bool TryFinishTask(Task task)
		{
			task?.Finish();
			return task != null;
		}
	}
}
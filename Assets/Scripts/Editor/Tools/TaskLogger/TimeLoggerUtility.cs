using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Editor.Tools.TaskLogger
{
	[Serializable]
	public class TimeLoggerUtility
	{
		[SerializeField]
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
			currentTask.Pasuse();
			_tasks.Add(currentTask);
			SaveInFile();
			return true;
		}

		public bool TryStartTask(Task task)
		{
			task?.Start();
			SaveInFile();
			return task != null;
		}

		public bool TryPausedTask(Task task)
		{
			task?.Pasuse();
			SaveInFile();
			return task != null;
		}

		public bool TryFinishTask(Task task)
		{
			task?.Finish();
			SaveInFile();
			return task != null;
		}

		public bool TryRemoveTask(Task task)
		{
			if (!_tasks.Contains(task))
			{
				return false;
			}
			_tasks.Remove(task);
			SaveInFile();
			return true;
		}

		public void SaveInFile()
		{
			var path = Path.Combine(Application.dataPath, "TimeLoggerUtility.json");
			File.WriteAllText(path, JsonUtility.ToJson(this));
		}
		
		public void SortingTasks()
		{
			_tasks.Sort(delegate (Task x, Task y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				if (y == null)
				{
					return 1;
				}

				if (x.IsFinal())
				{
					if (y.IsFinal())
					{
						if (x.IsInProgress())
						{
							if (y.IsInProgress())
							{
								return 0;
							}
							return 1;
						}
						if (y.IsInProgress())
						{
							return -1;
						}
					}
					return 1;
				}
				if (y.IsFinal())
				{
					return -1;
				}

				if (x.IsInProgress())
				{
					if (y.IsInProgress())
					{
						return 0;
					}
					return -1;
				}
				if (y.IsInProgress())
				{
					return 1;
				}
				return 0;
			});
		}

		public static TimeLoggerUtility LoadFile()
		{
			var path = Path.Combine(Application.persistentDataPath, "TimeLoggerUtility.json");
			var returnValue = File.Exists(path) ? JsonUtility.FromJson<TimeLoggerUtility>(File.ReadAllText(path)) : null;
			return returnValue;
		}

	}
}
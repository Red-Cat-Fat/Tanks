using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TimeLoggerUtility : EditorWindow
{
	private class Task : ICloneable
	{
		private class DeltaTime : ICloneable
		{
			private DateTime _startTime;
			private DateTime _endTime;
			private bool _inProgress = false;
			public DeltaTime() { }

			private DeltaTime(DateTime startTime, DateTime endTime)
			{
				_startTime = startTime;
				_endTime = endTime;
			}

			public bool InProgress()
			{
				return _inProgress;
			}

			public void Start()
			{
				_startTime = DateTime.Now;
			}

			public void Stop()
			{
				_endTime = DateTime.Now;
				_inProgress = false;
			}

			public TimeSpan GetWorkTime()
			{
				return _endTime.Subtract(_startTime);
			}

			public object Clone()
			{
				return new DeltaTime(_startTime, _endTime);
			}
		}

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

	[MenuItem("TANKS/Unitity/Timer")]
	public static void ShowWindow()
	{
		GetWindow<TimeLoggerUtility>();
	}

	private List<Task> _tasks = new List<Task>();
	private static Task _currentTask;
	private static string _currentTextInFiledTask = "";

	private void OnGUI()
	{
		var now = DateTime.Now;
		GUILayout.Label($"Current time: {now}");

		GUILayout.Label(_currentTask != null ? 
			$"Current task: {_currentTask.GetName()}" 
			: "Current task: null");

		GUILayout.BeginHorizontal();
		var newTask = GUILayout.TextArea(_currentTextInFiledTask);
		_currentTextInFiledTask = newTask;
		if (GUILayout.Button("Start", GUILayout.Width(50)))
		{
			TryStartNewTask();
		}
		if (GUILayout.Button("Pause", GUILayout.Width(50)))
		{
			TryPausedTask();
		}
		if (GUILayout.Button("Stop", GUILayout.Width(50)))
		{
			TryStopedTask();
		}
		GUILayout.EndHorizontal();

		foreach (var task in _tasks)
		{
			GUILayout.Label(task.GetName() + ": " + task.GetWorkFromTask());
		}
	}

	private void TryStartNewTask()
	{
		if (_currentTask != null)
		{
			if (_currentTask.GetName() == _currentTextInFiledTask
			    && !_currentTask.IsInProgress())
			{
				_currentTask.Start();
			}
		}
		else
		{
			_currentTask = new Task(_currentTextInFiledTask);
			_currentTask.Start();
		}
	}

	private void TryPausedTask()
	{
		_currentTask.Pause();
	}

	private void TryStopedTask()
	{
		_currentTask.Stop();
		_tasks.Add((Task)_currentTask.Clone());
		_currentTask = null;
	}
}

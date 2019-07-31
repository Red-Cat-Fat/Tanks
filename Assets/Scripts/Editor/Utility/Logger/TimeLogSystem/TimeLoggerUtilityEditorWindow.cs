using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor.Utility.Logger.TimeLogSystem
{
	public class TimeLoggerUtilityEditorWindow : EditorWindow
	{
		[MenuItem("TANKS/Unitity/Timer")]
		public static void ShowWindow()
		{
			GetWindow<TimeLoggerUtilityEditorWindow>();
		}

		private List<Task> _tasks = new List<Task>();
		private static Task _currentTask;
		private static string _currentTextInFiledTask = "";

		private void OnGUI()
		{
			var now = DateTime.Now;
			GUILayout.Label($"Current time: {now}");

			GUILayout.Label(_currentTask != null
				? $"Current task: {_currentTask.GetName()}"
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
			_tasks.Add((Task) _currentTask.Clone());
			_currentTask = null;
		}
	}
}

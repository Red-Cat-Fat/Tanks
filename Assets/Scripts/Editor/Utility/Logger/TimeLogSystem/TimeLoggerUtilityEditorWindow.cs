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

		private TimeLoggerUtility _timeLoggerUtility = new TimeLoggerUtility();
		private static string _currentTextInFiledTask = "";
		private void OnGUI()
		{
			var now = DateTime.Now;
			GUILayout.Label($"Current time: {now}");
			var currentTask = _timeLoggerUtility.GetCurrentTask();
			GUILayout.Label(currentTask != null
				? $"Current task: { currentTask }"
				: "Current task: null");

			GUILayout.BeginHorizontal();
			var newTask = GUILayout.TextArea(_currentTextInFiledTask);
			_currentTextInFiledTask = newTask;

			if (GUILayout.Button("Start", GUILayout.Width(50)))
			{
				_timeLoggerUtility.TryStartNewTask(_currentTextInFiledTask);
			}

			if (GUILayout.Button("Pause", GUILayout.Width(50)))
			{
				_timeLoggerUtility.TryPausedTask();
			}

			if (GUILayout.Button("Stop", GUILayout.Width(50)))
			{
				_timeLoggerUtility.TryStopedTask();
			}

			GUILayout.EndHorizontal();

			foreach (var task in _timeLoggerUtility.GetTasksList())
			{
				GUILayout.Label(task.GetName() + ": " + task.GetWorkFromTask());
			}
		}

	}
}

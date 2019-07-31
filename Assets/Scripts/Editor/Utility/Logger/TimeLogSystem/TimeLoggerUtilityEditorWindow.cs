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
			DrawTime();
			DrawTaskList();
			DrawEditorLine();
		}

		private void DrawTime()
		{
			var now = DateTime.Now;
			GUILayout.Label($"Time: {now}");
		}

		private void DrawTaskList()
		{
			foreach (var task in _timeLoggerUtility.GetTasksList())
			{
				GUILayout.Label(task.ToString());
			}
		}

		private void DrawEditorLine()
		{
			var currentTask = _timeLoggerUtility.GetCurrentTask();
			GUILayout.BeginHorizontal();
			if (currentTask == null)
			{
				_currentTextInFiledTask = GUILayout.TextArea(_currentTextInFiledTask);
			}
			else
			{
				GUILayout.Label($"Current task: {currentTask}");
			}

			if (currentTask == null || !currentTask.IsInProgress())
			{
				if (GUILayout.Button("Start", GUILayout.Width(50)))
				{
					_timeLoggerUtility.TryStartNewTask(_currentTextInFiledTask);
				}
			}
			else
			{
				if (GUILayout.Button("Pause", GUILayout.Width(50)))
				{
					_timeLoggerUtility.TryPausedTask();
				}
			}

			if (GUILayout.Button("Stop", GUILayout.Width(50)))
			{
				_timeLoggerUtility.TryStopedTask();
			}

			GUILayout.EndHorizontal();
		}

	}
}

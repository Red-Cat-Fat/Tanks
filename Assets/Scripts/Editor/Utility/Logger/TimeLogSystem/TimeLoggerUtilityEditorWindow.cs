using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Utility.LogSystem.TimeLogSystem
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
			DrawNewTaskField();
		}

		private void DrawTime()
		{
			var now = DateTime.Now;
			GUILayout.Label($"Time: {now}");
		}

		private void DrawTaskByCurrentStyle(Task task)
		{
			var str = task.GetGuiLabelString();
			var style = task.GetGuiLabelStyle();
			GUILayout.Label(str, style);
		}

		private void DrawTaskButons(Task task)
		{
			if (task.IsInProgress())
			{
				if (GUILayout.Button("Pause", GUILayout.Width(50)))
				{
					_timeLoggerUtility.TryPausedTask(task);
				}
			}
			else
			{
				if (GUILayout.Button("Start", GUILayout.Width(50)))
				{
					_timeLoggerUtility.TryStartTask(task);
				}
			}

			if (GUILayout.Button("Final", GUILayout.Width(50)))
			{
				_timeLoggerUtility.TryFinishTask(task);
			}
		}

		private void DrawTaskList()
		{
			foreach (var task in _timeLoggerUtility.GetTasksList())
			{
				GUILayout.BeginHorizontal();
				DrawTaskByCurrentStyle(task);
				DrawTaskButons(task);
				GUILayout.EndHorizontal();
			}
		}

		private void DrawNewTaskField()
		{
			GUILayout.BeginHorizontal();

			_currentTextInFiledTask = GUILayout.TextArea(_currentTextInFiledTask);

			if (GUILayout.Button("Add", GUILayout.Width(50)))
			{
				_timeLoggerUtility.TryAddNewTask(_currentTextInFiledTask);
			}

			GUILayout.EndHorizontal();
		}

	}
}

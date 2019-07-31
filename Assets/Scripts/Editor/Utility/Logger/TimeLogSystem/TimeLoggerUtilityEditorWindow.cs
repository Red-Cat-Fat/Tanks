using System;
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
				GUIStyle style = new GUIStyle
				{
					richText = true,
					fontStyle = task.IsInProgress()
						? FontStyle.Bold
						: FontStyle.Normal
				};
				var color = task.IsFinal()
					? "green"
					: task.IsInProgress()
						? "yellow"
						: "black";

				GUILayout.BeginHorizontal();
				GUILayout.Label($"<color={color}>{task}</color>", style);
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
					_timeLoggerUtility.TryStopedTask(task);
				}

				GUILayout.EndHorizontal();
			}
		}

		private void DrawEditorLine()
		{
			GUILayout.BeginHorizontal();

			_currentTextInFiledTask = GUILayout.TextArea(_currentTextInFiledTask);

			if (GUILayout.Button("Add", GUILayout.Width(50)))
			{
				_timeLoggerUtility.TryStartNewTask(_currentTextInFiledTask);
			}

			GUILayout.EndHorizontal();
		}

	}
}

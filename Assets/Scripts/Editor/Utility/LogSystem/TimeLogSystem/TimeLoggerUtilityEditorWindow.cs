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

		private TimeLoggerUtility _timeLoggerUtility;
		private static string _currentTextInFiledTask = "";
		private const int LengthTaskName = 50;
		private const float LengthStringSymbol = 7f;
		private const int FreeSpace = 15;
		private const int ButtonSize = 60;

		private void OnGUI()
		{
			if (_timeLoggerUtility == null)
			{
				var jsonLogs = TimeLoggerUtility.LoadFile();
				_timeLoggerUtility = jsonLogs ?? new TimeLoggerUtility();
			}

			DrawTime();
			DrawTaskList();
			DrawNewTaskField();
		}

		private void DrawTime()
		{
			LogDateTime now = DateTime.Now;
			GUILayout.Label($"Time: {now}");
		}


		private void DrawTaskByCurrentStyle(Task task)
		{
			var str = task.GetGuiLabelString();
			var style = task.GetGuiLabelStyle();
			GUILayout.Label(str, style, GUILayout.Width(LengthStringSymbol*LengthTaskName + FreeSpace));
		}

		private void DrawTaskButons(Task task)
		{
			GUILayout.BeginVertical();
			string buttonName = "";
			if (task != null && task.IsInProgress())
			{
				buttonName = "Pause";
				if (GUILayout.Button(buttonName, GUILayout.Width(ButtonSize)))
				{
					_timeLoggerUtility.TryPausedTask(task);
				}
			}
			else
			{
				buttonName = "Start";
				if (GUILayout.Button(buttonName, GUILayout.Width(ButtonSize)))
				{
					_timeLoggerUtility.TryStartTask(task);
				}
			}

			buttonName = "Final";
			if (GUILayout.Button(buttonName, GUILayout.Width(ButtonSize)))
			{
				_timeLoggerUtility.TryFinishTask(task);
			}
			GUILayout.EndVertical();
		}

		private Vector2 _scrollPos;
		private void DrawTaskList()
		{
			_scrollPos =
				EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.Width(LengthTaskName * LengthStringSymbol + FreeSpace + ButtonSize*2));
			foreach (var task in _timeLoggerUtility.GetTasksList())
			{
				DrawLine();
				GUILayout.BeginHorizontal();
				GUILayout.Space(FreeSpace);
				DrawTaskByCurrentStyle(task);
				DrawTaskButons(task);
				GUILayout.EndHorizontal();
			}
			EditorGUILayout.EndScrollView();
		}

		private void DrawLine()
		{
			GUILayout.BeginHorizontal();
			var s = "";
			for (int i = 0; i < LengthTaskName+3; i++)
			{
				s += "_";
			}
			GUILayout.Label(s + "\n");
			GUILayout.EndHorizontal();
		}

		private void DrawNewTaskField()
		{
			GUILayout.BeginHorizontal();

			_currentTextInFiledTask = CutTaskName(
				GUILayout.TextArea(_currentTextInFiledTask, 
				GUILayout.Width(LengthTaskName*LengthStringSymbol)));
			if (GUILayout.Button("Add", GUILayout.Width(ButtonSize)))
			{
				_timeLoggerUtility.TryAddNewTask(_currentTextInFiledTask);
			}

			GUILayout.EndHorizontal();
		}


		private string CutTaskName(string currentTextInFiledTask)
		{
			return currentTextInFiledTask.Length > LengthTaskName 
				? currentTextInFiledTask.Substring(0, LengthTaskName) 
				: currentTextInFiledTask;
		}

	}
}

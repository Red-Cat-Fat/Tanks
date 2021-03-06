﻿using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Tools.TaskLogger
{
	public class TimeLoggerUtilityEditorWindow : EditorWindow
	{
		[MenuItem("Tools/Task time logger")]
		public static void ShowWindow()
		{
			CreateWindow();
		}

		private const string WindowTitle = "Task time logger";
		private static TimeLoggerUtilityEditorWindow _windowInstance;
		public static void CreateWindow()
		{
			if (_windowInstance != null)
			{
				_windowInstance.Focus();
			}
			else
			{
				_windowInstance = GetWindow<TimeLoggerUtilityEditorWindow>(typeof(SceneView));
				_windowInstance.titleContent = new GUIContent(WindowTitle);
			}
		}

		private TimeLoggerUtility _timeLoggerUtility;
		private static string _currentTextInFiledTask = "";
		private const int LengthTaskName = 50;
		private const float LengthStringSymbol = 7f;
		private const int ButtonSize = 60;
		private Vector2 _scrollPos;

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

		private void DrawSortButton()
		{
			if (GUILayout.Button("Sort", GUILayout.MinWidth(ButtonSize)))
			{
				_timeLoggerUtility.SortingTasks();
			}
		}

		private void DrawTime()
		{
			LogDateTime now = DateTime.Now;
			GUILayout.BeginVertical(EditorStyles.helpBox);
			GUILayout.Label($"Time: {now}");
			GUILayout.EndVertical();
		}
		
		private void DrawTaskByCurrentStyle(Task task)
		{
			GUIStyle styleTaskBorder = EditorStyles.helpBox;
			styleTaskBorder.alignment = TextAnchor.LowerLeft;

			GUILayout.BeginVertical(styleTaskBorder);
			var str = task.GetGuiLabelString();
			var style = task.GetGuiLabelStyle();
			GUILayout.Label(str, style, GUILayout.MinWidth(LengthStringSymbol*LengthTaskName));
			GUILayout.EndVertical();
		}

		private void DrawTaskButons(Task task)
		{
			GUIStyle styleTaskBorder = EditorStyles.helpBox;
			styleTaskBorder.alignment = TextAnchor.LowerRight;
			GUILayout.BeginVertical(GUILayout.MaxWidth(ButtonSize));
			var buttonName = "Delete";
			if (GUILayout.Button(buttonName, GUILayout.MinWidth(ButtonSize)))
			{
				_timeLoggerUtility.TryRemoveTask(task);
			}

			if (task != null && task.IsInProgress())
			{
				buttonName = "Pause";
				if (GUILayout.Button(buttonName, GUILayout.MinWidth(ButtonSize)))
				{
					_timeLoggerUtility.TryPausedTask(task);
				}
			}
			else
			{
				buttonName = "Start";
				if (GUILayout.Button(buttonName, GUILayout.MinWidth(ButtonSize)))
				{
					_timeLoggerUtility.TryStartTask(task);
				}
			}

			buttonName = "Final";
			if (GUILayout.Button(buttonName, GUILayout.MinWidth(ButtonSize)))
			{
				_timeLoggerUtility.TryFinishTask(task);
			}
			GUILayout.EndVertical();
		}

		private void DrawTaskList()
		{
			GUILayout.BeginVertical(EditorStyles.helpBox);
			_scrollPos =
				EditorGUILayout.BeginScrollView(_scrollPos);
			var list = _timeLoggerUtility.GetTasksList();

			for (var i = 0; i < list.Count; i++)
			{
				var task = list[i];
				GUILayout.BeginHorizontal(EditorStyles.helpBox);
				DrawTaskByCurrentStyle(task);
				DrawTaskButons(task);
				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();

			EditorGUILayout.EndScrollView();
			DrawSortButton();
		}

		private void DrawNewTaskField()
		{
			GUILayout.BeginHorizontal();

			_currentTextInFiledTask = CutTaskName(
				GUILayout.TextArea(_currentTextInFiledTask, 
				GUILayout.MinWidth(LengthTaskName*LengthStringSymbol)));

			GUILayout.BeginVertical(GUILayout.MaxWidth(ButtonSize));
			if (GUILayout.Button("Add", GUILayout.MinWidth(ButtonSize)))
			{
				_timeLoggerUtility.TryAddNewTask(_currentTextInFiledTask);
				_currentTextInFiledTask = "";
			}
			GUILayout.EndVertical();

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

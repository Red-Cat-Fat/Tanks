using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using Game.Controllers.Units;

namespace Editor.Tools.TankBuilder
{
	public class TankBuilderEditorWindow : EditorWindow
	{
		private const string WindowTitle = "Task time logger";
		private static TankBuilderEditorWindow _windowInstance;

		[MenuItem("Tools/Tank builder")]
		public static void ShowWindow()
		{
			CreateWindow();
		}

		public static void CreateWindow()
		{
			if (_windowInstance != null)
			{
				_windowInstance.Focus();
			}
			else
			{
				_windowInstance = GetWindow<TankBuilderEditorWindow>(typeof(SceneView));
				_windowInstance.titleContent = new GUIContent(WindowTitle);
			}
		}

	
		private void OnGUI()
		{
			/*
			if (_timeLoggerUtility == null)
			{
				var jsonLogs = TimeLoggerUtility.LoadFile();
				_timeLoggerUtility = jsonLogs ?? new TimeLoggerUtility();
			}

			DrawTime();
			DrawTaskList();
			DrawNewTaskField();*/
		}

	}
}

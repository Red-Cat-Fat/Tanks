using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Editor.Utility.LogSystem
{
	public class Log : MonoBehaviour
	{
		[Conditional("DEBUG")]
		public static void CheckForNull(object checkObject, GameObject parrent, Type type)
		{
			if (checkObject == null)
			{
				Debug.LogError(type + " on " + parrent.name + " is null");
			}
		}

		public static void SendMessageToConsole(MonoBehaviour sender, string message)
		{
			Debug.Log(sender.name + " send: " + message);
		}
	}
}
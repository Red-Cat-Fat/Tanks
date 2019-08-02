using System;
using UnityEngine;

namespace Editor.Utility.LogSystem
{
	public class Log : MonoBehaviour
	{
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
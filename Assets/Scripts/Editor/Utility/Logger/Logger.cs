using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.Utility.Logger
{
	public class Logger : MonoBehaviour
	{
		public static void CheckForNull(object checkObject, GameObject parrent, Type type)
		{
			if(checkObject == null)
			{
				Debug.LogError(type + " on " + parrent.name + " is null");
			}
		}
	}
}
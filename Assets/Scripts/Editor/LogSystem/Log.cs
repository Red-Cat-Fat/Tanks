using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.LogSystem
{
	public class Log : MonoBehaviour
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
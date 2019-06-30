using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.LogSystem
{
	public class Log : MonoBehaviour
	{
		public static void CheckForNull(object checkObject, GameObject parrent)
		{
			if(checkObject == null)
			{
				Debug.LogError(checkObject.GetType() + " on " + parrent.name + " is null");
			}
		}
	}
}
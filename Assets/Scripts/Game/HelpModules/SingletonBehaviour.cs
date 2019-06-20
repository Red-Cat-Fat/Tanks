using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.HelpModules
{
	public class SingletonBehaviour<T> : MonoBehaviour
		where T : SingletonBehaviour<T>
	{

		private static T _instance;

		public static T Instance => _instance == null ? _instance = FindObjectOfType<T>() : _instance;
	}
}

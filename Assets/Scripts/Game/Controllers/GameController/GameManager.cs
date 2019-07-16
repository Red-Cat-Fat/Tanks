using System.Collections;
using System.Collections.Generic;
using Game.HelpModules;
using UnityEngine;

namespace Game.Controllers.GameControllers
{
	public class GameManager : SingletonBehaviour<GameManager>
	{
		public GameObject PlayerGameObject;
		private List<GameObject> _enemys;

		public void AddEnemy(GameObject enemy)
		{
			_enemys.Add(enemy);
		}

		private GameObject GetMinDistanceEnemy(Vector3 position)
		{
			GameObject returnValue = null;
			var minDistance = float.MaxValue;

			foreach (var enemy in _enemys)
			{
				var distanceVector = enemy.transform.position - position;
				var sqrMagnitude = distanceVector.sqrMagnitude;
				if (sqrMagnitude < minDistance)
				{
					returnValue = enemy;
					minDistance = sqrMagnitude;
				}
			}

			return returnValue;
		}
	}
}
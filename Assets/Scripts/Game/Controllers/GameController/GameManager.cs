using System.Collections;
using System.Collections.Generic;
using Game.HelpModules;
using UnityEngine;

namespace Game.Controllers.GameControllers
{
	public class GameManager : SingletonBehaviour<GameManager>
	{
		private GameObject _playerGameObject;
		private List<GameObject> _enemys = new List<GameObject>();

		public void SetPlayer(GameObject player)
		{
			_playerGameObject = player;
		}

		public GameObject GetPlayerGameObject()
		{
			return _playerGameObject;
		}

		public void AddEnemy(GameObject enemy)
		{
			_enemys.Add(enemy);
		}

		public GameObject GetMinDistanceEnemy(Vector3 position)
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
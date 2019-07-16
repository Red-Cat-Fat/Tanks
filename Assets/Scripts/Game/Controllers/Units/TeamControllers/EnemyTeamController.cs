using System.Collections;
using System.Collections.Generic;
using Game.Controllers.GameControllers;
using UnityEngine;

namespace Game.Controllers.Units.TeamControllers
{
	public class EnemyTeamController : MonoBehaviour, ITeamController
	{
		public void InitialAction()
		{
			GameManager.Instance.AddEnemy(gameObject);
		}
	}
}
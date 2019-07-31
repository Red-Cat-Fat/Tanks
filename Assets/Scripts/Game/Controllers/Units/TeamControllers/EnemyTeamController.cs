using Game.Controllers.GameControllers;
using Game.Systems;
using UnityEngine;

namespace Game.Controllers.Units.TeamControllers
{
	public class EnemyTeamController : MonoBehaviour, ITeamController
	{
		public void InitialAction()
		{
			GameManager.Instance.AddEnemy(gameObject);
			var healthSystem = GetComponent<HealthSystem>();
			if (healthSystem != null)
			{
				healthSystem.AddDeadEvent(() => GameManager.Instance.DestroyEnemy(gameObject));
			}
		}
	}
}
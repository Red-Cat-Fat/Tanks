using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class EnemyFollowPlayerController : BaseMoveController
	{
		[SerializeField] private GameObject _player;
		public override Vector3 CulculateTarget()
		{
			return _player.transform.position;
		}
	}
}

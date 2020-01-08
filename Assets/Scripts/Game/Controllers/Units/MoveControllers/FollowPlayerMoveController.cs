using Game.Controllers.GameControllers;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class FollowPlayerMoveController : BaseMoveController
	{
		[SerializeField, HideInInspector] private GameObject _player;

		private void Start()
		{
			_player = GameManager.Instance.GetPlayerGameObject();
			if (_player == null)
			{
				Debug.LogError("Player in game manager is null");
			}
		}

		public override Vector3 CulculateTarget()
		{
			return _player.transform.position;
		}
	}
}

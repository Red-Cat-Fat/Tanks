using System.Collections;
using System.Collections.Generic;
using Editor.LogSystem;
using Game.Controllers.GameControllers;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class FollowPlayerController : BaseMoveController
	{
		private GameObject _player;
		protected override void Start()
		{
			base.Start();
			_player = GameManager.Instance.PlayerGameObject;
			Log.CheckForNull(_player, gameObject, typeof(GameObject));
		}
		public override Vector3 CulculateTarget()
		{
			return _player.transform.position;
		}
	}
}
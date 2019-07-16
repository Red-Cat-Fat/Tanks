using System.Collections;
using System.Collections.Generic;
using Editor.LogSystem;
using Game.Controllers.GameControllers;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class FollowPlayerController : BaseMoveController
	{
		public override Vector3 CulculateTarget()
		{
			var player = GameManager.Instance.GetPlayerGameObject();
			return player.transform.position;
		}
	}
}
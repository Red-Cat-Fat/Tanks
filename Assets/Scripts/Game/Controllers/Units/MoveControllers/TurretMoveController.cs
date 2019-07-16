using System.Collections;
using System.Collections.Generic;
using Game.Controllers.GameControllers;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class TurretMoveController : BaseMoveController
	{
		[SerializeField]private GameObject _pivot;
		public override Vector3 CulculateTarget()
		{
			var player = GameManager.Instance.GetMinDistanceEnemy(transform.position);
			Debug.DrawLine(player.transform.position, _pivot.transform.position);
			return player.transform.position;
		}

		public override Vector3 GetNextPosirionVector3(Vector3 forwardVector3)
		{
			return _pivot.transform.position;
		}
	}
}
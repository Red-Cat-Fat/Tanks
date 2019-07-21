using System.Collections;
using System.Collections.Generic;
using Game.Controllers.GameControllers;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class PlayerTurretMoveController : BaseMoveController
	{
		public override Vector3 CulculateTarget()
		{
			var target = GameManager.Instance.GetMinDistanceEnemy(transform.position);
			var direction = target != null
				? target.transform.position
				: UnitMoveData.GetForwardDirectionVector3(transform) + transform.position;
			return direction;
		}
	}
}
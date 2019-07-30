using System.Collections;
using System.Collections.Generic;
using Game.Controllers.GameControllers;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class PlayerTurretMoveController : BaseMoveController
	{
		private Vector3 _lastPositionVector3 = Vector3.zero;
		public void Update()
		{
			var currentPosition = transform.position;
			UnitMoveData.SetIsCanRotate(currentPosition == _lastPositionVector3);
			_lastPositionVector3 = currentPosition;
		}

		public override Vector3 CulculateTarget()
		{
			if (UnitMoveData.GetIsCanRotate())
			{
				var target = GameManager.Instance.GetMinDistanceEnemy(transform.position);
				if (target != null)
				{
					return target.transform.position;
				}
			}
			return UnitMoveData.GetForwardDirectionVector3(transform) + transform.position;
		}
	}
}
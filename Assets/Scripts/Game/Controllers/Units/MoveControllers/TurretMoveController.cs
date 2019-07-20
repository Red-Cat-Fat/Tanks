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
			var target = GameManager.Instance.GetMinDistanceEnemy(transform.position);
			Debug.DrawLine(target.transform.position, _pivot.transform.position);
			return target.transform.position;
		}

		public override Vector3 GetNextPosirionVector3(Vector3 forwardVector3)
		{
			return _pivot.transform.position;
		}
	}
}
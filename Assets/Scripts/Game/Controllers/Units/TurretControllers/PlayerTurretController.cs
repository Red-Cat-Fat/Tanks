using Game.Controllers.GameControllers;
using Game.Controllers.Units.MoveControllers;
using Game.Data.Units;
using UnityEngine;

namespace Game.Controllers.Units.TurretController
{
	[RequireComponent(typeof(TurretData), typeof(MoveData))]
	public class PlayerTurretController : BaseTurretController
	{
		protected override Vector3 CulculateTarget()
		{
			if (_unitTurretData.GetIsCanRotate())
			{
				var target = GameManager.Instance.GetMinDistanceEnemy(transform.position);
				if (target != null)
				{
					return target.transform.position;
				}
			}
			return _unitMoveData.GetForwardDirectionVector(transform) + transform.position;
		}
	}
}
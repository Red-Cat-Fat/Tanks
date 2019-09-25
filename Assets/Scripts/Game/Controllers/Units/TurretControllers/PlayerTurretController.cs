using Game.Controllers.GameControllers;
using Game.Controllers.Units.MoveControllers;
using Game.Data.Units;
using UnityEngine;

namespace Game.Controllers.Units.TurretController
{
	[RequireComponent(typeof(TurretData), typeof(MoveData))]
	public class PlayerTurretController : MonoBehaviour, ITurretController
	{
		private TurretData _unitTurretData;
		private MoveData _unitMoveData;

		protected virtual void OnValidate()
		{
			_unitTurretData = GetComponent<TurretData>();
			_unitMoveData = GetComponent<MoveData>();
		}
		
		private Vector3 CulculateTarget()
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

		public Quaternion GetNextRotationQuaternion(Vector3 axisVector3)
		{
			if (_unitMoveData.GetIsMove())
			{
				return _unitTurretData.GetRotationTurret();
			}

			var directionVector = CulculateTarget() - transform.position;
			var rotationAngle = directionVector.GetAngleInGameSystemInDeg();
			var rotation = Quaternion.AngleAxis(rotationAngle, axisVector3);

			var teleportToRotation = Quaternion.Slerp(_unitTurretData.GetRotationTurret(), rotation,
				Time.fixedDeltaTime * _unitTurretData.GetSpeedRotation());
			return teleportToRotation;
		}
	}
}
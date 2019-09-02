using Game.Controllers.GameControllers;
using Game.Data.Units;
using Game.Utillity.DigitalSignalPeocessing.Filters;
using UnityEngine;

namespace Game.Controllers.Units.TurretController
{
	public class PlayerTurretController : MonoBehaviour, ITurretController
	{
		private TurretData _unitTurretData;
		private MoveData _unitMoveData;
		private Vector3 _lastPositionVector3 = Vector3.zero;
		private const int CountThueCheckerTrigger = 3;
		private BoolMovingAvargeWindow _boolRotateMovingAvargeWindow = new BoolMovingAvargeWindow(CountThueCheckerTrigger);

		protected virtual void Start()
		{
			_unitTurretData = GetComponent<TurretData>();
			_unitMoveData = GetComponent<MoveData>();
		}


		public void Update()
		{
			TryChangeCanRotate();
		}

		private bool IsStay()
		{
			//TODO: Change to new method check input
			return transform.position == _lastPositionVector3; 
		}

		private void TryChangeCanRotate()
		{
			var canRotate = IsStay();

			_boolRotateMovingAvargeWindow.AddValue(canRotate);
			_unitTurretData.SetIsCanRotate(_boolRotateMovingAvargeWindow.GetValue());
			_lastPositionVector3 = transform.position;
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
			return _unitMoveData.GetForwardDirectionVector3(transform) + transform.position;
		}

		public Quaternion GetNextRotationQuaternion(Vector3 axisVector3)
		{
			var directionVector3 = CulculateTarget() - transform.position;//_unitTurretData.GetPositionTurret();
			if (directionVector3 == Vector3.zero) return transform.rotation;

			var rotationAngle = Mathf.Atan2(directionVector3.y, directionVector3.x);
			rotationAngle = rotationAngle * Mathf.Rad2Deg;
			var rotation = Quaternion.AngleAxis(rotationAngle, axisVector3);

			var teleportToRotation = Quaternion.Slerp(_unitTurretData.GetRotationTurret(), rotation,
				Time.fixedDeltaTime * _unitTurretData.GetSpeedRotation());
			return teleportToRotation;
		}
	}
}
using Game.Controllers.Units.TurretController;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	public class TurretSystem : MoveSystem
	{
		private ITurretController _turretController;
		private TurretData _unitTurretData;

		private void Awake()
		{
			_turretController = GetComponent<ITurretController>();
			_unitTurretData = GetComponent<TurretData>();
		}
		
		protected override void UpdateTransform()
		{
			if (_unitTurretData.GetIsCanRotate())
			{
				var normalDirectionVector3 = UnitsMoveData.GetNormalDirectionVector3();
				var rotation = _turretController.GetNextRotationQuaternion(normalDirectionVector3);

				Rotate(rotation);
			}
		}

		protected override void Rotate(Quaternion rotationQuaternion)
		{
			_unitTurretData.SetRotateTurret(rotationQuaternion);
			//transform.rotation = rotationQuaternion;
		}
	}
}

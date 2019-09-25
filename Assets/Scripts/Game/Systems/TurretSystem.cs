using Game.Controllers.Units.TurretController;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	[RequireComponent(typeof(TurretData))]
	public class TurretSystem : MoveSystem
	{
		private ITurretController _turretController;
		[SerializeField, HideInInspector]
		private TurretData _unitTurretData;

		protected virtual void OnValidate()
		{
			_unitTurretData = GetComponent<TurretData>();
			UnitsMoveData = GetComponent<MoveData>();
		}

		private void Awake()
		{
			_turretController = GetComponent<ITurretController>();
		}
		
		protected override void UpdateTransform()
		{
			if (_unitTurretData.GetIsCanRotate())
			{
				var normalDirectionVector3 = UnitsMoveData.GetNormalDirectionVector();
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

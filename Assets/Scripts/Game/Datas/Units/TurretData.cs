using UnityEngine;

namespace Game.Data.Units
{
	public class TurretData : MonoBehaviour, IUnitsData
	{
		[SerializeField] public float _slowdownSpeedCoef = 1f;
		[SerializeField] public float _slowdownStartAngle = 45;
		[SerializeField] private float _speedRotate = 3f;
		[SerializeField] private bool _isCanRotate = true;
		[SerializeField] private GameObject _turretPivot;

		public Vector3 GetPositionTurret()
		{
			return _turretPivot.transform.position;
		}

		public Quaternion GetRotationTurret()
		{
			return _turretPivot.transform.rotation;
		}

		public void SetRotateTurret(Quaternion rotationQuaternion)
		{
			_turretPivot.transform.rotation = rotationQuaternion;
		}

		public float GetSpeedRotation()
		{
			return _speedRotate;
		}

		public void SetIsCanRotate(bool value)
		{
			_isCanRotate = value;
		}

		public bool GetIsCanRotate()
		{
			return _isCanRotate;
		}
	}
}

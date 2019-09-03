using Game.Data.Units;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	[RequireComponent(typeof(MoveData))]
	public class MetalBulletMoveController : MonoBehaviour, IMoveController
	{
		[SerializeField, HideInInspector]
		private MoveData _moveData;
		private void OnValidate()
		{
			_moveData = GetComponent<MoveData>();
		}

		public Vector3 CulculateTarget()
		{
			return _moveData.GetForwardDirectionVector3(transform) * Time.fixedDeltaTime * _moveData.GetSpeedMove();
		}

		public Vector3 GetNextPosirionVector3(Vector3 forwardVector3)
		{
			return transform.position + CulculateTarget();
		}

		public Quaternion GetNextRotationQuaternion(Vector3 axisVector3)
		{
			return transform.rotation;
		}
	}
}
using Editor.LogSystem;
using Game.Data.Units;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class MetalBulletMoveController : MonoBehaviour, IMoveController
	{
		private MoveData _moveData;
		private void Start()
		{
			_moveData = GetComponent<MoveData>();
			Log.CheckForNull(_moveData, gameObject);
		}

		public Vector3 CulculateTarget()
		{
			return transform.forward * Time.fixedDeltaTime * _moveData.GetSpeedMove();
		}

		public Vector3 GetNextPosirionVector3()
		{
			return transform.position + CulculateTarget();
		}

		public Quaternion GetNextRotationQuaternion()
		{
			return transform.rotation;
		}
	}
}
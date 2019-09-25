using Game.Data.Units;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


namespace Game.Controllers.Units.MoveControllers
{
	[RequireComponent(typeof(MoveData))]
	public abstract class BaseMoveController : MonoBehaviour, IMoveController
	{
		[SerializeField, HideInInspector]
		protected MoveData UnitsMoveData;

		protected virtual void OnValidate()
		{
			UnitsMoveData = GetComponent<MoveData>();
		}

		/// <summary>
		///	Calculate final position for path
		/// </summary>
		/// <returns>Final position</returns>
		public virtual Vector3 CulculateTarget()
		{
			return transform.position;
		}
		
		/// <summary>
		/// Calculate next position in path
		/// </summary>
		/// <returns>Next position</returns>
		public virtual Vector3 GetNextPosirionVector3()
		{
			var directionVector3 = CulculateTarget() - transform.position;
			if (directionVector3 == Vector3.zero) return transform.position;

			var forwardVector3 = UnitsMoveData.GetForwardDirectionVector(transform);
			var procent = Time.fixedDeltaTime / 1;
			var speed = UnitsMoveData.GetSpeedMove();
			var newPositionVector3 = transform.position + (forwardVector3 * speed * procent);
			return newPositionVector3;
		}

		/// <summary>
		/// Calculate next rotation quaternion in path
		/// </summary>
		/// <returns>Next rotation quaternion</returns>
		public virtual Quaternion GetNextRotationQuaternion()
		{
			var directionVector3 = CulculateTarget() - transform.position;
			if (directionVector3 == Vector3.zero) return transform.rotation;
			var axisVector3 = UnitsMoveData.GetNormalDirectionVector3();
			var rotationAngle = Mathf.Atan2(directionVector3.y, directionVector3.x);
			rotationAngle = rotationAngle * Mathf.Rad2Deg;
			var rotation = Quaternion.AngleAxis(rotationAngle, axisVector3);

			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * UnitsMoveData.GetSpeedRotation());
			return teleportToRotation;
		}
	}
}
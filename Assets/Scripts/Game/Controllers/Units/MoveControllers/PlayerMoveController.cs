using Game.Controllers.TanksInput;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class PlayerMoveController : BaseMoveController
	{
		public override Vector3 CulculateTarget()
		{
			var directionMoveVector = InputManager.Instance.GetDirectionVector();
			return directionMoveVector + transform.position;
		}

		public override Vector3 GetNextPosirionVector3()
		{
			var directionVector = CulculateTarget() - transform.position;
			if (directionVector == Vector3.zero) return transform.position;

			var forwardVector = UnitsMoveData.GetForwardDirectionVector(transform);
			//var directionForwardBack = Vector2.Dot(forwardVector, directionVector)
			//                           <= Settings.InputSettings.StepInJoystickByBackMoved ? -1 : 1;//нужно для езды задом
			var procent = Time.fixedDeltaTime /*/ 1 * directionForwardBack*/;
			var speed = UnitsMoveData.GetSpeedMove();
			var newPositionVector = transform.position + (forwardVector * speed * procent);
			//return CulculateTarget();
			return newPositionVector;
		}

		
		public override Quaternion GetNextRotationQuaternion()
		{
			var directionVector = CulculateTarget() - transform.position;
			if (directionVector == Vector3.zero) return transform.rotation;

			//var direction = Vector2.Dot(UnitsMoveData.GetForwardDirectionVector(transform), directionVector)
			//                <= Settings.InputSettings.StepInJoystickByBackMoved ? -1 : 1;//нужно для езды задом
			var axisVector3 = UnitsMoveData.GetNormalDirectionVector3();
			var rotationAngle = Mathf.Atan2(directionVector.y, directionVector.x);
			rotationAngle = rotationAngle * Mathf.Rad2Deg;
			var rotation = Quaternion.AngleAxis(rotationAngle/* + (direction == -1 ? 180 : 0)*/, axisVector3);

			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * UnitsMoveData.GetSpeedRotation());
			return teleportToRotation;
		}
	}
}

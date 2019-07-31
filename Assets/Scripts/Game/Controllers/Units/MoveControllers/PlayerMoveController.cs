using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using Game.Controllers.Units.MoveControllers;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public enum TypePlayerController
	{
		FirstPerson,
		ThridPerson,
		TopDown
	}

	public class PlayerMoveController : BaseMoveController
	{
		public TypePlayerController CurrentTypePlayerController = TypePlayerController.ThridPerson;

		public override Vector3 CulculateTarget()
		{
			var directionMoveVector = InputManager.Instance.GetDirectionVector3();
			return ConvertToXPerson(directionMoveVector) + transform.position;
		}

		public override Vector3 GetNextPosirionVector3(Vector3 forwardVector3)
		{
			var directionVector3 = CulculateTarget() - transform.position;
			if (directionVector3 == Vector3.zero) return transform.position;

			var directionForwardBack = Vector3.Dot(forwardVector3, directionVector3)
			                           <= Settings.InputSettings.StepInJoystickByBackMoved ? -1 : 1;//нужно для езды задом
			var procent = Time.fixedDeltaTime / 1 * directionForwardBack;
			var speed = UnitMoveData.GetSpeedMove();
			var newPositionVector3 = transform.position + (forwardVector3 * speed * procent);
			return newPositionVector3;
		}


		public override Quaternion GetNextRotationQuaternion(Vector3 axisVector3)
		{
			var directionVector3 = CulculateTarget() - transform.position;
			if (directionVector3 == Vector3.zero) return transform.rotation;

			var direction = Vector3.Dot(UnitMoveData.GetForwardDirectionVector3(transform), directionVector3)
			                <= Settings.InputSettings.StepInJoystickByBackMoved ? -1 : 1;//нужно для езды задом

			var rotationAngle = Mathf.Atan2(directionVector3.y, directionVector3.x);
			rotationAngle = rotationAngle * Mathf.Rad2Deg;
			var rotation = Quaternion.AngleAxis(rotationAngle + (direction == -1 ? 180 : 0), axisVector3);

			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * UnitMoveData.GetSpeedRotation());
			return teleportToRotation;
		}

		private Vector3 ConvertToXPerson(Vector3 directionMoveVector)
		{
			switch (CurrentTypePlayerController)
			{
				case TypePlayerController.ThridPerson:
					var resultVector = UnitMoveData.GetForwardDirectionVector3(transform) * directionMoveVector.z
					                   + transform.right * directionMoveVector.x;
					return resultVector;
				case TypePlayerController.FirstPerson:
				case TypePlayerController.TopDown:
				default:
					return directionMoveVector;
			}
		}
	}
}

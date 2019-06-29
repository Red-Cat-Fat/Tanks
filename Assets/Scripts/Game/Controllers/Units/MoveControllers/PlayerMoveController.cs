using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
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

		private Vector3 ConvertToXPerson(Vector3 directionMoveVector)
		{
			switch (CurrentTypePlayerController)
			{
				case TypePlayerController.FirstPerson:
					return directionMoveVector;
				case TypePlayerController.ThridPerson:
					var resultVector = transform.forward * directionMoveVector.z
					                   + transform.right * directionMoveVector.x;
					return resultVector;
				case TypePlayerController.TopDown:
					return directionMoveVector;
				default:
					return directionMoveVector;
			}
		}
	}
}

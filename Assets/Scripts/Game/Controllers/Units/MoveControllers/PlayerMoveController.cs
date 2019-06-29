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
	public class PlayerMoveController : MonoBehaviour, IMoveController
	{
		public TypePlayerController CurrentTypePlayerController = TypePlayerController.ThridPerson;
		private Vector3 _moveTargetVector3;

		private void Start()
		{
			_moveTargetVector3 = transform.position;
		}
		
		public Vector3 GetNewTargetPosirionVector3()
		{
			var directionMoveVector = InputManager.Instance.GetDirectionVector3();
			_moveTargetVector3 = ConvertToXPerson(directionMoveVector);
			return _moveTargetVector3;
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

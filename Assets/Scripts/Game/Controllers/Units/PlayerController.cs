using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using UnityEngine;

namespace Game.Controllers.Units
{
	public class PlayerController : MonoBehaviour, IController
	{
		private Vector3 _moveTargetVector3;

		private void Start()
		{
			_moveTargetVector3 = transform.position;
		}
		
		public Vector3 GetNewTargetPosirionVector3()
		{
			var directionMoveVector = InputSystem.Instance.GetDirectionVector3();
			_moveTargetVector3 = transform.position + directionMoveVector;
			return _moveTargetVector3;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using UnityEngine;

namespace Game.Controllers.Units
{
	public class PlayerController : MonoBehaviour
	{
		private Vector3 _moveTargetVector3;
		private float _moveTime = 0f;
		private GameObject _targetVisualisetGameObject;
		private void Start()
		{
			_moveTargetVector3 = transform.position;
		}
		private void Update()
		{
			var directionMoveVector = InputSystem.Instance.GetDirectionVector3();
			if (directionMoveVector != Vector3.zero)
			{
				_moveTargetVector3 = transform.position + directionMoveVector * 0.3f;
			}

			transform.position = _moveTargetVector3;
		}
	}
}

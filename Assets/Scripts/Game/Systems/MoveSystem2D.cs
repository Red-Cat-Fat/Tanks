using Game.Controllers.Units.MoveControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems
{
	public class MoveSystem2D : MoveSystem
	{
		private IMoveController _unitsMoveController;
		private Rigidbody2D _unitsRigidbody2D;

		private void Start()
		{
			_unitsMoveController = GetComponent<IMoveController>();
			if (_unitsMoveController == null)
			{
				Debug.LogError("UnitController on " + gameObject.name + " is null");
			}

			_unitsRigidbody2D = GetComponent<Rigidbody2D>();
			if (_unitsRigidbody2D == null)
			{
				Debug.LogError("Rigidbody2D on " + gameObject.name + " is null");
			}
		}

		private void FixedUpdate()
		{
			_unitsMoveController.CulculateTarget();
			var position = _unitsMoveController.GetNextPosirionVector3();
			var rotation = _unitsMoveController.GetNextRotationQuaternion(Vector3.forward);

			Move(position);
			Rotate(rotation);
		}

		private void Move(Vector3 newPositionVector3)
		{
			_unitsRigidbody2D?.MovePosition(newPositionVector3);
		}

		private void Rotate(Quaternion rotationQuaternion)
		{
			transform.rotation = rotationQuaternion;
		}
	}
}

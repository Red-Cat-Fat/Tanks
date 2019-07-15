using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Units.MoveControllers;
using UnityEngine;

namespace Game.Systems
{
	public class MoveSystem : MonoBehaviour
	{
		private IMoveController _unitsMoveController;
		private Rigidbody _unitsRigidbody;

		private void Start()
		{
			_unitsMoveController = GetComponent<IMoveController>();
			if (_unitsMoveController == null)
			{
				Debug.LogError("UnitController on " + gameObject.name + " is null");
			}

			_unitsRigidbody = GetComponent<Rigidbody>();
			if (_unitsRigidbody == null)
			{
				Debug.LogError("Rigidbody on " + gameObject.name + " is null");
			}
		}

		private void FixedUpdate()
		{
			_unitsMoveController.CulculateTarget();
			var position = _unitsMoveController.GetNextPosirionVector3(transform.forward);
			var rotation = _unitsMoveController.GetNextRotationQuaternion(Vector3.up);

			Move(position);
			Rotate(rotation);
		}
		
		private void Move(Vector3 newPositionVector3)
		{
			_unitsRigidbody?.MovePosition(newPositionVector3);
		}

		private void Rotate(Quaternion rotationQuaternion)
		{
			_unitsRigidbody.rotation = rotationQuaternion;
		}
	}
}

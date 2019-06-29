using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Units.MoveControllers;
using UnityEngine;

namespace Game.Systems
{
	public class MoveSystem : MonoBehaviour
	{
		public float SpeedMove = 3f;
		public float SpeedRotate = 3f;

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
			Move(Time.deltaTime);
		}

		private void Move(float deltaTime)
		{
			var directionVector3 = _unitsMoveController.GetNewTargetPosirionVector3();
			if(directionVector3 == Vector3.zero) return;

			var direction = Vector3.Dot(transform.forward, directionVector3) <= 0 ? -1 : 1;//нужно для езды задом
			var rotation = Quaternion.LookRotation(directionVector3 * direction);
			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * SpeedRotate);
			Rotate(teleportToRotation);

			var procent = deltaTime / 1 * direction;
			var newPositionVector3 = transform.position + transform.forward * directionVector3.magnitude * SpeedMove * procent;
			
			Move(newPositionVector3);
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

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

			var procent = deltaTime / 1;
			var newPositionVector3 = transform.position + directionVector3 * SpeedMove * procent;
			
			var rotation = Vector3.Dot(transform.forward, directionVector3) <= 0
				? Quaternion.LookRotation(-directionVector3)
				: Quaternion.LookRotation(directionVector3);
			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * SpeedRotate);

			Move(newPositionVector3, teleportToRotation);
		}

		private void Move(Vector3 newPositionVector3, Quaternion rotationQuaternion)
		{
			_unitsRigidbody.rotation = rotationQuaternion;
			_unitsRigidbody?.MovePosition(newPositionVector3);
		}
	}
}

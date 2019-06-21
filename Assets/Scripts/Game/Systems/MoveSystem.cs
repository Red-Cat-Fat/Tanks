using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using Game.Controllers.Units;
using UnityEngine;

namespace Game.Systems
{
	public class MoveSystem : MonoBehaviour
	{
		[SerializeField] private float _speedMove = 3f;
		[SerializeField] private float _speedRotate = 3f;
		private IController _unitsController;
		private Rigidbody _unitsRigidbody;

		private void Start()
		{
			_unitsController = GetComponent<IController>();
			if (_unitsController == null)
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
			var newPositionVector3 = _unitsController.GetNewTargetPosirionVector3();
			if (newPositionVector3 == transform.position) return;

			var directionVector3 = newPositionVector3 - transform.position;
			var distanceToTargetPoint = directionVector3.magnitude;
			var timeMoveToPoint = distanceToTargetPoint / _speedMove;
			var procent = deltaTime / timeMoveToPoint;
			var teleportToPosition = Vector3.Lerp(transform.position, newPositionVector3, procent);

			var rotation = Vector3.Dot(transform.forward, directionVector3) <= 0
				? Quaternion.LookRotation(-directionVector3)
				: Quaternion.LookRotation(directionVector3);
			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _speedRotate);

			Move(teleportToPosition, teleportToRotation);
		}

		private void Move(Vector3 newPositionVector3, Quaternion rotationQuaternion)
		{
			_unitsRigidbody.rotation = rotationQuaternion;
			_unitsRigidbody?.MovePosition(newPositionVector3);
		}
	}
}

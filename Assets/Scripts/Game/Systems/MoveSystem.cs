using System.Collections;
using System.Collections.Generic;
using Editor.LogSystem;
using Game.Controllers.Units.MoveControllers;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	public class MoveSystem : MonoBehaviour
	{
		protected IMoveController UnitsMoveController;
		private Rigidbody _unitsRigidbody;
		protected MoveData UnitsMoveData;

		protected void InitialBaseMoveSystemField()
		{
			UnitsMoveController = GetComponent<IMoveController>();
			UnitsMoveData = GetComponent<MoveData>();
			Log.CheckForNull(UnitsMoveController, gameObject, typeof(IMoveController));
			Log.CheckForNull(UnitsMoveData, gameObject, typeof(MoveData));
		}

		private void Start()
		{
			InitialBaseMoveSystemField();
			_unitsRigidbody = GetComponent<Rigidbody>();
			Log.CheckForNull(_unitsRigidbody, gameObject, typeof(Rigidbody));
		}

		private void FixedUpdate()
		{
			UpdateTransform();
		}

		protected virtual void UpdateTransform()
		{
			UnitsMoveController.CulculateTarget();

			var forwardVector3 = UnitsMoveData.GetForwardDirectionVector3(transform);
			var position = UnitsMoveController.GetNextPosirionVector3(forwardVector3);

			var normalDirectionVector3 = UnitsMoveData.GetNormalDirectionVector3();
			var rotation = UnitsMoveController.GetNextRotationQuaternion(normalDirectionVector3);

			Move(position);
			Rotate(rotation);
		}

		protected virtual void Move(Vector3 newPositionVector3)
		{
			_unitsRigidbody?.MovePosition(newPositionVector3);
		}

		protected virtual void Rotate(Quaternion rotationQuaternion)
		{
			transform.rotation = rotationQuaternion;
		}
	}
}

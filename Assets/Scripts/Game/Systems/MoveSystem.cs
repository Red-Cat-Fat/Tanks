using Game.Controllers.Units.MoveControllers;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	[RequireComponent(typeof(Rigidbody2D), typeof(MoveData))]
	public class MoveSystem : MonoBehaviour
	{
		protected IMoveController UnitsMoveController;
		[SerializeField, HideInInspector]
		private Rigidbody2D _unitsRigidbody2D;
		[SerializeField, HideInInspector]
		protected MoveData UnitsMoveData;
		
		private void OnValidate()
		{
			UnitsMoveData = GetComponent<MoveData>();
			_unitsRigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void Awake()
		{
			UnitsMoveController = GetComponent<IMoveController>();
		}

		private void FixedUpdate()
		{
			UpdateTransform();
		}

		protected virtual void UpdateTransform()
		{
			UnitsMoveController.CulculateTarget();

			if (UnitsMoveData.GetIsCanMove())
			{
				var position = UnitsMoveController.GetNextPosirionVector3();

				Move(position);
			}

			if (UnitsMoveData.GetIsCanRotate())
			{
				var rotation = UnitsMoveController.GetNextRotationQuaternion();

				Rotate(rotation);
			}
		}

		protected virtual void Move(Vector3 newPositionVector3)
		{
			_unitsRigidbody2D?.MovePosition(newPositionVector3);
		}

		protected virtual void Rotate(Quaternion rotationQuaternion)
		{
			transform.rotation = rotationQuaternion;
		}
	}
}


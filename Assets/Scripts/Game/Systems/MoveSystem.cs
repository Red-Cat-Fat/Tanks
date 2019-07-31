using Game.Controllers.Units.MoveControllers;
using Game.Data.Units;
using UnityEngine;
using Logger = Editor.Utility.Logger.Logger;

namespace Game.Systems
{
	public class MoveSystem : MonoBehaviour
	{
		protected IMoveController UnitsMoveController;
		private Rigidbody2D _unitsRigidbody2D;
		protected MoveData UnitsMoveData;

		protected void InitialBaseMoveSystemField()
		{
			UnitsMoveController = GetComponent<IMoveController>();
			UnitsMoveData = GetComponent<MoveData>();
			Logger.CheckForNull(UnitsMoveController, gameObject, typeof(IMoveController));
			Logger.CheckForNull(UnitsMoveData, gameObject, typeof(MoveData));
		}

		private void Start()
		{
			InitialBaseMoveSystemField();

			_unitsRigidbody2D = GetComponent<Rigidbody2D>();
			Logger.CheckForNull(_unitsRigidbody2D, gameObject, typeof(Rigidbody2D));
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
				var forwardVector3 = UnitsMoveData.GetForwardDirectionVector3(transform);
				var position = UnitsMoveController.GetNextPosirionVector3(forwardVector3);

				Move(position);
			}

			if (UnitsMoveData.GetIsCanRotate())
			{
				var normalDirectionVector3 = UnitsMoveData.GetNormalDirectionVector3();
				var rotation = UnitsMoveController.GetNextRotationQuaternion(normalDirectionVector3);

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


using Game.Controllers.Units.MoveControllers;
using System.Collections;
using System.Collections.Generic;
using Editor.LogSystem;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	public class MoveSystem2D : MoveSystem
	{
		private Rigidbody2D _unitsRigidbody2D;

		private void Start()
		{
			InitialBaseMoveSystemField();

			_unitsRigidbody2D = GetComponent<Rigidbody2D>();
			Log.CheckForNull(_unitsRigidbody2D, gameObject, typeof(Rigidbody2D));
		}
		
		protected override void Move(Vector3 newPositionVector3)
		{
			_unitsRigidbody2D?.MovePosition(newPositionVector3);
		}
	}
}

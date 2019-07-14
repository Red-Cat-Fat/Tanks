using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public class PlayerMoveController2D : PlayerMoveController, IMoveController2D
	{
		public Vector2 GetNextPosirionVector2()
		{
			var resVect = GetNextPosirionVector3();

			return new Vector2(resVect.x, resVect.z);
		}

		public float GetNextRotationFloat()
		{
			return Vector3.Angle(Vector3.up, GetNextPosirionVector3());
		}
	}
}

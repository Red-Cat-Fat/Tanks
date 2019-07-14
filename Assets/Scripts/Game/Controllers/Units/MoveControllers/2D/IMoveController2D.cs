using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public interface IMoveController2D : IMoveController
	{
		Vector2 GetNextPosirionVector2();
		float GetNextRotationFloat();
	}
}

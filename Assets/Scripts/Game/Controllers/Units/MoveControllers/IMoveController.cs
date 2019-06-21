using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.MoveControllers.Units
{
	public interface IMoveController
	{
		Vector3 GetNewTargetPosirionVector3();
	}
}

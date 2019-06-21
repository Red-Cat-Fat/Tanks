using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public interface IMoveController
	{
		Vector3 GetNewTargetPosirionVector3();
	}
}

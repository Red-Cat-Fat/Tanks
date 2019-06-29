using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public interface IMoveController
	{
		Vector3 CulculateTarget();
		Vector3 GetNextPosirionVector3();
		Quaternion GetNextRotationQuaternion();
	}
}

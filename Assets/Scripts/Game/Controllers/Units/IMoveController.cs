using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using UnityEngine;

namespace Game.Controllers.Units
{
	public interface IMoveController
	{
		Vector3 GetNewTargetPosirionVector3();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.MoveControllers.Units
{
	public class MetalBulletMoveController : MonoBehaviour, IMoveController
	{
		public Vector3 GetNewTargetPosirionVector3()
		{
			return transform.forward;
		}
	}
}
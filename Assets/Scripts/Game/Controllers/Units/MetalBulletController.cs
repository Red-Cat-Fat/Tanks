using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units
{
	public class MetalBulletController : MonoBehaviour, IController
	{
		public Vector3 GetNewTargetPosirionVector3()
		{
			return transform.forward;
		}
	}
}
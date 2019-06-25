using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.GunControllers
{
	public class BaseGunController : MonoBehaviour, IGunController
	{
		public bool IsFire()
		{
			return true;
		}
	}
}

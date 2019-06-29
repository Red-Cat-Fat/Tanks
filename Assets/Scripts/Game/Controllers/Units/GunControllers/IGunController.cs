using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.GunControllers
{
	public interface IGunController
	{
		bool IsCanFire();
		void Fire();
	}
}
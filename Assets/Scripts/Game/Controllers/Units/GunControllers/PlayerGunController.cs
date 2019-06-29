using Game.Controllers.TanksInput;
using Game.Data.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.GunControllers
{
	public class PlayerGunController : PhysicalGunController, IGunController
	{
		public override bool IsCanFire()
		{
			return InputManager.Instance.IsClicked() && base.IsCanFire();
		}
	}
}

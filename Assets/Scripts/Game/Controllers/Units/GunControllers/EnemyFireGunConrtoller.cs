using UnityEngine;

namespace Game.Controllers.Units.GunControllers
{
	public class EnemyFireGunConrtoller : PhysicalGunController
	{
		public override bool IsCanFire()
		{
			var gunPoint = GunData.GetGunPoint();
			if (base.IsCanFire() 
				&& Physics.Raycast(gunPoint.transform.position, gunPoint.transform.forward, out var hit, 1000, 1))
			{
				return true;
			}
			return false;
		}
	}
}

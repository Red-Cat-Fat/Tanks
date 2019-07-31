using Game.Controllers.TanksInput;

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

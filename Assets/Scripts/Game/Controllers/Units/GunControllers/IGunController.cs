using Assets.Scripts.Game.Controllers.Units;

namespace Game.Controllers.Units.GunControllers
{
	public interface IGunController : IUnitsController
	{
		bool IsCanFire();
		void Fire();
	}
}
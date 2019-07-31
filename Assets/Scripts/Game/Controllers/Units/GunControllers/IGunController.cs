namespace Game.Controllers.Units.GunControllers
{
	public interface IGunController
	{
		bool IsCanFire();
		void Fire();
	}
}
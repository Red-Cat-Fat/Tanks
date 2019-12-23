using Assets.Scripts.Game.Controllers.Units;

namespace Game.Controllers.Units.TeamControllers
{
	public interface ITeamController : IUnitsController
	{
		void InitialAction();
	}
}

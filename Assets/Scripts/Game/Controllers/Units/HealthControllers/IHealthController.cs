using System;

namespace Game.Controllers.Units.HealthControllers
{
	public interface IHealthController : IUnitsController
	{
		void AddDeadEvent(ref Action actionEvent);
		void SetDamage(float inputDamage);
		bool IsDead();
	}
}
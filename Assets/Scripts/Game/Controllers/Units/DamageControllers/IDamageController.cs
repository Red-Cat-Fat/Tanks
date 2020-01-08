using System;
using UnityEngine;

namespace Game.Controllers.Units.DamageControllers
{
	public interface IDamageController : IUnitsController
	{
		void SetDamageEvent(Action<GameObject, float> actionEvent);
		void SetDamage(GameObject targetGameObject);
	}
}

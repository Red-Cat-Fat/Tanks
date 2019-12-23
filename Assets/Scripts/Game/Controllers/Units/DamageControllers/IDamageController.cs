using System;
using Assets.Scripts.Game.Controllers.Units;
using UnityEngine;

namespace Game.Controllers.Units.DamageControllers
{
	public interface IDamageController : IUnitsController
	{
		void SetDamageEvent(Action<GameObject, float> actionEvent);
		void SetDamage(GameObject targetGameObject);
	}
}

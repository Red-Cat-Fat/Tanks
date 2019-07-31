using System;
using UnityEngine;

namespace Game.Controllers.Units.DamageControllers
{
	public interface IDamageController
	{
		void SetDamageEvent(Action<GameObject, float> actionEvent);
		void SetDamage(GameObject targetGameObject);
	}
}

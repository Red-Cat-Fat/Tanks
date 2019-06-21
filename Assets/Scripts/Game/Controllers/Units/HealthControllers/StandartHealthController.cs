using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.HealthControllers
{
	public class StandartHealthController : MonoBehaviour, IHealthController
	{
		public GameObject DestroyedGameObject;
		public void AddDeadEvent(ref Action actionEvent)
		{
			actionEvent += () => { Instantiate(DestroyedGameObject, transform.position, transform.rotation); };
			//no nothing
		}

		public float GetCurrentDamage(float inputDamage)
		{
			return inputDamage;
		}
	}
}

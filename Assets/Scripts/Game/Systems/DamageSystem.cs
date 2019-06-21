using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Units.DamageControllers;
using UnityEngine;

namespace Game.Systems
{
	public class DamageSystem : MonoBehaviour
	{
		public float DamageValue = 100;
		private void Start()
		{
			var damageController = GetComponent<IDamageController>();
			if (damageController == null)
			{
				Debug.LogError("damageController in " + gameObject.name + " is null");
			}
			else
			{
				damageController.SetDamageEvent(OnSetDamage);
			}
		}
		
		public void OnSetDamage(GameObject targetGameObject)
		{
			var healthSystemWarior = targetGameObject.GetComponent<HealthSystem>();
			healthSystemWarior?.SetDamage(DamageValue);
		}
	}
}
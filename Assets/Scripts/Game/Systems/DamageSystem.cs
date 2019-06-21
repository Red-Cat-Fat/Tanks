using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems
{
	public class DamageSystem : MonoBehaviour
	{
		public float DamageValue = 100;

		public void SetDamage(GameObject gameObject)
		{
			var healthSystemWarior = gameObject.GetComponent<HealthSystem>();
			healthSystemWarior.SetDamage(DamageValue);
		}
	}
}
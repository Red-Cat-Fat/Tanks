using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems
{
	public class HealthSystem : MonoBehaviour
	{
		public float HealthPoint = 100f;
		public Action DeadEvent;

		private void Start()
		{
			DeadEvent += OnDead;
		}

		public void SetDamage(float value)
		{
			HealthPoint -= value;
			if (HealthPoint <= 0)
			{
				DeadEvent?.Invoke();
			}
		}

		private void OnDead()
		{
			Destroy(gameObject);
		}
	}
}
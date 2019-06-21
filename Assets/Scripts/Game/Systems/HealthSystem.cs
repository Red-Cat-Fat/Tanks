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
		public void SetDamage(float value)
		{
			HealthPoint -= value;
			if (HealthPoint < 0)
			{
				DeadEvent?.Invoke();
			}
		}
	}
}
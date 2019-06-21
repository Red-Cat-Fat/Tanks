using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Units.HealthControllers;
using UnityEngine;

namespace Game.Systems
{
	public class HealthSystem : MonoBehaviour
	{
		public float HealthPoint = 100f;
		private IHealthController _currentHealthController;
		private Action DeadEvent;
		private void Start()
		{
			_currentHealthController = GetComponent<IHealthController>();
			if (_currentHealthController == null)
			{
				Debug.LogError("IHealthController in "+ gameObject.name + "is null");
			}
			else
			{
				DeadEvent += OnDead;
				_currentHealthController.AddDeadEvent(ref DeadEvent);
			}
		}

		public void SetDamage(float inputDamage)
		{
			HealthPoint-=_currentHealthController.GetCurrentDamage(inputDamage);
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
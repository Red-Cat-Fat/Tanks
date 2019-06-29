using System;
using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Units.HealthControllers;
using UnityEngine;

namespace Game.Systems
{
	public class HealthSystem : MonoBehaviour
	{
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
			_currentHealthController.SetDamage(inputDamage);
			if (_currentHealthController.IsDead())
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
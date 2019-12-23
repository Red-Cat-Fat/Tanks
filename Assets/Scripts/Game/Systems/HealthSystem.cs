using System;
using Game.Controllers.Units.HealthControllers;
using UnityEngine;

namespace Game.Systems
{
	public class HealthSystem : MonoBehaviour, ISystem
	{
		private IHealthController _currentHealthController;
		private Action _deadEvent;
		private void Start()
		{
			_currentHealthController = GetComponent<IHealthController>();
			if (_currentHealthController == null)
			{
				Debug.LogError("IHealthController in "+ gameObject.name + "is null");
			}
			else
			{
				_deadEvent += OnDead;
				_currentHealthController.AddDeadEvent(ref _deadEvent);
			}
		}

		public void SetDamage(float inputDamage)
		{
			_currentHealthController.SetDamage(inputDamage);
			if (_currentHealthController.IsDead())
			{
				_deadEvent?.Invoke();
			}
		}

		private void OnDead()
		{
			Destroy(gameObject);
		}

		public void AddDeadEvent(Action newDeadEvent)
		{
			_deadEvent += newDeadEvent;
		}
	}
}
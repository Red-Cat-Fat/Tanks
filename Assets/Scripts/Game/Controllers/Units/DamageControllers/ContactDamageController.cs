using System;
using System.Collections;
using System.Collections.Generic;
using Game.Systems;
using UnityEngine;

namespace Game.Controllers.Units.DamageControllers
{
	public class ContactDamageController : MonoBehaviour, IDamageController
	{
		private Action<GameObject> _setDamageEvent;

		public void SetDamageEvent(Action<GameObject> actionEvent)
		{
			_setDamageEvent += actionEvent;
		}

		public void SetDamage(GameObject targetGameObject)
		{
			_setDamageEvent?.Invoke(targetGameObject);
		}

		private void OnCollisionEnter(Collision collision)
		{
			var targetGameObject = collision.gameObject;
			if (targetGameObject == null) { return; }

			var healthSystem = targetGameObject.GetComponent<HealthSystem>();
			if(healthSystem == null) { return; }

			SetDamage(targetGameObject);
		}
	}
}

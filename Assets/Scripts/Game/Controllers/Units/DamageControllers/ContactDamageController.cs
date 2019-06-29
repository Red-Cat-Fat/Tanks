using System;
using System.Collections;
using System.Collections.Generic;
using Game.Data.Units;
using Game.Systems;
using UnityEngine;

namespace Game.Controllers.Units.DamageControllers
{
	public class ContactDamageController : MonoBehaviour, IDamageController
	{
		private DamageData _damageData;
		private Action<GameObject, float> _setDamageEvent;
		private void Start()
		{
			_damageData = GetComponent<DamageData>();
			if (_damageData == null)
			{
				Debug.LogError("DamageData in " + gameObject.name + "is null");
			}
		}
		
		private void OnCollisionEnter(Collision collision)
		{
			var targetGameObject = collision.gameObject;
			if (targetGameObject == null) { return; }

			var healthSystem = targetGameObject.GetComponent<HealthSystem>();
			if(healthSystem == null)
			{
				Destroy(gameObject);
			}

			SetDamage(targetGameObject);
		}

		public void SetDamageEvent(Action<GameObject, float> actionEvent)
		{
			_setDamageEvent += actionEvent;
		}

		public void SetDamage(GameObject targetGameObject)
		{
			_setDamageEvent?.Invoke(targetGameObject, _damageData.GetDamage());
			Destroy(gameObject);
		}
	}
}

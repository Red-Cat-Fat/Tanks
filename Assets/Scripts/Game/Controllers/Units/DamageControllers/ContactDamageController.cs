using System;
using Editor.Utility.LogSystem;
using Game.Data.Units;
using Game.Systems;
using UnityEngine;

namespace Game.Controllers.Units.DamageControllers
{
	[RequireComponent(typeof(DamageData))]
	public class ContactDamageController : MonoBehaviour, IDamageController
	{
		[SerializeField, HideInInspector]
		private DamageData _damageData;
		private Action<GameObject, float> _setDamageEvent;
		private void OnValidate()
		{
			_damageData = GetComponent<DamageData>();
		}

		private void OnCollisionEnter(Collision collision)
		{
			var targetGameObject = collision.gameObject;
			if (targetGameObject != null)
			{
				OnCollisionOnGameObject(targetGameObject);
			}
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			var targetGameObject = collision.gameObject;
			if (targetGameObject != null)
			{
				OnCollisionOnGameObject(targetGameObject);
			}
		}

		private void OnCollisionOnGameObject(GameObject targetGameObject)
		{
			var healthSystem = targetGameObject.GetComponent<HealthSystem>();
			if (healthSystem == null)
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

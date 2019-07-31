using System;
using Game.Data.Units;
using Game.Systems;
using UnityEngine;
using Logger = Editor.Utility.Logger.Logger;

namespace Game.Controllers.Units.DamageControllers
{
	public class ContactDamageController : MonoBehaviour, IDamageController
	{
		private DamageData _damageData;
		private Action<GameObject, float> _setDamageEvent;
		private void Start()
		{
			_damageData = GetComponent<DamageData>();
			Logger.CheckForNull(_damageData, gameObject, typeof(DamageData));
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

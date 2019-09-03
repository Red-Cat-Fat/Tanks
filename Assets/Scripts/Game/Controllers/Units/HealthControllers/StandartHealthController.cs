using Game.Data.Units;
using System;
using Editor.Utility.LogSystem;
using UnityEngine;

namespace Game.Controllers.Units.HealthControllers
{
	[RequireComponent(typeof(HealthData))]
	public class StandartHealthController : MonoBehaviour, IHealthController
	{
		[SerializeField, HideInInspector] private HealthData _healthData;

		private void OnValidate()
		{
			_healthData = GetComponent<HealthData>();
		}

		public void AddDeadEvent(ref Action actionEvent)
		{
			actionEvent += () =>
			{
				var destroyedGameObject = _healthData.GetDestroyedGameObject();
				if (destroyedGameObject != null)
				{
					Instantiate(destroyedGameObject, transform.position, transform.rotation);
				}
			};
		}

		public bool IsDead()
		{
			return _healthData.IsDead();
		}

		public void SetDamage(float inputDamage)
		{
			_healthData.SetDamage(inputDamage);
		}
	}
}

using Game.Data.Units;
using System;
using Editor.Utility.LogSystem;
using UnityEngine;

namespace Game.Controllers.Units.HealthControllers
{
	public class StandartHealthController : MonoBehaviour, IHealthController
	{
		private HealthData _healthData;
		private void Start()
		{
			_healthData = GetComponent<HealthData>();
			Log.CheckForNull(_healthData, gameObject, typeof(HealthData));
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

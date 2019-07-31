using Game.Data.Units;
using System;
using UnityEngine;
using Logger = Editor.Utility.Logger.Logger;

namespace Game.Controllers.Units.HealthControllers
{
	public class StandartHealthController : MonoBehaviour, IHealthController
	{
		private HealthData _healthData;
		private void Start()
		{
			_healthData = GetComponent<HealthData>();
			Logger.CheckForNull(_healthData, gameObject, typeof(HealthData));
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

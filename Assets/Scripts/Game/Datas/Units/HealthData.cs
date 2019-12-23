using UnityEngine;

namespace Game.Data.Units
{
	public class HealthData : MonoBehaviour, IUnitsData
	{
		[SerializeField] private float _healthPoint = 100f;
		[SerializeField] private GameObject _destroyedGameObject;

		public void SetHealth(float value)
		{
			_healthPoint = value;
		}

		public void SetDamage(float value)
		{
			_healthPoint -= value;
		}

		public bool IsDead()
		{
			return _healthPoint <= 0;
		}

		public GameObject GetDestroyedGameObject()
		{
			return _destroyedGameObject;
		}
	}
}
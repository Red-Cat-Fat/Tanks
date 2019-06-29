using UnityEngine;

namespace Game.Data.Units
{
	public class GunData : MonoBehaviour
	{
		private float _cooldownTime = 0f;
		[SerializeField] private float _reloadTime = 1f;
		[SerializeField] private GameObject _bullet;
		[SerializeField] private GameObject _gunPoint;

		public void Reload(float time)
		{
			_cooldownTime -= time;
		}

		public void Fire()
		{
			_cooldownTime = _reloadTime;
		}

		public GameObject GetBullet()
		{
			return _bullet;
		}

		public GameObject GetGunPoint()
		{
			return _gunPoint;
		}

		public bool IsCanFire()
		{
			return _cooldownTime < 0;
		}
	}
}
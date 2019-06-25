using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Units.GunControllers;
using UnityEngine;

namespace Game.Systems
{
	public class GunSystem : MonoBehaviour
	{
		[SerializeField] private float _reloadTime = 1f;
		[SerializeField] private GameObject _bullet;
		[SerializeField] private GameObject _gunPoint;
		private float _cooldownTime = 0f;
		private IGunController _gunController;

		private void Start()
		{
			_gunController = GetComponent<IGunController>();
			if (_gunController == null)
			{
				Debug.LogError("GunController on " + gameObject.name + " is null");
			}
		}

		private void Update()
		{
			_cooldownTime -= Time.deltaTime;
			if (IsCanFire())
			{
				Fire();
			}
		}

		public void Fire()
		{
			Instantiate(_bullet, _gunPoint.transform.position, _gunPoint.transform.rotation);
			_cooldownTime = _reloadTime;
		}

		public bool IsCanFire()
		{
			return _gunController.IsFire() && _cooldownTime < 0;
		}
	}
}

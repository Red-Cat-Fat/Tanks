using System.Collections;
using System.Collections.Generic;
using Game.Controllers.Units.GunControllers;
using UnityEngine;

namespace Game.Systems
{
	public class GunSystem : MonoBehaviour
	{
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
			if (_gunController.IsCanFire())
			{
				_gunController.Fire();
			}
		}
	}
}

using Game.Data.Units;
using UnityEngine;

namespace Game.Controllers.Units.GunControllers
{
	[RequireComponent(typeof(GunData))]
	public abstract class PhysicalGunController : MonoBehaviour, IGunController
	{
		[SerializeField, HideInInspector]
		protected GunData GunData;
		//TODO: распространить на все контроллеры
		protected virtual void OnValidate()
		{
			GunData = GetComponent<GunData>();
		}

		private void Update()
		{
			GunData.Reload(Time.deltaTime);
		}

		public virtual bool IsCanFire()
		{
			return GunData.IsCanFire();
		}

		public virtual void Fire()
		{
			var bullet = GunData.GetBullet();
			var gunPoint = GunData.GetGunPoint();
			Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
			GunData.Fire();
		}
	}
}

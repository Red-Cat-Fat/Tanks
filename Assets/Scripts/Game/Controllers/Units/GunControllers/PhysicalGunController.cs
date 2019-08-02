using Editor.Utility.LogSystem;
using Game.Data.Units;
using UnityEngine;

namespace Game.Controllers.Units.GunControllers
{
	public abstract class PhysicalGunController : MonoBehaviour, IGunController
	{
		protected GunData GunData;

		private void Start()
		{
			GunData = GetComponent<GunData>();
			Log.CheckForNull(GunData, gameObject, typeof(GunData));
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

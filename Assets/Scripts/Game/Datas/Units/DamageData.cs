using UnityEngine;

namespace Game.Data.Units
{
	public class DamageData : MonoBehaviour
	{
		[SerializeField] private float _damageValue = 100f;

		public float GetDamage()
		{
			return _damageValue;
		}
	}
}

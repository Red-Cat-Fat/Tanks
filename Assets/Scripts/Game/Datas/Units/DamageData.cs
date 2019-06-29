using System.Collections;
using System.Collections.Generic;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Units
{
	public class MoveData : MonoBehaviour
	{
		[SerializeField] private float _speedMove = 3f;
		[SerializeField] private float _speedRotation = 3f;

		public float GetSpeedMove()
		{
			return _speedMove;
		}

		public float GetSpeedRotation()
		{
			return _speedRotation;
		}
	}
}
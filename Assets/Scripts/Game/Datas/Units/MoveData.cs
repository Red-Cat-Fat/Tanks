using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Units
{
	public enum VectorDirectionType
	{
		Forward,
		Right,
		Up
	}

	public class MoveData : MonoBehaviour
	{
		[SerializeField] private float _speedMove = 3f;
		[SerializeField] private float _speedRotation = 3f;
		[SerializeField] private VectorDirectionType _vectorForwardDirectionType = VectorDirectionType.Forward;
		[SerializeField] private VectorDirectionType _vectorNormalDirectionType = VectorDirectionType.Up;
		public float GetSpeedMove()
		{
			return _speedMove;
		}

		public float GetSpeedRotation()
		{
			return _speedRotation;
		}

		public Vector3 GetForwardDirectionVector3()
		{
			switch (_vectorForwardDirectionType)
			{
				case VectorDirectionType.Forward:
					return Vector3.forward;
				case VectorDirectionType.Right:
					return Vector3.right;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public Vector3 GetForwardDirectionVector3(Transform transform)
		{
			switch (_vectorForwardDirectionType)
			{
				case VectorDirectionType.Forward:
					return transform.forward;
				case VectorDirectionType.Right:
					return transform.right;
				case VectorDirectionType.Up:
					return transform.up;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public Vector3 GetNormalDirectionVector3()
		{
			switch (_vectorNormalDirectionType)
			{
				case VectorDirectionType.Forward:
					return Vector3.forward;
				case VectorDirectionType.Right:
					return Vector3.right;
				case VectorDirectionType.Up:
					return Vector3.up;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

	}
}
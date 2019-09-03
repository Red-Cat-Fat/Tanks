using System;
using Game.Utillity.DigitalSignalPeocessing.Filters;
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
		[SerializeField] private bool _isCanMove = true;
		[SerializeField] private bool _isCanRotate = true;
		[SerializeField] private float _speedMove = 3f;
		[SerializeField] private float _speedRotation = 3f;
		[SerializeField] private VectorDirectionType _vectorForwardDirectionType = VectorDirectionType.Forward;
		[SerializeField] private VectorDirectionType _vectorNormalDirectionType = VectorDirectionType.Up;
		[SerializeField] private bool _isMove = false;

		private Vector3 _lastPositionVector3;
		private const int CountThueCheckerTrigger = 3;
		private BoolMovingAvargeWindow _boolRotateMovingAvargeWindow = new BoolMovingAvargeWindow(CountThueCheckerTrigger);

		private void Start()
		{
			_lastPositionVector3 = transform.position;
		}

		private void LateUpdate()
		{
			var moveMagnitude = Vector3.Magnitude(_lastPositionVector3 - transform.position);
			_boolRotateMovingAvargeWindow.AddValue(moveMagnitude > 0.01f);
			SetIsMove(_boolRotateMovingAvargeWindow.GetValue());
			_lastPositionVector3 = transform.position;
		}
		public void SetIsMove(bool value)
		{
			if (_isCanMove)
			{
				_isMove = value;
			}
		}

		public bool GetIsMove()
		{
			return _isCanMove && _isMove;
		}

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

		public bool GetIsCanMove()
		{
			return _isCanMove;
		}

		public bool GetIsCanRotate()
		{
			return _isCanRotate;
		}
	}
}
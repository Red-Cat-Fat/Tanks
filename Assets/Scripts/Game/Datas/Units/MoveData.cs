using System;
using Game.Utillity.DigitalSignalPeocessing.Filters;
using UnityEngine;

namespace Game.Data.Units
{
	public class MoveData : MonoBehaviour
	{
		[SerializeField] private bool _isCanMove = true;
		[SerializeField] private bool _isCanRotate = true;
		[SerializeField] private float _speedMove = 3f;
		[SerializeField] private float _speedRotation = 3f;
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

		public Vector3 GetForwardDirectionVector(Transform inputTransform)
		{
			return inputTransform.up;
		}

		public Vector3 GetNormalDirectionVector()
		{
			return Vector3.back;
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
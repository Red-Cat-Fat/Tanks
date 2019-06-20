using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class SwipeInputType : IInputType
	{
		private Vector3 _directionVector3 = Vector3.zero;
		private bool _isTouched = false;
		private Vector2 _startTouchVector2;
		private Vector2 _lastTouchVector2;

		public void CheckInput()
		{
			if (Input.touches.Length > 0)
			{
				if (!_isTouched)
				{
					_startTouchVector2 = Input.GetTouch(0).position;
					_isTouched = true;
				}
				_lastTouchVector2 = Input.GetTouch(0).position;
				Debug.Log("_isTouched = " + _isTouched);
			}
			else
			{
				if (_isTouched)
				{
					var swipe = _lastTouchVector2 - _startTouchVector2;
					_directionVector3 = new Vector3(swipe.x, 0, swipe.y);
					_isTouched = false;
				}
			}

		}

		public Vector3 GetDirectionVector3()
		{
			var retValue = _directionVector3;
			_directionVector3 = Vector3.zero; 
			return retValue;
		}
	}
}
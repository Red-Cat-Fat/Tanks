using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class SwipeMouseInputType : MonoBehaviour, IInputType
	{
		private Vector3 _directionVector3 = Vector3.zero;
		private bool _isTouched = false;
		private Vector2 _startTouchVector2;
		private Vector2 _lastTouchVector2;

		public void CheckInput()
		{
			if (Input.GetMouseButton(0))
			{
				if (!_isTouched)
				{
					_startTouchVector2 = Input.mousePosition;
					_isTouched = true;
				}

				_lastTouchVector2 = Input.mousePosition;
			}
			else
			{
				if (!_isTouched) return;
				var swipe = _lastTouchVector2 - _startTouchVector2;
				_directionVector3 = new Vector3(swipe.x, 0, swipe.y);
				_isTouched = false;
			}
		}

		public Vector3 GetDirectionVector3()
		{
			var retValue = _directionVector3.normalized;
			_directionVector3 = Vector3.zero; 
			return retValue;
		}
	}
}

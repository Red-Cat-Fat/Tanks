using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using UnityEngine;

namespace MyNamespace
{
	public class VirtualJoystickInputType : MonoBehaviour, IInputType
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

				var swipe = _lastTouchVector2 - _startTouchVector2;
				_directionVector3 = new Vector3(swipe.x, 0, swipe.y);
			}
			else
			{
				_directionVector3 = Vector3.zero;
				_isTouched = false;
			}
		}

		public Vector3 GetDirectionVector3()
		{
			var retValue = _directionVector3.normalized;
			return retValue;
		}
	}
}

using Game.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class SwipeMouseInputType : VirtualJoystickInputType
	{
		public override void CheckInput()
		{
			if (Input.GetMouseButton(0))
			{
				CalculateInput(Input.mousePosition);
			}
			else
			{
				IsTouched = false;
				CheckClicked();
			}
		}
	}
}

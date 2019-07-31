using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class SwipeInputType : VirtualJoystickInputType
	{
		public override void CheckInput()
		{
			if (Input.touches.Length > 0)
			{
				CalculateInput(Input.GetTouch(0).position);
			}
			else
			{
				IsTouched = false;
			}
			CheckClicked();
		}
	}
}
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class SwipeMouseInputType : VirtualJoystickInputType
	{
		public override void CheckInput()
		{
			if (Input.GetMouseButton(0))
			{
				CalculateSwipeInput(Input.mousePosition);
			}
			else
			{
				IsTouched = false;
			}
			CheckClicked();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using Game.Settings;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class VirtualJoystickInputType : BaseInputType
	{
		protected bool IsTouched = false;
		protected Vector2 StartTouchVector2;
		protected Vector2 LastTouchVector2;
		protected bool IsMoved = false;
		
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
				LastInputVector2 = Vector2.zero;
			}

		}

		protected void CalculateInput(Vector2 inputVector2)
		{
			if (!IsTouched)
			{
				StartTouchVector2 = inputVector2;
				IsTouched = true;
			}

			LastTouchVector2 = inputVector2;
			var swipe = LastTouchVector2 - StartTouchVector2;
			var typeInput = GetTypeCommand(swipe);
			switch (typeInput)
			{
				case CommandInputType.none:
					break;
				case CommandInputType.Swipe:
					LastInputVector2 = swipe;
					break;
			}
		}

		protected void CheckClicked()
		{
			if (!IsTouched)
			{
				Clicked = GetTypeCommand(LastInputVector2) == CommandInputType.Click && IsMoved;
			}
		}
	}
}

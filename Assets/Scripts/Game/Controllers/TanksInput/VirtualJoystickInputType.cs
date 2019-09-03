using Game.Settings;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class VirtualJoystickInputType : BaseInputType
	{
		protected bool IsTouched = false;
		protected Vector2 StartTouchVector2;
		protected Vector2 LastTouchVector2;
		protected bool JustClicked = false;
		private float _keepTime = 0f;

		public override void CheckInput()
		{
			if (Input.GetMouseButton(0))
			{
				CalculateInput(Input.mousePosition);
			}
			else
			{
				IsTouched = false;
				LastInputVector2 = Vector2.zero;
			}
			CheckClicked();
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
					JustClicked = false;
					LastInputVector2 = swipe;
					break;
				case CommandInputType.Click:
					JustClicked = true;
					break;
			}
		}

		protected virtual void CheckClicked()
		{
			if (IsTouched)
			{
				if (JustClicked)
				{
					_keepTime += Time.deltaTime;
					if (_keepTime > InputSettings.ClickKeepTimeStart)
					{
						Clicked = true;
						JustClicked = false;
					}
				}
				else
				{
					_keepTime = 0f;
				}
			}
			else
			{
				_keepTime = 0f;
				if (JustClicked)
				{
					Clicked = true;
					JustClicked = false;
				}
			}
		}
	}
}

using Game.Settings;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class VirtualJoystickInputType : BaseInputType
	{
		/// <summary>
		/// Touched is right now
		/// </summary>
		protected bool IsTouched = false;
		/// <summary>
		/// Start touch position in current swipe
		/// </summary>
		protected Vector2 StartTouchVector2;
		/// <summary>
		/// Last touch position
		/// </summary>
		protected Vector2 LastTouchVector2;
		/// <summary>
		/// Is just cloced
		/// </summary>
		protected bool JustClicked = false;
		/// <summary>
		/// Time for keep
		/// </summary>
		private float _keepTime = 0f;
		/// <summary>
		/// Calculate all inputs
		/// </summary>
		public override void CheckInput()
		{
			if (Input.GetMouseButton(0))
			{
				CalculateSwipeInput(Input.mousePosition);
			}
			else
			{
				IsTouched = false;
				LastInputSwipeVector2 = Vector2.zero;
			}
			CheckClicked();
		}
		/// <summary>
		/// Calculate type current swipe input
		/// </summary>
		/// <param name="inputVector2">Current touch position</param>
		protected void CalculateSwipeInput(Vector2 inputVector2)
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
					LastInputSwipeVector2 = swipe;
					break;
				case CommandInputType.Click:
					JustClicked = true;
					break;
			}
		}
		/// <summary>
		/// Check clicked state
		/// </summary>
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

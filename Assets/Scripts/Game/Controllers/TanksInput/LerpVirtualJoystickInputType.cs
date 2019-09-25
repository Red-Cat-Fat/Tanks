using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class LerpVirtualJoystickInputType : VirtualJoystickInputType
	{
		private float _lerpSpeed = 0.8f;

		protected override void CheckClicked()
		{
			base.CheckClicked();
			StartTouchVector2 = Vector2.Lerp(StartTouchVector2, LastTouchVector2, Time.deltaTime * _lerpSpeed);
		}
	}
}

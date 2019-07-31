using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public class VirtualJoystickInputType2D : VirtualJoystickInputType
	{
		public virtual Vector2 GetDirectionVector2()
		{
			return LastInputVector2.normalized;
		}

		public override Vector3 GetDirectionVector3()
		{
			return GetDirectionVector2();
		}
	}
}
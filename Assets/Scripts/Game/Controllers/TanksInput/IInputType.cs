using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Controllers.TanksInput
{
	public interface IInputType
	{
		Vector3 GetDirectionVector3();
		void CheckInput();
	}
}

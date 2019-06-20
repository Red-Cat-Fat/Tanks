using System.Collections;
using System.Collections.Generic;
using Game.Controllers.TanksInput;
using UnityEngine;

namespace Game.Controllers.Units
{
	public class PlayerController : MonoBehaviour
	{
		private void Update()
		{
			transform.position += InputSystem.Instance.GetDirectionVector3();
		}
	}
}

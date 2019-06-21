﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.DamageControllers
{
	public interface IDamageController
	{
		void SetDamageEvent(Action<GameObject> actionEvent);
		void SetDamage(GameObject targetGameObject);
	}
}
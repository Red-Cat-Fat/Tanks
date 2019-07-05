﻿using Editor.LogSystem;
using Game.Data.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Controllers.Units.MoveControllers
{
	public abstract class BaseMoveController : MonoBehaviour, IMoveController
	{
		private Vector3 _moveTargetVector3 = Vector3.zero;
		protected MoveData MoveData;

		protected virtual void Start()
		{
			MoveData = GetComponent<MoveData>();
			Log.CheckForNull(MoveData, gameObject);
			_moveTargetVector3 = Vector3.zero;
		}

		public virtual Vector3 CulculateTarget()
		{
			return transform.position + _moveTargetVector3;
		}

		public Vector3 GetNextPosirionVector3()
		{
			var directionVector3 = CulculateTarget() - transform.position;
			if (directionVector3 == Vector3.zero) return transform.position;

			var directionForwardBack = Vector3.Dot(transform.forward, directionVector3) <= Settings.InputSettings.StepInJoystickByBackMoved ? -1 : 1;//нужно для езды задом
			var procent = Time.fixedDeltaTime / 1 * directionForwardBack;
			var speed = MoveData.GetSpeedMove();
			var newPositionVector3 = transform.position + (transform.forward * speed * procent);
			return newPositionVector3;
		}

		public Quaternion GetNextRotationQuaternion()
		{
			var directionVector3 = CulculateTarget() - transform.position;
			if (directionVector3 == Vector3.zero) return transform.rotation;

			var direction = Vector3.Dot(transform.forward, directionVector3) <= Settings.InputSettings.StepInJoystickByBackMoved ? -1 : 1;//нужно для езды задом
			var rotation = Quaternion.LookRotation(directionVector3 * direction);
			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * MoveData.GetSpeedRotation());
			return teleportToRotation;
		}
	}
}
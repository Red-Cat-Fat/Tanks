using Assets.Scripts.Game.Controllers.Units;
using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public static class Vector3Extension
	{
		/// <summary>
		/// This work only if NormalDirectionVector == Vector3.back
		/// </summary>
		/// <param name="vector"></param>
		/// <returns>Angle in current system</returns>
		public static float GetAngleInGameSystemInDeg(this Vector3 vector)
		{
			var rotationAngle = Mathf.Atan2(vector.x, vector.y);
			return rotationAngle * Mathf.Rad2Deg;
		}
	}
	public interface IMoveController : IUnitsController
	{
		Vector3 CulculateTarget();
		/// <summary>
		/// Calculate next position in path
		/// </summary>
		/// <returns>Next position</returns>
		Vector3 GetNextPosirionVector3();
		Quaternion GetNextRotationQuaternion();
	}
}

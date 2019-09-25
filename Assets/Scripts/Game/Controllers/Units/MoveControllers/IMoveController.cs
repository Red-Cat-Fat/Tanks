using UnityEngine;

namespace Game.Controllers.Units.MoveControllers
{
	public interface IMoveController
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

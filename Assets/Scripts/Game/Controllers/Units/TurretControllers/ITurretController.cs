using UnityEngine;

namespace Game.Controllers.Units.TurretController
{
	public interface ITurretController
	{
		Quaternion GetNextRotationQuaternion(Vector3 axisVector3);
	}
}

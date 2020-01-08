using UnityEngine;

namespace Game.Controllers.Units.TurretController
{
	public interface ITurretController : IUnitsController
	{
		Quaternion GetNextRotationQuaternion(Vector3 axisVector3);
	}
}

using Game.Controllers.Units.MoveControllers;
using UnityEngine;

namespace Game.Renderer.Camera
{
	public class FollowCameraData : MonoBehaviour
	{
		[SerializeField] private bool _isRotate = true;
		[SerializeField] private GameObject _anchorPoint;
		[SerializeField] private GameObject _followObject;
		[SerializeField] private float _moveSpeed;
		[SerializeField] private float _rotateSpeed;

		/// <summary>
		/// Get anchor point or find new anchor point by PlayerCameraTag
		/// </summary>
		/// <returns></returns>
		public GameObject GetAnchorPoint()
		{
			if (_anchorPoint == null)
			{
				var newAcnhorPoint = FindObjectsOfType<CameraTags.PlayerCameraTag>();
				foreach (var cameraTag in newAcnhorPoint)
				{
					var parentComponent = cameraTag.GetComponentInParent<PlayerMoveController>();
					if (parentComponent != null)
					{
						SetAnchorPoint(cameraTag.gameObject);
						break;
					}
				}
			}
			return _anchorPoint;
		}

		public void SetAnchorPoint(GameObject anchorPoint)
		{
			_anchorPoint = anchorPoint;
		}

		public GameObject GetFollowObject()
		{
			return _isRotate ? _followObject : null;
		}

		public float GetMoveSpeed()
		{
			return _moveSpeed;
		}

		public float GetRotateSpeed()
		{
			return _isRotate ? _rotateSpeed : 0;
		}
	}
}
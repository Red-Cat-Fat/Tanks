using UnityEngine;
using Logger = Editor.Utility.Logger.Logger;

namespace Game.Renderer.Camera
{
	public class FollowCameraSystem : MonoBehaviour
	{
		private FollowCameraData _followCameraData;
		private Vector3 _lastAnchorPointPositionVector3;
		private float _moveTime = 0f;

		private void Start()
		{
			_followCameraData = GetComponent<FollowCameraData>();
			Logger.CheckForNull(_followCameraData, gameObject, typeof(FollowCameraData));
		}

		private void FixedUpdate()
		{
			var anchorPoint = _followCameraData.GetAnchorPoint();
			var moveSpeed = _followCameraData.GetMoveSpeed();
			var followObject = _followCameraData.GetFollowObject();

			if (anchorPoint.transform.position != _lastAnchorPointPositionVector3)
			{
				_lastAnchorPointPositionVector3 = anchorPoint.transform.position;
				_moveTime = 0f;
			}
			_moveTime += Time.deltaTime;
			var progress = _moveTime * moveSpeed;
			if (progress > 1f)
			{
				transform.position = _lastAnchorPointPositionVector3;
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, _lastAnchorPointPositionVector3, progress);
			}
			var roteteSpeed = _followCameraData.GetRotateSpeed();
			var rotateProgress = roteteSpeed * _moveTime;

			if (followObject != null)
			{
				LookAt(followObject.transform.position, rotateProgress);
			}
		}

		private void LookAt(Vector3 position, float progress)
		{
			var directionVector3 = position - transform.position;
			if (directionVector3 == Vector3.zero) return;
			var rotation = Quaternion.LookRotation(directionVector3);
			var teleportToRotation = Quaternion.Slerp(transform.rotation, rotation, progress);
			transform.rotation = teleportToRotation;
		}
	}
}
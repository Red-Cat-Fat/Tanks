using UnityEngine;

namespace Game.Renderer.Camera
{
	[RequireComponent(typeof(FollowCameraData))]
	public class FollowCameraSystem : MonoBehaviour
	{
		[SerializeField, HideInInspector]
		private FollowCameraData _followCameraData;
		private Vector3 _lastAnchorPointPositionVector3;
		private float _moveTime = 0f;

		private GameObject anchorPoint = null;
		private float moveSpeed = 0f;
		private GameObject followObject = null;

		private void OnValidate()
		{
			_followCameraData = GetComponent<FollowCameraData>();
		}

		private void Start()
		{
			if (_followCameraData != null)
			{
				anchorPoint = _followCameraData.GetAnchorPoint();
				moveSpeed = _followCameraData.GetMoveSpeed();
				followObject = _followCameraData.GetFollowObject();
			}
		}

		private void FixedUpdate()
		{
			if (anchorPoint == null) return;
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
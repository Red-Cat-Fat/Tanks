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

		public GameObject GetAnchorPoint()
		{
			return _anchorPoint;
		}

		public GameObject GetFollowObject()
		{
			return _isRotate ? _followObject : null;\
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
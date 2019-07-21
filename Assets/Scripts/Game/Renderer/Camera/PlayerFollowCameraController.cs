using System.Collections;
using System.Collections.Generic;
using Editor.LogSystem;
using Game.Controllers.GameControllers;
using Game.Renderer.Camera.CameraTags;
using UnityEngine;

namespace Game.Renderer.Camera
{
	public class PlayerFollowCameraController : MonoBehaviour
	{
		private void Start()
		{
			var player = GameManager.Instance.GetPlayerGameObject();
			if (player == null)
			{
				Debug.Log("Error");
			}
			var followPoints = player.GetComponentsInChildren<ICameraTag>();
			foreach (var point in followPoints)
			{
				if (point is PlayerCameraTag)
				{
					var followCameraData = GetComponent<FollowCameraData>();
					Log.CheckForNull(followCameraData, gameObject, typeof(FollowCameraData));
					followCameraData.SetAnchorPoint(point.GetPoint());
				}
			}
		}
	}
}

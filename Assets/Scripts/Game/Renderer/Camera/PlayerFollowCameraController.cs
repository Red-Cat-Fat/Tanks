using Game.Controllers.GameControllers;
using Game.Renderer.Camera.CameraTags;
using UnityEngine;
using Logger = Editor.Utility.Logger.Logger;

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

			if (player != null)
			{
				var followPoints = player.GetComponentsInChildren<ICameraTag>();
				foreach (var point in followPoints)
				{
					if (point is PlayerCameraTag)
					{
						var followCameraData = GetComponent<FollowCameraData>();
						Logger.CheckForNull(followCameraData, gameObject, typeof(FollowCameraData));
						followCameraData.SetAnchorPoint(point.GetPoint());
					}
				}
			}
		}
	}
}

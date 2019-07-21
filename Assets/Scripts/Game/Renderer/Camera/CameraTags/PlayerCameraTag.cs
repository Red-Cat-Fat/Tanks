using UnityEngine;


namespace Game.Renderer.Camera.CameraTags
{
	public class PlayerCameraTag : MonoBehaviour, ICameraTag
	{
		public GameObject GetPoint()
		{
			return gameObject;
		}
	}
}
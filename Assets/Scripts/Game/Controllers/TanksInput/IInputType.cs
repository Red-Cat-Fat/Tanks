using Game.Settings;
using UnityEngine;


namespace Game.Controllers.TanksInput
{
	public enum CommandInputType
	{
		none,
		Swipe,
		Click
	}

	public interface IInputType
	{
		bool IsClicked();
		Vector2 GetDirectionVector();
		void CheckInput();
	}

	public abstract class BaseInputType : MonoBehaviour, IInputType
	{
		/// <summary>
		/// Last input swipe vector
		/// </summary>
		protected Vector2 LastInputSwipeVector2;

		protected bool Clicked = false;
		public abstract void CheckInput();
		
		public virtual Vector2 GetDirectionVector()
		{
			return LastInputSwipeVector2.normalized;
		}

		public virtual bool IsClicked()
		{
			if (Clicked)
			{
				Clicked = false;
				return true;
			}
			return false;
		}

		protected static CommandInputType GetTypeCommand(Vector2 inputVector2)
		{
			if (inputVector2.magnitude < InputSettings.ClickMagnitudeMaxSize)
			{
				return CommandInputType.Click;
			}

			return CommandInputType.Swipe;
		}

	}
}

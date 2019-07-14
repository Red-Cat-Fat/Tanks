using Game.Settings;
using System.Collections;
using System.Collections.Generic;
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
		Vector3 GetDirectionVector3();
		Vector2 GetDirectionVector2();
		void CheckInput();
	}

	public abstract class BaseInputType : MonoBehaviour, IInputType
	{
		protected Vector2 LastInputVector2;
		protected bool Clicked = false;
		public abstract void CheckInput();

		public virtual Vector2 GetDirectionVector2()
		{
			return LastInputVector2.normalized;
		}

		public virtual Vector3 GetDirectionVector3()
		{
			var direction = new Vector3(LastInputVector2.x, 0, LastInputVector2.y);
			return direction.normalized;
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
			if(inputVector2.magnitude < InputSettings.ClickMagnitudeMaxSize)
			{
				return CommandInputType.Click;
			}
			else
			{
				return CommandInputType.Swipe;
			}
		}

	}
}

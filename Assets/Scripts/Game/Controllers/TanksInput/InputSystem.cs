using System;
using System.Collections;
using System.Collections.Generic;
using Game.HelpModules;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public enum InputTypeEnum
	{
		Swipe,
		SwipeMouse
	}
	public class InputSystem : SingletonBehaviour<InputSystem>
	{
		[SerializeField] private InputTypeEnum _currentInputTypeEnum = InputTypeEnum.Swipe;
		private IInputType _currentInputType;

		public void SetCurrentInputType(IInputType newInputType)
		{
			_currentInputType = newInputType;
			switch (_currentInputTypeEnum)
			{
				case InputTypeEnum.Swipe:
					_currentInputType = new SwipeInputType();
					break;
				case InputTypeEnum.SwipeMouse:
					_currentInputType = new SwipeMouseInputType();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public Vector3 GetDirectionVector3()
		{
			return _currentInputType.GetDirectionVector3();
		}

		public void CheckInput()
		{
			_currentInputType.CheckInput();
		}

		private void Awake()
		{
			SetCurrentInputType(_currentInputType);
		}

		private void Update()
		{
			CheckInput();
		}
	}
}

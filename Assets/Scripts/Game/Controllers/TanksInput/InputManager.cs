﻿using System;
using Game.HelpModules;
using UnityEngine;

namespace Game.Controllers.TanksInput
{
	public enum InputTypeEnum
	{
		Swipe,
		SwipeMouse,
		VirtualJoystick,
		VirtualJoystick2D
	}
	public class InputManager : SingletonBehaviour<InputManager>
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
				case InputTypeEnum.VirtualJoystick:
					_currentInputType = new VirtualJoystickInputType();
					break;
				case InputTypeEnum.VirtualJoystick2D:
					_currentInputType = new LerpVirtualJoystickInputType();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public Vector3 GetDirectionVector()
		{
			return _currentInputType.GetDirectionVector();
		}

		public bool IsClicked()
		{
			return _currentInputType.IsClicked();
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

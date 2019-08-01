using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Utillity.DigitalSignalPeocessing.Filters
{
	public class FloatMovingAverageWindow
	{
		private int _sizeWindow = 3;
		private float[] _window;
		private int _index = 0;
		public FloatMovingAverageWindow(int sizeWindow)
		{
			_sizeWindow = sizeWindow;
			_window = new float[sizeWindow];
		}

		public void AddValue(float value)
		{
			_index++;
			if (_index >= _sizeWindow)
			{
				_index = 0;
			}

			_window[_index] = value;
		}

		public float GetValue()
		{
			float sum = 0;
			foreach (var value in _window)
			{
				sum += value;
			}

			return sum / _sizeWindow;
		}
	}
}

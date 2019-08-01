using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Utillity.DigitalSignalPeocessing.Filters
{
	public class BoolMovingAvargeWindow
	{
		private FloatMovingAverageWindow _averageWindow;
		private float _procentTrigger = 0.5f;

		public BoolMovingAvargeWindow(int sizeWindow, float procentTrigger = 0.5f)
		{
			_averageWindow = new FloatMovingAverageWindow(sizeWindow);
			_procentTrigger = procentTrigger;
		}

		public void AddValue(bool value)
		{
			_averageWindow.AddValue(value ? 1 : 0);
		}

		public bool GetValue()
		{
			var serult = _averageWindow.GetValue();
			return serult > _procentTrigger;
		}
	}
}

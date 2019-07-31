using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.Utility.Logger.TimeLogSystem
{
	public class DeltaTime : ICloneable
	{
		private DateTime _startTime;
		private DateTime _endTime;
		private bool _inProgress = false;

		public DeltaTime()
		{
		}

		private DeltaTime(DateTime startTime, DateTime endTime)
		{
			_startTime = startTime;
			_endTime = endTime;
		}

		public bool InProgress()
		{
			return _inProgress;
		}

		public void Start()
		{
			_startTime = DateTime.Now;
			_inProgress = true;
		}

		public void Stop()
		{
			if (_inProgress)
			{
				_endTime = DateTime.Now;
				_inProgress = false;
			}
		}

		public TimeSpan GetWorkTime()
		{
			return _endTime.Subtract(_startTime);
		}

		public TimeSpan GetWorkTime(DateTime currentTime)
		{
			return currentTime.Subtract(_startTime);
		}

		public DateTime GetStartTime()
		{
			return _startTime;
		}

		public DateTime GetEndTime()
		{
			return _endTime;
		}

		public object Clone()
		{
			return new DeltaTime(_startTime, _endTime);
		}
	}
}

using System;

namespace Editor.Utility.Logger.TimeLogSystem
{
	public class DeltaTime
	{
		private DateTime _startTime;
		private DateTime _endTime;
		private bool _inProgress = false;

		public DateTime GetStartTime()
		{
			return _startTime;
		}

		public DateTime GetEndTime()
		{
			return _endTime;
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

	}
}

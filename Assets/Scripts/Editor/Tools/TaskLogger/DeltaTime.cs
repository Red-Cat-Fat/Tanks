using System;
using UnityEngine;

namespace Editor.Tools.TaskLogger
{
	[Serializable]
	public class DeltaTime
	{
		[SerializeField]
		public LogDateTime StartTime;
		[SerializeField]
		public LogDateTime EndTime;

		[SerializeField]
		private bool _inProgress = false;

		public bool IsInProgress()
		{
			return _inProgress;
		}

		public LogDateTime GetStartTime()
		{
			return StartTime;
		}

		public LogDateTime GetEndTime()
		{
			return EndTime;
		}

		public void Start()
		{
			StartTime = DateTime.Now;
			_inProgress = true;
		}

		public void Stop()
		{
			if (_inProgress)
			{
				EndTime = DateTime.Now;
				_inProgress = false;
			}
		}

		public LogDateTime GetWorkTime()
		{
			return GetEndTime() - GetStartTime();
		}

	}
}

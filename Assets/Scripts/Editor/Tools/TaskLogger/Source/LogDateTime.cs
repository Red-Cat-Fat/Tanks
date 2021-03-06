﻿using System;
using UnityEngine;

namespace Editor.Tools.TaskLogger
{
	[Serializable]
	public class LogDateTime
	{
		[SerializeField]
		private int _hour = 0;

		public int Hour
		{
			get => _hour;
			set
			{
				if (value < 0)
				{
					Day--;
					_hour = value + 24;
					return;
				}

				if (value >= 24)
				{
					Day++;
					_hour = value - 24;
				}
				else
				{
					_hour = value;
				}
			}
		}
		
		[SerializeField]
		private int _minute = 0;

		public int Minute
		{
			get => _minute;
			set
			{
				if (value < 0)
				{
					Hour--;
					_minute = value + 60;
					return;
				}

				if (value >= 60)
				{
					Hour++;
					_minute = value - 60;
				}
				else
				{
					_minute = value;
				}
			}
		}
		
		[SerializeField]
		private int _second = 0;

		public int Second
		{
			get => _second;
			set
			{
				if (value < 0)
				{
					Minute--;
					_second = value + 60;
					return;
				}

				if (value >= 60)
				{
					Minute++;
					_second = value - 60;
				}
				else
				{
					_second = value;
				}
			}
		}

		[SerializeField]
		private int _year = 2019;

		public int Year
		{
			get
			{
				if (_year < 2019) { _year = 2019; }
				return _year;
			}
			set => _year = value > 2019 ? value : 2019;
		}

		[field: SerializeField]
		public int Day { get; set; } = 0;

		[field: SerializeField]
		public int Month { get; set; } = 0;
		
		#region Overrides
		public static LogDateTime operator +(LogDateTime logDate1, LogDateTime logDate2)
		{
			return new LogDateTime
			{
				Year = logDate1.Year,
				Month = logDate1.Month,
				Day = logDate1.Day,
				Hour = logDate1.Hour + logDate2.Hour,
				Minute = logDate1.Minute + logDate2.Minute,
				Second = logDate1.Second + logDate2.Second
			};
		}

		public static LogDateTime operator -(LogDateTime logDate1, LogDateTime logDate2)
		{
			if (logDate1 == null)
			{
				return new LogDateTime();
			}
			if (logDate2 == null)
			{
				return logDate1;
			}
			return new LogDateTime
			{
				Year = logDate1.Year,
				Month = logDate1.Month,
				Day = logDate1.Day,
				Hour = logDate1.Hour - logDate2.Hour,
				Minute = logDate1.Minute - logDate2.Minute,
				Second = logDate1.Second - logDate2.Second
			};
		}

		public override string ToString()
		{
			var h = Hour < 10 ? "0" + Hour : Hour.ToString();
			var m = Minute < 10 ? "0" + Minute : Minute.ToString();
			var s = Second < 10 ? "0" + Second : Second.ToString();
			return $"{h}:{m}:{s}";
		}

		public string ToString(bool isFull)
		{ 
			var dd = Day < 10 ? "0" + Day : Day.ToString();
			var mm = Month < 10 ? "0" + Month : Month.ToString();
			return $"{dd}.{mm}.{Year} {ToString()}";
		}
		
		public static implicit operator LogDateTime(DateTime dateTime)
		{
			return new LogDateTime
			{
				Year = dateTime.Year,
				Month = dateTime.Month,
				Day = dateTime.Day,
				Hour = dateTime.Hour,
				Minute = dateTime.Minute,
				Second = dateTime.Second
			};
		}

		public static explicit operator DateTime(LogDateTime logDateTime)
		{
			return new DateTime(logDateTime.Year, logDateTime.Month, logDateTime.Day, logDateTime.Hour, logDateTime.Minute, logDateTime.Second);
		}

		#endregion
	}
}

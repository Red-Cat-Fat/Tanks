using System;
using Editor.Tools.TaskLogger;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Utility.LogSystem.TimeLogSystem
{
	public class LogDateTimeTest : MonoBehaviour
	{
		[Test]
		public void TestSumResult()
		{
			LogDateTime logDateTimeA = new DateTime(2019, 1, 1, 12, 0, 3);
			LogDateTime logDateTimeB = new DateTime(2019, 1, 1, 17, 2, 0);

			var tesult = logDateTimeA + logDateTimeB;
			LogDateTime trueValue = new DateTime(2019, 1, 2, 5, 2, 3);

			Debug.Log(logDateTimeA.ToString(true) + "\n+\n" + logDateTimeB.ToString(true) + "\n=\n" + tesult.ToString(true));
			Debug.Log(trueValue.ToString(true) + " <- true value");

			Assert.IsTrue(tesult.ToString(true) == trueValue.ToString(true));
		}

		[Test]
		public void TestSubtractResult()
		{
			LogDateTime logDateTimeA = new DateTime(2019, 1, 3, 12, 0, 3);
			LogDateTime logDateTimeB = new DateTime(2019, 1, 1, 17, 2, 0);

			var tesult = logDateTimeA - logDateTimeB;
			LogDateTime trueValue = new DateTime(2019, 1, 2, 18, 58, 3);

			Debug.Log(logDateTimeA.ToString(true) + "\n-\n" + logDateTimeB.ToString(true) + "\n=\n" + tesult.ToString(true));
			Debug.Log(trueValue.ToString(true) + " <- true value");

			Assert.IsTrue(tesult.ToString(true) == trueValue.ToString(true));
		}
	}
}
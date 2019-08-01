using Game.Controllers.GameControllers;
using Game.Utillity.DigitalSignalPeocessing.Filters;
using UnityEngine;
using Logger = Editor.Utility.Logger.Logger;

namespace Game.Controllers.Units.MoveControllers
{
	public class PlayerTurretMoveController : BaseMoveController
	{
		private Vector3 _lastPositionVector3 = Vector3.zero;
		private const int CountThueCheckerTrigger = 3;
		private BoolMovingAvargeWindow _boolRotateMovingAvargeWindow = new BoolMovingAvargeWindow(CountThueCheckerTrigger);

		public void Update()
		{
			TryChangeCanRotate();
		}

		public bool IsStay()
		{
			return transform.position == _lastPositionVector3; 
		}

		public void TryChangeCanRotate()
		{
			var canRotate = IsStay();

			_boolRotateMovingAvargeWindow.AddValue(canRotate);
			UnitMoveData.SetIsCanRotate(_boolRotateMovingAvargeWindow.GetValue());
			//Logger.SendMessageToConsole(this, canRotate.ToString() + ' ' +_countThueChecker);
			_lastPositionVector3 = transform.position;
		}

		public override Vector3 CulculateTarget()
		{
			if (UnitMoveData.GetIsCanRotate())
			{
				var target = GameManager.Instance.GetMinDistanceEnemy(transform.position);
				if (target != null)
				{
					return target.transform.position;
				}
			}
			return UnitMoveData.GetForwardDirectionVector3(transform) + transform.position;
		}
	}
}
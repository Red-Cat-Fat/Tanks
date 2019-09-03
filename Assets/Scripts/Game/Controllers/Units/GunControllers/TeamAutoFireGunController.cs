using UnityEngine;
using Game.Data.Units;

namespace Game.Controllers.Units.GunControllers
{
	[RequireComponent(typeof(TeamData))]
	public class TeamAutoFireGunController : PhysicalGunController
	{
		[SerializeField, HideInInspector] protected TeamData UnitTeamData;
		private MoveData _unitMoveData;

		protected override void OnValidate()
		{
			UnitTeamData = GetComponent<TeamData>();
			_unitMoveData = GetComponent<MoveData>();
			base.OnValidate();
		}

		public override bool IsCanFire()
		{
			bool isEnemy = false;
			var hit = Physics2D.Raycast(GunData.GetGunPoint().transform.position,
				GunData.GetGunPoint().transform.right);
			Debug.DrawLine(GunData.GetGunPoint().transform.position, GunData.GetGunPoint().transform.right + GunData.GetGunPoint().transform.position, Color.white);

			if (hit.collider != null)
			{
				Debug.DrawLine(GunData.GetGunPoint().transform.position, GunData.GetGunPoint().transform.right + GunData.GetGunPoint().transform.position, Color.red);

				var colliderGameObject = hit.collider.gameObject;
				if (colliderGameObject != null)
				{
					var targetTeamData = colliderGameObject.GetComponent<TeamData>(); //TODO: Ускорить
					isEnemy = targetTeamData == null
					          || targetTeamData.GetTeamType() != UnitTeamData.GetTeamType();
				}
			}

			var moveResolve = _unitMoveData == null
			                  || (_unitMoveData != null
			                      && !_unitMoveData.GetIsMove());
			return isEnemy && base.IsCanFire() && moveResolve;
		}
	}
}

using UnityEngine;

namespace Game.Data.Units
{
	public enum TeamType
	{
		Player,
		Computer
	}
	public class TeamData : MonoBehaviour
	{
		[SerializeField] private TeamType _teamType;

		public TeamType GetTeamType()
		{
			return _teamType;
		}
	}
}

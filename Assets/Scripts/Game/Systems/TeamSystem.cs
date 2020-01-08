using Game.Controllers.Units.TeamControllers;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	[RequireComponent(typeof(ITeamController), typeof(TeamData))]
	public class TeamSystem : MonoBehaviour, ISystem
	{
		[SerializeField, HideInInspector] private TeamData _teamData;
		[SerializeField, HideInInspector] private ITeamController _teamController;

		private void OnValidate()
		{
			_teamData = GetComponent<TeamData>();
		}

		private void Awake()
		{
			_teamController = GetComponent<ITeamController>();
			_teamController?.InitialAction();
		}
	}
}

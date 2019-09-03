using Game.Controllers.Units.TeamControllers;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	[RequireComponent(typeof(ITeamController), typeof(TeamData))]
	public class TeamSystem : MonoBehaviour
	{
		[SerializeField, HideInInspector] private TeamData _teamData;
		[SerializeField, HideInInspector] private ITeamController _teamController;

		private void OnValidate()
		{
			_teamData = GetComponent<TeamData>();
			_teamController = GetComponent<ITeamController>();
		}

		private void Awake()
		{
			_teamController.InitialAction();
		}
	}
}

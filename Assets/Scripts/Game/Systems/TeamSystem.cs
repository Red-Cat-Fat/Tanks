using System.Collections;
using System.Collections.Generic;
using Editor.LogSystem;
using Game.Controllers.Units.TeamControllers;
using Game.Data.Units;
using UnityEngine;

namespace Game.Systems
{
	public class TeamSystem : MonoBehaviour
	{
		private TeamData _teamData;
		private ITeamController _teamController;
		private void Start()
		{
			_teamData = GetComponent<TeamData>();
			_teamController = GetComponent<ITeamController>();

			Log.CheckForNull(_teamData, gameObject, typeof(TeamData));
			Log.CheckForNull(_teamController, gameObject, typeof(ITeamController));

			_teamController.InitialAction();
		}
	}
}

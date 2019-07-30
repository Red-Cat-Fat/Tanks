using System.Collections;
using System.Collections.Generic;
using Editor.Utility.Logger;
using Game.Controllers.Units.TeamControllers;
using Game.Data.Units;
using UnityEngine;
using Logger = Editor.Utility.Logger.Logger;

namespace Game.Systems
{
	public class TeamSystem : MonoBehaviour
	{
		private TeamData _teamData;
		private ITeamController _teamController;
		private void Awake()
		{
			_teamData = GetComponent<TeamData>();
			_teamController = GetComponent<ITeamController>();

			Logger.CheckForNull(_teamData, gameObject, typeof(TeamData));
			Logger.CheckForNull(_teamController, gameObject, typeof(ITeamController));

			_teamController.InitialAction();
		}
	}
}

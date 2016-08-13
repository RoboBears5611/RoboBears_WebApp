using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class TeamManager : ITeamManager
    {
        private ITeamAccessor _teamAccessor;
        public ITeamAccessor TeamAccessor
        {
            get
            {
                return _teamAccessor ?? ClassFactory.CreateClass<ITeamAccessor>();
            }
            set
            {
                _teamAccessor = value;
            }
        }
        public Team CreateTeam(Team team)
        {
            return TeamAccessor.CreateTeam(team);
        }

        public Team GetTeamById(int teamId)
        {
            return TeamAccessor.GetTeamById(teamId);
        }

        public Team[]
        GetTeams()
        {
            return TeamAccessor.GetTeams();
        }

        public Team ModifyTeam(Team newTeam)
        {
            return TeamAccessor.ModifyTeam(newTeam);
        }
    }
}

using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface ITeamManager
    {
        Team GetTeamById(int teamId);

        Team[] GetTeams();

        Team CreateTeam(Team team);

        Team ModifyTeam(Team newTeam);
    }
}

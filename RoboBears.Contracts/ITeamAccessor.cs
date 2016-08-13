using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface ITeamAccessor
    {
        Team GetTeamById(int teamId);

        Team[] GetTeams();

        Team CreateTeam(Team team);

        Team ModifyTeam(Team newTeam);
    }
}

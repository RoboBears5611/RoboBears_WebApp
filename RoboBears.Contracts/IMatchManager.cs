using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IMatchManager
    {
        Match GetMatchById(int matchId);

        Match[] GetMatches();

        Match CreateMatch(Match match);

        Match ModifyMatch(Match newMatch);
    }
}

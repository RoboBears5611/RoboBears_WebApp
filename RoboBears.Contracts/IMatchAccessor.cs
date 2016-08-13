using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IMatchAccessor
    {
        Match GetMatchById(int matchId);

        Match[] GetMatches();

        Match CreateMatch(Match match);

        Match ModifyMatch(Match newMatch);
    }
}

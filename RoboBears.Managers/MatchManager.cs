using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class MatchManager : IMatchManager
    {
        private IMatchAccessor _matchAccessor;
        public IMatchAccessor MatchAccessor
        {
            get
            {
                return _matchAccessor ?? ClassFactory.CreateClass<IMatchAccessor>();
            }
            set
            {
                _matchAccessor = value;
            }
        }
        public Match CreateMatch(Match match)
        {
            return MatchAccessor.CreateMatch(match);
        }

        public Match GetMatchById(int matchId)
        {
            return MatchAccessor.GetMatchById(matchId);
        }

        public Match[]
        GetMatches()
        {
            return MatchAccessor.GetMatches();
        }

        public Match ModifyMatch(Match newMatch)
        {
            return MatchAccessor.ModifyMatch(newMatch);
        }
    }
}

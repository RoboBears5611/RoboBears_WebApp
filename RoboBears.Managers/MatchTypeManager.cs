using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class MatchTypeManager : IMatchTypeManager
    {
        private IMatchTypeAccessor _matchTypeAccessor;
        public IMatchTypeAccessor MatchTypeAccessor
        {
            get
            {
                return _matchTypeAccessor ?? ClassFactory.CreateClass<IMatchTypeAccessor>();
            }
set
            {
                _matchTypeAccessor = value;
            }
        }
        public MatchType CreateMatchType(MatchType matchType)
        {
            return MatchTypeAccessor.CreateMatchType(matchType);
        }

        public MatchType GetMatchTypeById(int matchTypeId)
{
    return MatchTypeAccessor.GetMatchTypeById(matchTypeId);
}

public MatchType[]
GetMatchTypes()
{
    return MatchTypeAccessor.GetMatchTypes();
}

public MatchType ModifyMatchType(MatchType newMatchType)
        {
            return MatchTypeAccessor.ModifyMatchType(newMatchType);
        }
    }
}

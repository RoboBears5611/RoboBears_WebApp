using RoboBears.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.Contracts
{
    public interface IMatchTypeManager
    {
        MatchType GetMatchTypeById(int matchTypeId);

        MatchType[] GetMatchTypes();

        MatchType CreateMatchType(MatchType matchType);

        MatchType ModifyMatchType(MatchType newMatchType);

    }
}

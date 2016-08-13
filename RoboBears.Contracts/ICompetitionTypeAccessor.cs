using RoboBears.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.Contracts
{
    public interface ICompetitionTypeAccessor
    {
        CompetitionType GetCompetitionTypeById(int competitionTypeId);

        CompetitionType[] GetCompetitionTypes();

        CompetitionType CreateCompetitionType(CompetitionType competitionType);

        CompetitionType ModifyCompetitionType(CompetitionType newCompetition);
    }
}

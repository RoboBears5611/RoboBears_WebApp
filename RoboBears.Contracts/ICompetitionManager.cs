using RoboBears.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.Contracts
{
    public interface ICompetitionManager
    {
        Competition GetCompetitionById(int competitionId);

        Competition[] GetCompetitions();

        Competition CreateCompetition(Competition competition);

        Competition ModifyCompetition(Competition newCompetition);
    }
}

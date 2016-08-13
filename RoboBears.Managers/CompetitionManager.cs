using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class CompetitionManager : ICompetitionManager
    {
        private ICompetitionAccessor _competitionAccessor;
        public ICompetitionAccessor CompetitionAccessor
        {
            get
            {
                return _competitionAccessor ?? ClassFactory.CreateClass<ICompetitionAccessor>();
            }
            set
            {
                _competitionAccessor = value;
            }
        }
        public Competition CreateCompetition(Competition competition)
        {
            return CompetitionAccessor.CreateCompetition(competition);
        }

        public Competition GetCompetitionById(int competitionId)
        {
            return CompetitionAccessor.GetCompetitionById(competitionId);
        }

        public Competition[]
        GetCompetitions()
        {
            return CompetitionAccessor.GetCompetitions();
        }

        public Competition ModifyCompetition(Competition newCompetition)
        {
            return CompetitionAccessor.ModifyCompetition(newCompetition);
        }
    }
}

using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class CompetitionTypeManager : ICompetitionTypeManager
    {
        private ICompetitionTypeAccessor _competitionTypeAccessor;
        public ICompetitionTypeAccessor CompetitionTypeAccessor
        {
            get
            {
                return _competitionTypeAccessor ?? ClassFactory.CreateClass<ICompetitionTypeAccessor>();
            }
            set
            {
                _competitionTypeAccessor = value;
            }
        }
        public CompetitionType CreateCompetitionType(CompetitionType competitionType)
        {
            return CompetitionTypeAccessor.CreateCompetitionType(competitionType);
        }

        public CompetitionType GetCompetitionTypeById(int competitionTypeId)
        {
            return CompetitionTypeAccessor.GetCompetitionTypeById(competitionTypeId);
        }

        public CompetitionType[]
        GetCompetitionTypes()
        {
            return CompetitionTypeAccessor.GetCompetitionTypes();
        }

        public CompetitionType ModifyCompetitionType(CompetitionType newCompetitionType)
        {
            return CompetitionTypeAccessor.ModifyCompetitionType(newCompetitionType);
        }
    }
}

using RoboBears.DataContracts;

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

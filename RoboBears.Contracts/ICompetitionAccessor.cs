using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface ICompetitionAccessor
    {
        Competition GetCompetitionById(int competitionId);

        Competition[] GetCompetitions();

        Competition CreateCompetition(Competition competition);

        Competition Modify(Competition newCompetition);
    }
}

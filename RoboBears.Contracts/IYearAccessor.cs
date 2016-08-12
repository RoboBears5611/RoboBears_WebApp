using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IYearAccessor
    {
        Year GetYearById(int yearId);

        Year[] GetYears();

        Year CreateYear(Year year);

        Year ModifyYear(Year newYear);
    }
}

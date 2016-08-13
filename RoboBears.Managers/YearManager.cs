using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class YearManager : IYearManager
    {
        private IYearAccessor _yearAccessor;
        public IYearAccessor YearAccessor
        {
            get
            {
                return _yearAccessor ?? ClassFactory.CreateClass<IYearAccessor>();
            }
            set
            {
                _yearAccessor = value;
            }
        }
        public Year CreateYear(Year year)
        {
            return YearAccessor.CreateYear(year);
        }

        public Year GetYearById(int yearId)
        {
            return YearAccessor.GetYearById(yearId);
        }

        public Year[]
        GetYears()
        {
            return YearAccessor.GetYears();
        }

        public Year ModifyYear(Year newYear)
        {
            return YearAccessor.ModifyYear(newYear);
        }
    }
}

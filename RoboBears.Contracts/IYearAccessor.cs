using RoboBears.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.Contracts
{
    public interface IYearAccessor
    {
        Year GetYearById(int yearId);

        Year[] GetYears();

        Year CreateYear(Year year);

        Year ModifyYear(Year newYear, int oldYearId);
    }
}

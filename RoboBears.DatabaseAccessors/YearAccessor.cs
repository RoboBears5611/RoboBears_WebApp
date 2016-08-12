using RoboBears.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboBears.DataContracts;
using Year = RoboBears.DataContracts.Year;
using RoboBears.DatabaseAccessors.EntityFramework;

namespace RoboBears.DatabaseAccessors
{
    public class YearAccessor : IYearAccessor
    {
        public Year CreateYear(Year year)
        {
            using (var db = new DatabaseContext())
            {
                var CreatedYear = db.Years.Add((EntityFramework.Year)year);
                db.SaveChanges();
                return (Year)CreatedYear;
            }
        }

        public Year GetYearById(int yearId)
        {
            using (var db = new DatabaseContext())
            {
                return (Year)db.Years.Find(yearId);
            }
        }

        public Year[] GetYears()
        {
            throw new NotImplementedException();
        }

        public Year ModifyYear(Year newYear, int oldYearId)
        {
            throw new NotImplementedException();
        }
    }
}

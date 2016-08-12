using RoboBears.Contracts;
using System.Linq;
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
            using (var db = new DatabaseContext())
            {
                return db.Years.Select(year => (Year)year).ToArray();
            }
        }

        public Year ModifyYear(Year newYear)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newYear).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Year)db.Years.Find(newYear.YearId);
            }
        }
    }
}

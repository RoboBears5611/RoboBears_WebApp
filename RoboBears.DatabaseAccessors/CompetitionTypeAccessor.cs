using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using CompetitionType = RoboBears.DataContracts.CompetitionType;

namespace RoboBears.DatabaseAccessors
{
    public class CompetitionTypeAccessor : ICompetitionTypeAccessor
    {
        public CompetitionType CreateCompetitionType(CompetitionType competitionType)
        {
            using (var db = new DatabaseContext())
            {
                CompetitionType CreatedCompetitionType = (CompetitionType)db.CompetitionTypes.Add((EntityFramework.CompetitionType)competitionType);
                db.SaveChanges();
                return CreatedCompetitionType;
            }
        }

        public CompetitionType GetCompetitionTypeById(int competitionTypeId)
        {
            using (var db = new DatabaseContext())
            {
                return (CompetitionType)db.CompetitionTypes.Find(competitionTypeId);
            }
        }

        public CompetitionType[] GetCompetitionTypes()
        {
            using (var db = new DatabaseContext())
            {
                return db.CompetitionTypes.Select(competitionType => (CompetitionType)competitionType).ToArray();
            }
        }

        public CompetitionType ModifyCompetitionType(CompetitionType newCompetition)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newCompetition).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (CompetitionType)db.CompetitionTypes.Find(newCompetition.CompetitionTypeId);
            }
        }
    }
}

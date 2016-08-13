using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Competition = RoboBears.DataContracts.Competition;

namespace RoboBears.DatabaseAccessors
{
    public class CompetitionAccessor : ICompetitionAccessor
    {
        public Competition CreateCompetition(Competition competition)
        {
            using (var db = new DatabaseContext())
            {
                Competition CreatedCompetition = (Competition)db.Competitions.Add((EntityFramework.Competition)competition);
                db.SaveChanges();
                return CreatedCompetition;
            }
        }

        public Competition GetCompetitionById(int competitionId)
        {
            using (var db = new DatabaseContext())
            {
                return (Competition)db.Competitions.Find(competitionId);
            }
        }

        public Competition[] GetCompetitions()
        {
            using (var db = new DatabaseContext())
            {
                return db.Competitions.Select(competition => (Competition)competition).ToArray();
            }
        }

        public Competition ModifyCompetition(Competition newCompetition)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newCompetition).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Competition)db.Competitions.Find(newCompetition.CompetitionID);
            }
        }
    }
}

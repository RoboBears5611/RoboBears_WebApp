using RoboBears.Contracts;
using System.Linq;
using MatchType = RoboBears.DataContracts.MatchType;
using RoboBears.DatabaseAccessors.EntityFramework;

namespace RoboBears.DatabaseAccessors
{
    public class MatchTypeAccessor : IMatchTypeAccessor
    {
        public MatchType CreateMatchType(MatchType matchType)
        {
            using (var db = new DatabaseContext())
            {
                var CreatedMatchType = db.MatchTypes.Add((EntityFramework.MatchType)matchType);
                db.SaveChanges();
                return (MatchType)CreatedMatchType;
            }
        }

        public MatchType GetMatchTypeById(int matchTypeId)
        {
            using (var db = new DatabaseContext())
            {
                return (MatchType)db.MatchTypes.Find(matchTypeId);
            }
        }

        public MatchType[] GetMatchTypes()
        {
            using (var db = new DatabaseContext())
            {
                return db.MatchTypes.Select(matchType => (MatchType)matchType).ToArray();
            }
        }

        public MatchType ModifyMatchType(MatchType newMatchType)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newMatchType).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (MatchType)db.MatchTypes.Find(newMatchType.MatchTypeId);
            }
        }
    }
}

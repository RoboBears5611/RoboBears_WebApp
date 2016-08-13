using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Match = RoboBears.DataContracts.Match;

namespace RoboBears.DatabaseAccessors
{
    public class MatchAccessor : IMatchAccessor
    {
        public Match CreateMatch(Match match)
        {
            using (var db = new DatabaseContext())
            {
                Match CreatedMatch = (Match)db.Matches.Add((EntityFramework.Match)match);
                db.SaveChanges();
                return CreatedMatch;
            }
        }

        public Match GetMatchById(int matchId)
        {
            using (var db = new DatabaseContext())
            {
                return (Match)db.Matches.Find(matchId);
            }
        }

        public Match[] GetMatches()
        {
            using (var db = new DatabaseContext())
            {
                return db.Matches.Select(match => (Match)match).ToArray();
            }
        }

        public Match ModifyMatch(Match newMatch)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newMatch).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Match)db.Matches.Find(newMatch.MatchId);
            }
        }
    }
}

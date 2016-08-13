using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Team = RoboBears.DataContracts.Team;

namespace RoboBears.DatabaseAccessors
{
    public class TeamAccessor : ITeamAccessor
    {
        public Team CreateTeam(Team team)
        {
            using (var db = new DatabaseContext())
            {
                Team CreatedTeam = (Team)db.Teams.Add((EntityFramework.Team)team);
                db.SaveChanges();
                return CreatedTeam;
            }
        }

        public Team GetTeamById(int teamId)
        {
            using (var db = new DatabaseContext())
            {
                return (Team)db.Teams.Find(teamId);
            }
        }

        public Team[] GetTeams()
        {
            using (var db = new DatabaseContext())
            {
                return db.Teams.Select(team => (Team)team).ToArray();
            }
        }

        public Team ModifyTeam(Team newTeam)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newTeam).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Team)db.Teams.Find(newTeam.TeamId);
            }
        }
    }
}

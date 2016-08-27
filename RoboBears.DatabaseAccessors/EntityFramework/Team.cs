using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Team
    {
        public Team()
        {
            Members = new HashSet<Member>();
            Strengths = new HashSet<StrengthQualityPair>();
            Competitions = new HashSet<Competition>();
            Blue1Matches = new HashSet<Match>();
            Blue2Matches = new HashSet<Match>();
            Red1Matches = new HashSet<Match>();
            Red2Matches = new HashSet<Match>();

        }
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public ICollection<Member> Members { get; set; }

        public Robot Robot { get; set; }

        public ICollection<StrengthQualityPair> Strengths { get; set; }

        public int? DescriptionId { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<Match> Blue1Matches { get; set; }
        public virtual ICollection<Match> Blue2Matches { get; set; }
        public virtual ICollection<Match> Red2Matches { get; set; }
        public virtual ICollection<Match> Red1Matches { get; set; }

        public static explicit operator DataContracts.Team(Team value)
        {
            return new DataContracts.Team()
            {
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                Members = value.Members.Select(member => (DataContracts.Member)member),
                Robot = (DataContracts.Robot)value.Robot,
                Strengths = value.Strengths.Select(sq => (DataContracts.StrengthQualityPair)sq),
                TeamName = value.TeamName,
                TeamId = value.TeamId
            };
        }

        public static explicit operator Team(DataContracts.Team value)
        {
            return new Team()
            {
                DescriptionId = value.Description.DescriptionId,
                Members = value.Members.Select(member => (Member)member).ToArray(),
                Robot = (Robot)value.Robot,
                Strengths = value.Strengths.Select(s => (StrengthQualityPair)s).ToArray(),
                TeamName = value.TeamName,
                TeamId = value.TeamId
            };
        }
    }
}

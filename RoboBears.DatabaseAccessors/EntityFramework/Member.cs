using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<Position> Positions { get; set; }

        public ICollection<Year> YearsInTeam { get; set; }

        public int Experience { get; set; }

        public int JoinYearId { get; set; }

        public int? DescriptionId { get; set; }

        public virtual Team Team { get; set; }
        public int TeamId { get; set; }

        public static explicit operator DataContracts.Member(Member value)
        {
            return new DataContracts.Member()
            {
                Age = value.Age,
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                Experience = value.Experience,
                FirstName = value.FirstName,
                LastName = value.LastName,
                JoinYearId = value.JoinYearId,
                MemberId = value.MemberId,
                YearIds = value.YearsInTeam.Select(Year => Year.YearId),
                Positions = value.Positions.Select(position => (DataContracts.Position)position),
                TeamId = value.TeamId
            };
        }

        public static explicit operator Member(DataContracts.Member value)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return new Member()
                {
                    Age = value.Age,
                    DescriptionId = value.Description.DescriptionId,
                    Experience = value.Experience,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    JoinYearId = value.JoinYearId,
                    MemberId = value.MemberId,
                    YearsInTeam = value.YearIds.Select(yearId => db.Years.Find(yearId)).ToArray(),
                    TeamId=value.TeamId,
                    Positions = value.Positions.Select(position => (Position)position).ToArray()
                };
            }

        }
    }
}
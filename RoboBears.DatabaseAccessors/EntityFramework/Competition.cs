using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Competition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetitionID { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int Lat { get; set; }

        public int Lng { get; set; }

        public DateTime? Date { get; set; }

        public CompetitionType CompetitionType { get; set; }

        public int CompetitionTypeId { get; set; }

        public ICollection<Match> Matches { get; set; }

        public int? DescriptionId { get; set; }

        public int YearId { get; set; }

        public virtual Year year { get; set; }

        public ICollection<Team> Teams { get; set; }

        public static explicit operator DataContracts.Competition(Competition value)
        {
            return new DataContracts.Competition()
            {
                CompetitionID = value.CompetitionID,
                CompetitionType = (DataContracts.CompetitionType)value.CompetitionType,
                Date = value.Date,
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                Lat = value.Lat,
                Lng = value.Lng,
                Location = value.Location,
                Matches = value.Matches.Select(match => (DataContracts.Match)match),
                Title = value.Title,
                YearId = value.YearId,
                Teams = value.Teams.Select(team => (DataContracts.Team)team)
            };
        }

        public static explicit operator Competition(DataContracts.Competition value)
        {
            return new Competition()
            {
                CompetitionID = value.CompetitionID,
                CompetitionType = (CompetitionType)value.CompetitionType,
                Date = value.Date,
                DescriptionId = value.Description.DescriptionId,
                Lat = value.Lat,
                Lng = value.Lng,
                Location = value.Location,
                Matches = value.Matches.Select(match => (Match)match).ToArray(),
                Title = value.Title,
                YearId = value.YearId,
                Teams = value.Teams.Select(team => (Team)team).ToArray()
            };
        }
    }
}

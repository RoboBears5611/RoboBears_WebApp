using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        public string Name { get; set; }

        public virtual Team BlueAllianceTeam1 { get; set; }
        public int BlueAllianceTeam1Id { get; set; }

        public virtual Team BlueAllianceTeam2 { get; set; }
        public int BlueAllianceTeam2Id { get; set; }

        public virtual Team RedAllianceTeam1 { get; set; }
        public int RedAllianceTeam1Id { get; set; }

        public virtual Team RedAllianceTeam2 { get; set; }
        public int RedAllianceTeam2Id { get; set; }

        public bool WinnerIsBlue { get; set; }

        public int DescriptionId { get; set; }

        public virtual Competition Competition { get; set; }

        public int CompetitionId { get; set; }

        public MatchType MatchType { get; set; }

        public int MatchTypeId { get; set; }

        public static explicit operator DataContracts.Match(Match value)
        {
            DataContracts.Match toReturn = new DataContracts.Match()
            {
                MatchId = value.MatchId,
                MatchType = (DataContracts.MatchType)value.MatchType,
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                Name = value.Name,
                WinnerIsBlue = value.WinnerIsBlue
            };
            toReturn.BlueAlliance = new DataContracts.Alliance
            {
                Team1 = (DataContracts.Team)value.BlueAllianceTeam1,
                Team2 = (DataContracts.Team)value.BlueAllianceTeam2
            };
            toReturn.RedAlliance = new DataContracts.Alliance
            {
                Team1 = (DataContracts.Team)value.RedAllianceTeam1,
                Team2 = (DataContracts.Team)value.RedAllianceTeam2
            };
            return toReturn;
        }

        public static explicit operator Match(DataContracts.Match value)
        {
            Match toReturn = new Match()
            {
                MatchId = value.MatchId,
                MatchType = (MatchType)value.MatchType,
                DescriptionId = value.Description.DescriptionId,
                Name = value.Name,
                WinnerIsBlue = value.WinnerIsBlue,
                BlueAllianceTeam1 = (Team)value.BlueAlliance.Team1,
                BlueAllianceTeam2 = (Team)value.BlueAlliance.Team2,
                RedAllianceTeam1 = (Team)value.RedAlliance.Team1,
                RedAllianceTeam2 = (Team)value.RedAlliance.Team2
            };
            return toReturn;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class Competition
    {
        public int CompetitionID { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int Lat { get; set; }

        public int Lng { get; set; }

        public DateTime? Date { get; set; }

        public CompetitionType CompetitionType { get; set; }

        public IEnumerable<Match> Matches { get; set; }

        public Description Description { get; set; }

        public int YearId { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}

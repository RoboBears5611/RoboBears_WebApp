using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class Match
    {
        public int MatchId { get; set; }

        public string Name { get; set; }

        public Alliance BlueAlliance { get; set; }

        public Alliance RedAlliance { get; set; }

        public bool WinnerIsBlue { get; set; }

        public Description Description { get; set; }

        public MatchType MatchType { get; set; }
    }
}

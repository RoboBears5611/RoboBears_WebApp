using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class Team
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public IEnumerable<Member> Members { get; set; }

        public Robot Robot { get; set; }

        public IEnumerable<StrengthQualityPair> Strengths { get; set; }

        public Description Description { get; set; }


    }
}

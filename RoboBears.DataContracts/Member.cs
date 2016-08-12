using System.Collections.Generic;

namespace RoboBears.DataContracts
{
    public class Member
    {
        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public IEnumerable<Position> Positions { get; set; }

        public IEnumerable<int> YearIds { get; set; }

        public int Experience { get; set; }

        public int JoinYearId { get; set; }

        public Description Description { get; set; }
        public int TeamId { get; set; }
    }
}
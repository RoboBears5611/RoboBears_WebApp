using System.Collections.Generic;

namespace RoboBears.DataContracts
{
    public class Mat
    {
        public int MatId { get; set; }

        public IEnumerable<Obstacle> Obstacles { get; set; }
        public Description Description { get; set; }

    }
}
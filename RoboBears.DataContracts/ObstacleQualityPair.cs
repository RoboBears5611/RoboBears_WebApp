using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class ObstacleQualityPair
    {
        public int ObstacleQualityPairId { get; set; }

        public virtual Obstacle Obstacle { get; set; }

        public int Quality { get; set; }
    }
}

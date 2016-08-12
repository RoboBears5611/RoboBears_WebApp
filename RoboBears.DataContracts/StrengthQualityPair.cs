using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class StrengthQualityPair
    {
        public int StrengthQualityPairId { get; set; }

        public Strength Strength { get; set; }

        public int Quality { get; set; }
    }
}

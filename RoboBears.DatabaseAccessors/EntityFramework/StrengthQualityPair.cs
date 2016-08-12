using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class StrengthQualityPair
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StrengthQualityPairId { get; set; }

        public Strength Strength { get; set; }

        public int Quality { get; set; }

        public static explicit operator DataContracts.StrengthQualityPair(StrengthQualityPair value)
        {
            return new DataContracts.StrengthQualityPair()
            {
                Quality = value.Quality,
                StrengthQualityPairId = value.StrengthQualityPairId,
                Strength = (DataContracts.Strength)value.Strength
            };
        }

        public static explicit operator StrengthQualityPair(DataContracts.StrengthQualityPair value)
        {
            return new StrengthQualityPair()
            {
                Quality = value.Quality,
                StrengthQualityPairId = value.StrengthQualityPairId,
                Strength = (Strength)value.Strength
            };
        }
    }
}

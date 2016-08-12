using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class MatchType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatchTypeId { get; set; }

        public string MatchTypeName { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        public static explicit operator DataContracts.MatchType(MatchType value)
        {
            return new DataContracts.MatchType()
            {
                MatchTypeId = value.MatchTypeId,
                MatchTypeName = value.MatchTypeName
            };
        }

        public static explicit operator MatchType(DataContracts.MatchType value)
        {
            return new MatchType()
            {
                MatchTypeId = value.MatchTypeId,
                MatchTypeName = value.MatchTypeName
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class CompetitionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetitionTypeId { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }

        public static explicit operator DataContracts.CompetitionType(CompetitionType value)
        {
            return new DataContracts.CompetitionType()
            {
                CompetitionTypeId = value.CompetitionTypeId,
                Title = value.Title,
                Level = value.Level
            };
        }

        public static explicit operator CompetitionType(DataContracts.CompetitionType value)
        {
            return new CompetitionType()
            {
                CompetitionTypeId = value.CompetitionTypeId,
                Title = value.Title,
                Level = value.Level
            };
        }
    }
}

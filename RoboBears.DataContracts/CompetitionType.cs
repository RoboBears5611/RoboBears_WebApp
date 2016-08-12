using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class CompetitionType
    {
        public int CompetitionTypeId { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Distance from Qualifiers. e.g. Qualifiers = 1, Regionals = 2, Super-Regionals = 3...
        /// </summary>
        public int Level { get; set; }
    }
}

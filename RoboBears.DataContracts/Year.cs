using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class Year
    {
        public int YearId { get; set; }

        public IEnumerable<Competition> Competitions { get; set; }

        public Game Game { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DataContracts
{
    public class Description
    {
        public int DescriptionId { get; set; }

        public string Summary { get; set; }

        public string FullDescription { get; set; }

        public IEnumerable<string> Notes { get; set; }
    }
}

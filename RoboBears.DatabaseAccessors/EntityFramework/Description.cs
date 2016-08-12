using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Description
    {
        public Description()
        {
            Notes = new HashSet<Note>();
        }

        public int DescriptionId { get; set; }

        public string Summary { get; set; }

        public string FullDescription { get; set; }

        public ICollection<Note> Notes { get; set; }

        public static explicit operator DataContracts.Description(Description value)
        {
            return new DataContracts.Description()
            {
                DescriptionId = value.DescriptionId,
                FullDescription = value.FullDescription,
                Summary = value.Summary,
                Notes = value.Notes.Select(note => note.Body)
            };
        }

        public static explicit operator Description(DataContracts.Description value)
        {
            return new Description()
            {
                DescriptionId = value.DescriptionId,
                FullDescription = value.FullDescription,
                Summary = value.Summary,
                Notes = value.Notes.Select(note => new Note() { DescriptionId = value.DescriptionId, Body = note }).ToArray()
            };
        }
    }
}

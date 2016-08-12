using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Mat
    {
        public int MatId { get; set; }

        public ICollection<Obstacle> Obstacles { get; set; }

        public int DescriptionId { get; set; }
        
        public virtual Game Game { get; set; }

        public static explicit operator DataContracts.Mat(Mat value)
        {
            return new DataContracts.Mat()
            {
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                MatId = value.MatId,
                Obstacles = value.Obstacles.Select(o => (DataContracts.Obstacle)o)
            };
        }

        public static explicit operator Mat(DataContracts.Mat value)
        {
            return new Mat()
            {
                DescriptionId = value.Description.DescriptionId,
                MatId = value.MatId,
                Obstacles = value.Obstacles.Select(o => (Obstacle)o).ToArray()
            };
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Obstacle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObstacleId { get; set; }

        public string Title { get; set; }

        public float Hieght { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public int DescriptionId { get; set; }

        public virtual Mat Mat { get; set; }
        public int MatId { get; set; }

        public static explicit operator DataContracts.Obstacle(Obstacle value)
        {
            return new DataContracts.Obstacle()
            {
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                Hieght = value.Hieght,
                Width = value.Width,
                Length = value.Width,
                Title = value.Title,
                ObstacleId = value.ObstacleId,
                MatId = value.MatId
            };
        }

        public static explicit operator Obstacle(DataContracts.Obstacle value)
        {
            return new Obstacle()
            {
                DescriptionId = value.Description.DescriptionId,
                Hieght = value.Hieght,
                Width = value.Width,
                Length = value.Length,
                MatId = value.MatId,
                ObstacleId = value.ObstacleId,
                Title = value.Title
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Robot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RobotId { get; set; }

        public string Name { get; set; }

        public float Hieght { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public int? DescriptionId { get; set; }

        public virtual Team Team { get; set; }

        public ICollection<ObstacleQualityPair> ObstacleStrengths { get; set; }

        public static explicit operator DataContracts.Robot(Robot value)
        {
            return new DataContracts.Robot()
            {
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                Hieght = value.Hieght,
                Width = value.Width,
                Length = value.Length,
                Name = value.Name,
                RobotId = value.RobotId,
                ObstacleStrengths = value.ObstacleStrengths.Select(os => (DataContracts.ObstacleQualityPair)os).ToArray()
            };
        }

        public static explicit operator Robot(DataContracts.Robot value)
        {
            return new Robot()
            {
                DescriptionId = value.Description.DescriptionId,
                Hieght = value.Hieght,
                Width = value.Width,
                Length = value.Length,
                Name = value.Name,
                RobotId = value.RobotId,
                ObstacleStrengths = value.ObstacleStrengths.Select(os => (ObstacleQualityPair)os).ToArray()
            };
        }
    }
}
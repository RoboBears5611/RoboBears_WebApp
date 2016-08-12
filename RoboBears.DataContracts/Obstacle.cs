using System.Collections.Generic;

namespace RoboBears.DataContracts
{
    public class Obstacle
    {
        public int ObstacleId { get; set; }

        public string Title { get; set; }

        public float Hieght { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public IEnumerable<ImageData> Pictures { get; set; }

        public Description Description { get; set; }
        public int MatId { get; set; }
    }
}
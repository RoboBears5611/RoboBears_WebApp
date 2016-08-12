using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace RoboBears.DataContracts
{
    public class Robot
    {
        public int RobotId { get; set; }

        public string Name { get; set; }

        public float Hieght { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public IEnumerable<ImageData> Pictures { get; set; }

        public IEnumerable<ObstacleQualityPair> ObstacleStrengths { get; set; }

        public Description Description { get; set; }

    }
}
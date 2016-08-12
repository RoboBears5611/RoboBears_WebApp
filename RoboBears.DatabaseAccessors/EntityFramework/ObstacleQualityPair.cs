namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class ObstacleQualityPair
    {
        public int ObstacleQualityPairId { get; set; }

        public virtual Obstacle Obstacle { get; set; }

        public int Quality { get; set; }

        public static explicit operator DataContracts.ObstacleQualityPair(ObstacleQualityPair value)
        {
            return new DataContracts.ObstacleQualityPair()
            {
                ObstacleQualityPairId = value.ObstacleQualityPairId,
                Quality = value.Quality,
                Obstacle = (DataContracts.Obstacle)value.Obstacle
            };
        }

        public static explicit operator ObstacleQualityPair(DataContracts.ObstacleQualityPair value)
        {
            return new ObstacleQualityPair()
            {
                ObstacleQualityPairId = value.ObstacleQualityPairId,
                Quality = value.Quality,
                Obstacle = (Obstacle)value.Obstacle
            };
        }
    }
}
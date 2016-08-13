using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class ObstacleManager : IObstacleManager
    {
        private IObstacleAccessor _obstacleAccessor;
        public IObstacleAccessor ObstacleAccessor
        {
            get
            {
                return _obstacleAccessor ?? ClassFactory.CreateClass<IObstacleAccessor>();
            }
            set
            {
                _obstacleAccessor = value;
            }
        }
        public Obstacle CreateObstacle(Obstacle obstacle)
        {
            return ObstacleAccessor.CreateObstacle(obstacle);
        }

        public Obstacle GetObstacleById(int obstacleId)
        {
            return ObstacleAccessor.GetObstacleById(obstacleId);
        }

        public Obstacle[]
        GetObstacles()
        {
            return ObstacleAccessor.GetObstacles();
        }

        public Obstacle ModifyObstacle(Obstacle newObstacle)
        {
            return ObstacleAccessor.ModifyObstacle(newObstacle);
        }
    }
}

using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IObstacleAccessor
    {
        Obstacle GetObstacleById(int obstacleId);

        Obstacle[] GetObstacles();

        Obstacle CreateObstacle(Obstacle obstacle);

        Obstacle ModifyObstacle(Obstacle newObstacle);

    }
}

using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IObstacleManager
    {
        Obstacle GetObstacleById(int obstacleId);

        Obstacle[] GetObstacles();

        Obstacle CreateObstacle(Obstacle obstacle);

        Obstacle ModifyObstacle(Obstacle newObstacle);

    }
}

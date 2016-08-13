using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Obstacle = RoboBears.DataContracts.Obstacle;

namespace RoboBears.DatabaseAccessors
{
    public class ObstacleAccessor : IObstacleAccessor
    {
        public Obstacle CreateObstacle(Obstacle obstacle)
        {
            using (var db = new DatabaseContext())
            {
                Obstacle CreateObstacle = (Obstacle)db.Obstacles.Add((EntityFramework.Obstacle)obstacle);
                db.SaveChanges();
                return CreateObstacle;
            }
        }

        public Obstacle GetObstacleById(int obstacleId)
        {
            using (var db = new DatabaseContext())
            {
                return (Obstacle)db.Obstacles.Find(obstacleId);
            }
        }

        public Obstacle[] GetObstacles()
        {
            using (var db = new DatabaseContext())
            {
                return db.Obstacles.Select(obstacle => (Obstacle)obstacle).ToArray();
            }
        }

        public Obstacle ModifyObstacle(Obstacle newObstacle)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newObstacle).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Obstacle)db.Obstacles.Find(newObstacle.ObstacleId);
            }
        }
    }
}

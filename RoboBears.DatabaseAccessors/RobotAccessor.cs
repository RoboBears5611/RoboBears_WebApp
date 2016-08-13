using RoboBears.Contracts;
using System.Linq;
using Robot = RoboBears.DataContracts.Robot;
using RoboBears.DatabaseAccessors.EntityFramework;

namespace RoboBears.DatabaseAccessors
{
    public class RobotAccessor : IRobotAccessor
    {
        public Robot CreateRobot(Robot robot)
        {
            using (var db = new DatabaseContext())
            {
                var CreatedRobot = db.Robots.Add((EntityFramework.Robot)robot);
                db.SaveChanges();
                return (Robot)CreatedRobot;
            }
        }

        public Robot GetRobotById(int robotId)
        {
            using (var db = new DatabaseContext())
            {
                return (Robot)db.Robots.Find(robotId);
            }
        }

        public Robot[] GetRobots()
        {
            using (var db = new DatabaseContext())
            {
                return db.Robots.Select(robot => (Robot)robot).ToArray();
            }
        }

        public Robot ModifyRobot(Robot newRobot)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newRobot).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Robot)db.Robots.Find(newRobot.RobotId);
            }
        }
    }
}

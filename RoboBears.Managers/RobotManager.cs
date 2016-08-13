using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class RobotManager : IRobotManager
    {
        private IRobotAccessor _robotAccessor;
        public IRobotAccessor RobotAccessor
        {
            get
            {
                return _robotAccessor ?? ClassFactory.CreateClass<IRobotAccessor>();
            }
set
            {
                _robotAccessor = value;
            }
        }
        public Robot CreateRobot(Robot robot)
        {
            return RobotAccessor.CreateRobot(robot);
        }

        public Robot GetRobotById(int robotId)
{
    return RobotAccessor.GetRobotById(robotId);
}

public Robot[]
GetRobots()
{
    return RobotAccessor.GetRobots();
}

public Robot ModifyRobot(Robot newRobot)
        {
            return RobotAccessor.ModifyRobot(newRobot);
        }
    }
}

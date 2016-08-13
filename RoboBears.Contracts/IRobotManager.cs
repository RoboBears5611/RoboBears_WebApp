using RoboBears.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.Contracts
{
    public interface IRobotManager
    {
        Robot GetRobotById(int robotId);

        Robot[] GetRobots();

        Robot CreateRobot(Robot robot);

        Robot ModifyRobot(Robot newRobot);

    }
}

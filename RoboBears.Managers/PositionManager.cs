using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class PositionManager : IPositionManager
    {
        private IPositionAccessor _positionAccessor;
        public IPositionAccessor PositionAccessor
        {
            get
            {
                return _positionAccessor ?? ClassFactory.CreateClass<IPositionAccessor>();
            }
            set
            {
                _positionAccessor = value;
            }
        }
        public Position CreatePosition(Position position)
        {
            return PositionAccessor.CreatePosition(position);
        }

        public Position GetPositionById(int positionId)
        {
            return PositionAccessor.GetPositionById(positionId);
        }

        public Position[]
        GetPositions()
        {
            return PositionAccessor.GetPositions();
        }

        public Position ModifyPosition(Position newPosition)
        {
            return PositionAccessor.ModifyPosition(newPosition);
        }
    }
}

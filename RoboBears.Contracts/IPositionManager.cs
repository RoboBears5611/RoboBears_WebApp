using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IPositionManager
    {
        Position GetPositionById(int positionId);

        Position[] GetPositions();

        Position CreatePosition(Position position);

        Position ModifyPosition(Position newPosition);
    }
}

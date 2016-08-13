using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Position = RoboBears.DataContracts.Position;

namespace RoboBears.DatabaseAccessors
{
    public class PositionAccessor : IPositionAccessor
    {
        public Position CreatePosition(Position position)
        {
            using(var db = new DatabaseContext())
            {
                Position CreatedPosition = (Position)db.Positions.Add((EntityFramework.Position)position);
                db.SaveChanges();
                return CreatedPosition;
            }
        }

        public Position GetPositionById(int positionId)
        {
            using (var db = new DatabaseContext())
            {
                return (Position)db.Positions.Find(positionId);
            }
        }

        public Position[] GetPositions()
        {
            using (var db = new DatabaseContext())
            {
                return db.Positions.Select(position => (Position)position).ToArray();
            }
        }

        public Position ModifyPosition(Position newPosition)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newPosition).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Position)db.Positions.Find(newPosition.PositionId);
            }
        }
    }
}

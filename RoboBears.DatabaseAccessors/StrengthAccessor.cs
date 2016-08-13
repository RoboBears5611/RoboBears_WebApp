using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Strength = RoboBears.DataContracts.Strength;

namespace RoboBears.DatabaseAccessors
{
    public class StrengthAccessor : IStrengthAccessor
    {
        public Strength CreateStrength(Strength strength)
        {
            using(var db = new DatabaseContext())
            {
                Strength CreatedStrength = (Strength)db.Strengths.Add((EntityFramework.Strength)strength);
                db.SaveChanges();
                return CreatedStrength;
            }
        }

        public Strength GetStrengthById(int strengthId)
        {
            using (var db = new DatabaseContext())
            {
                return (Strength)db.Strengths.Find(strengthId);
            }
        }

        public Strength[] GetStrengths()
        {
            using (var db = new DatabaseContext())
            {
                return db.Strengths.Select(strength => (Strength)strength).ToArray();
            }
        }

        public Strength ModifyStrength(Strength newStrength)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newStrength).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Strength)db.Strengths.Find(newStrength.StrengthId);
            }
        }
    }
}

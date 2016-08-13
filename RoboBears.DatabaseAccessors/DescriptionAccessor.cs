using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Description = RoboBears.DataContracts.Description;

namespace RoboBears.DatabaseAccessors
{
    public class DescriptionAccessor : IDescriptionAccessor
    {
        public Description CreateDescription(Description description)
        {
            using (var db = new DatabaseContext())
            {
                Description CreatedDescription = (Description)db.Descriptions.Add((EntityFramework.Description)description);
                db.SaveChanges();
                return CreatedDescription;
            }
        }

        public Description GetDescriptionById(int descriptionId)
        {
            using (var db = new DatabaseContext())
            {
                return (Description)db.Descriptions.Find(descriptionId);
            }
        }

        public Description[] GetDescriptions()
        {
            using (var db = new DatabaseContext())
            {
                return db.Descriptions.Select(description => (Description)description).ToArray();
            }
        }

        public Description ModifyDescription(Description newDescription)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newDescription).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Description)db.Descriptions.Find(newDescription.DescriptionId);
            }
        }
    }
}

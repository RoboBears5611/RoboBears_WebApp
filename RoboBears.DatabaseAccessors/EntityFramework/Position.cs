using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Position
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }

        public string Name { get; set; }

        public int? DescriptionId { get; set; }
        public virtual ICollection<Member> Members { get; set; }

        public static explicit operator DataContracts.Position(Position value)
        {
            return new DataContracts.Position()
            {
                PositionId = value.PositionId,
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                Name = value.Name
            };
        }

        public static explicit operator Position(DataContracts.Position value)
        {
            return new Position()
            {
                DescriptionId = value.Description.DescriptionId,
                Name = value.Name,
                PositionId = value.PositionId
            };
        }
    }
}
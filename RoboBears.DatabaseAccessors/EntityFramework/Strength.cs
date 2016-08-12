using System.ComponentModel.DataAnnotations.Schema;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Strength
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StrengthId { get; set; }

        public string Name { get; set; }

        public int DescriptionId { get; set; }

        public static explicit operator DataContracts.Strength(Strength value)
        {
            return new DataContracts.Strength()
            {
                StrengthId = value.StrengthId,
                Name = value.Name,
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId)
            };
        }

        public static explicit operator Strength(DataContracts.Strength value)
        {
            return new Strength()
            {
                StrengthId = value.StrengthId,
                Name = value.Name,
                DescriptionId = value.Description.DescriptionId
            };
        }
    }
}
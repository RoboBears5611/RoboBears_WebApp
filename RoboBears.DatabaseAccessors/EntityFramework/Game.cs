using System.ComponentModel.DataAnnotations.Schema;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Game
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public Mat Mat { get; set; }

        public int DescriptionId { get; set; }

        public virtual Year Year { get; set; }

        public int YearId { get; set; }

        public static explicit operator DataContracts.Game(Game value)
        {
            return new DataContracts.Game()
            {
                GameId = value.GameId,
                Title = value.Title,
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                YearId = value.YearId,
                Mat = (DataContracts.Mat)value.Mat
            };
        }

        public static explicit operator Game(DataContracts.Game value)
        {
            return new Game()
            {
                GameId = value.GameId,
                Title = value.Title,
                DescriptionId = value.Description.DescriptionId,
                YearId = value.YearId,
                Mat = (Mat)value.Mat
            };
        }
    }
}
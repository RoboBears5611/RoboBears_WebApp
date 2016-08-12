namespace RoboBears.DataContracts
{
    public class Game
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public Mat Mat { get; set; }

        public Description Description { get; set; }
        public int YearId { get; set; }
    }
}
using RoboBears.Contracts;
using RoboBears.DataContracts;
using RoboBears.Utilities;

namespace RoboBears.Managers
{

    public class GameManager : IGameManager
    {
        private IGameAccessor _gameAccessor;
        public IGameAccessor GameAccessor
        {
            get
            {
                return _gameAccessor ?? ClassFactory.CreateClass<IGameAccessor>();
            }
            set
            {
                _gameAccessor = value;
            }
        }
        public Game CreateGame(Game game)
        {
            return GameAccessor.CreateGame(game);
        }

        public Game GetGameById(int gameId)
        {
            return GameAccessor.GetGameById(gameId);
        }

        public Game[]
        GetGames()
        {
            return GameAccessor.GetGames();
        }

        public Game ModifyGame(Game newGame)
        {
            return GameAccessor.ModifyGame(newGame);
        }
    }
}

using RoboBears.DataContracts;

namespace RoboBears.Contracts
{
    public interface IGameAccessor
    {
        Game GetGameById(int gameId);

        Game[] GetGames();

        Game CreateGame(Game game);

        Game ModifyGame(Game newGame);
    }
}

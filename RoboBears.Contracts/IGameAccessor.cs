using RoboBears.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

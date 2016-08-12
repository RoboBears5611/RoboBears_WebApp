using RoboBears.Contracts;
using System.Linq;
using RoboBears.DatabaseAccessors.EntityFramework;
using Game = RoboBears.DataContracts.Game;

namespace RoboBears.DatabaseAccessors
{
    public class GameAccessor : IGameAccessor
    {
        public Game CreateGame(Game game)
        {
            using (var db = new DatabaseContext())
            {
                Game CreatedGame =  (Game)db.Games.Add((EntityFramework.Game)game);
                db.SaveChanges();
                return CreatedGame;
            }
        }

        public Game GetGameById(int gameId)
        {
            using (var db = new DatabaseContext())
            {
                return (Game)db.Games.Find(gameId);
            }
        }

        public Game[] GetGames()
        {
            using (var db = new DatabaseContext())
            {
                return db.Games.Select(game => (Game)game).ToArray();
            }
        }

        public Game ModifyGame(Game newGame)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(newGame).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (Game)db.Games.Find(newGame.GameId);
            }
        }
    }
}

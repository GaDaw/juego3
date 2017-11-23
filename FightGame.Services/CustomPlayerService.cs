using FightGame.Model;
using System.Collections.Generic;

namespace FightGame
{
    public class CustomPlayerService : IPlayerService
    {
        public List<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = ++GameModel.LastId,
                    Name = "Cat Woman",
                    Gender = Gender.Female,
                    Lives = GameModel.DefaultLives,
                    Power = GameModel.DefaultPower
                },
                new Player
                {
                    Id = ++GameModel.LastId,
                    Name = "Lobezno",
                    Gender = Gender.Male,
                    Lives = GameModel.DefaultLives,
                    Power = GameModel.DefaultPower
                },
                new Player
                {
                    Id = ++GameModel.LastId,
                    Name = "Wonder Woman",
                    Gender = Gender.Female,
                    Lives = GameModel.DefaultLives,
                    Power = GameModel.DefaultPower
                },
                new Player
                {
                    Id = ++GameModel.LastId,
                    Name = "Batman",
                    Gender = Gender.Male,
                    Lives = GameModel.DefaultLives,
                    Power = GameModel.DefaultPower
                },
            };
        }
    }
}

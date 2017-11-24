using FightGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightGame
{
    public class CustomPlayerService : IPlayerService
    {
        private static List<Player> _players = new List<Player>();

        public Player AddPlayer(Player player)
        {
            player.Id = _players.Max(x => x.Id) + 1;
            _players.Add(player);

            return player;
        }

        public Player GetPlayerById(int id)
        {
            return _players.First(x => x.Id == id);
        }

        public List<Player> GetPlayers()
        {
            if (!_players.Any())
            {
                _players = new List<Player>
                {
                    new Player
                    {
                        Id = 1,
                        Name = "Cat Woman",
                        Gender = Gender.Female,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                    new Player
                    {
                        Id = 2,
                        Name = "Lobezno",
                        Gender = Gender.Male,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                    new Player
                    {
                        Id = 3,
                        Name = "Wonder Woman",
                        Gender = Gender.Female,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                    new Player
                    {
                        Id = 4,
                        Name = "Batman",
                        Gender = Gender.Male,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                };
            }

            return _players;
        }

        public Player UpdatePlayer(Player player)
        {
            var match = _players.FirstOrDefault(x => x.Id == player.Id);

            if(match != null)
            {
                match.Lives = player.Lives;
                match.Power = player.Power;
                match.Name = player.Name;
                match.Gender = player.Gender;

                return match;
            }

            throw new Exception("Jugador no encontrado");
        }
    }
}

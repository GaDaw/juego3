using FightGame.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace FightGame
{
    public class StarwarsPlayerService : IPlayerService
    {
        private static List<Player> _players = new List<Player>();

        private const string ApiUrl = "https://swapi.co/api/people/";

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
            if(!_players.Any())
            {
                var httpClient = new HttpClient();
                var result = httpClient.GetStringAsync(ApiUrl).Result;
                StartWarsPeople people = JsonConvert.DeserializeObject<StartWarsPeople>(result);

                var lastId = 0;
                var players = people.Results.Select(person => new Player
                {
                    Id = ++lastId,
                    Name = person.PlayerName,
                    Gender = person.PlayerGender == "male" ? Gender.Male : Gender.Female,
                    Lives = GameModel.DefaultLives,
                    Power = GameModel.DefaultPower
                });

                _players = players.ToList();
            }

            return _players;
        }

        public Player UpdatePlayer(Player player)
        {
            var match = _players.FirstOrDefault(x => x.Id == player.Id);

            if (match != null)
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

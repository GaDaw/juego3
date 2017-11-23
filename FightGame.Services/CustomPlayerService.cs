using FightGame.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();
    }

    public class ApiPlayerService : IPlayerService
    {
        private const string ApiUrl = "https://swapi.co/api/people/";

        public List<Player> GetPlayers()
        {
            var httpClient = new HttpClient();
            Task<string> task = httpClient.GetStringAsync(ApiUrl);

            // forma 1 de recuperar valor
            //Task.Run(async() => {
            //    string result = await task;
            //});

            // forma 2 de recuperar valor
            string result = task.Result;
            StartWarsPeople people = JsonConvert.DeserializeObject<StartWarsPeople>(result);

            // Convertir List<Person> en nuestro List<Player>
            //var players = new List<Player>();
            //foreach(var person in people.results)
            //{
            //    players.Add(new Player
            //    {
            //        Id = ++Game.LastId,
            //        Name = person.name,
            //        Gender = person.gender == "male" ? Gender.Male : Gender.Female,
            //        Lives = Game.DefaultLives,
            //        Power = Game.DefaultPower
            //    });
            //}

            // 2: Convertir List<Person> en nuestro List<Player> con LINQ
            var players = people.results.Select(person => new Player
            {
                Id = ++GameModel.LastId,
                Name = person.PlayerName,
                Gender = person.PlayerGender == "male" ? Gender.Male : Gender.Female,
                Lives = GameModel.DefaultLives,
                Power = GameModel.DefaultPower
            });

            return players.ToList();
        }
    }

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

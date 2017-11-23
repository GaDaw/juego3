using FightGame.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FightGame
{
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

            // 1: Convertir List<Person> en nuestro List<Player> con un bucle
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
            var players = people.Results.Select(person => new Player
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
}

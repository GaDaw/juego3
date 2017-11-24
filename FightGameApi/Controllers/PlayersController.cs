using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FightGame;

namespace FightGameApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET api/players
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _playerService.GetPlayers();
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return _playerService.GetPlayerById(id);
        }

        // POST api/players
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/players/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

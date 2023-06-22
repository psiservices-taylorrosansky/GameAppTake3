using Microsoft.AspNetCore.Mvc;
using GamesCatalog.Models;
using Insight.Database;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GamesCatalog.ViewModels;
//using GamesCatalog.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;

        public GameController(IConfiguration configuration)
        {
            //Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbConnection = new SqlConnection(connectionString);
        }


        //GET: api/Game
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _dbConnection.Query<Game>("GetAllGames");
        }

        // GET api/Game/{id}
        [HttpGet("{id}")]
        public IEnumerable<Game> Get(int id)
        {
            return _dbConnection.Query<Game>("GetGameById", new { Id = id });
        }

        // POST api/Game
        // Correct DateTime entry example: "releaseDate": "2023-06-21T19:43:48.958Z"
        [HttpPost]
        public void Post([FromBody] AddGame request)
        {
            if(String.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Name field must be filled");
            }
            if (String.IsNullOrEmpty(request.Developer))
            {
                throw new ArgumentException("Developer field must be filled");
            }
            var game = new Game
            {
                Name = request.Name,
                ReleaseDate = request.ReleaseDate,
                Developer = request.Developer
            };
            _dbConnection.Execute("AddGame", game);
        }

        // PUT api/Game/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AddGame request)
        {
            var updatedGame = new Game
            {
                Id = id,
                Name = request.Name,
                ReleaseDate = request.ReleaseDate,
                Developer = request.Developer
            };
            _dbConnection.Execute("UpdateGame", updatedGame);
            //Console.WriteLine(w.GetType());
        }

        // DELETE api/Game/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dbConnection.Execute("DeleteGame", new { Id = id });
        }
    }
}


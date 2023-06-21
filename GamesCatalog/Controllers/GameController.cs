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
            var game = new Game
            {
                Name = request.Name,
                ReleaseDate = request.ReleaseDate,
                Developer = request.Developer
            };
            _dbConnection.Execute("AddGame", game);
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

////GET: api/<GameController>
//[HttpGet]
//public IEnumerable<Game> Get()
//{
//    var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameInsightDB;Integrated Security=True");
//    return connection.Query<Game>("GetAllGames");
//}

// GET: api/<GameController>
//[HttpGet]
//public IEnumerable<Game> Get(int pageIndex = 1, int pageSize = 10) 
//{
//    var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameInsightDB;Integrated Security=True");
//    var parameters = new { PageIndex = pageIndex - 1, PageSize = pageSize };
//    return connection.Query<Game>("GetAllGames", parameters);
//}
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Numerics;
using VLCAIAPI.Models;

namespace VLCAIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {

        string _connectionString = "Server=192.168.0.158,9999;Database=VLCAI;user=reader;Password=reader;TrustServerCertificate=true";
        SqlConnection _connection;

        public ShopController()
        {
            _connection = new SqlConnection(_connectionString);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public List<Commerce> Get()
        {
            _connection.Open();

            // Définir la requête

            string queryString = "SELECT * FROM Commerces";

            // Exécuter la requête

            SqlCommand command = new(queryString, _connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Commerce> listeCommerces = new List<Commerce>();
            while (reader.Read())
            {

                Commerce commerce = new Commerce();
                commerce.X = (decimal)reader[0];
                commerce.Y = (decimal)reader[1];
                commerce.osm_id = (long)reader[2];
                commerce.type = (string)reader[3];
                commerce.name = (string)reader[4];
                commerce.wheelchair = (string)reader[5];
                commerce.opening_hours = (string)reader[6];
                commerce.website = (string)reader[7];
                commerce.phone = (string)reader[8];
                commerce.email = (string)reader[9];
                commerce.address = (string)reader[10];
                commerce.code_insee = (string)reader[11];
                listeCommerces.Add(commerce);
            }

            reader.Close();
            _connection.Close();

            return listeCommerces;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

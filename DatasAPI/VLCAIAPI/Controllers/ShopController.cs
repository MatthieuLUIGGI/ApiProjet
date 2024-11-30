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

        string _connectionString = "Server=.,9595;Database=VLCAI;user=sa;Password=Password123456789;TrustServerCertificate=true";
        //"Server=192.168.30.7,5432;Database=mydatabase;user=myuser;Password=myuser;Encrypt=True;TrustServerCertificate=true";
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

                commerce.X = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0); // Par défaut, 0 si NULL
                commerce.Y = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                commerce.osm_id = reader.IsDBNull(2) ? 0 : reader.GetInt64(2);
                commerce.type = reader.IsDBNull(3) ? "Non renseigné" : reader.GetString(3);
                commerce.name = reader.IsDBNull(4) ? "Non renseigné" : reader.GetString(4);
                commerce.wheelchair = reader.IsDBNull(5) ? "Non renseigné" : reader.GetString(5);
                commerce.opening_hours = reader.IsDBNull(6) ? "Non renseigné" : reader.GetString(6);
                commerce.website = reader.IsDBNull(7) ? "Non renseigné" : reader.GetString(7);
                commerce.phone = reader.IsDBNull(8) ? "Non renseigné" : reader.GetString(8);
                commerce.email = reader.IsDBNull(9) ? "Non renseigné" : reader.GetString(9);
                commerce.address = reader.IsDBNull(10) ? "Non renseigné" : reader.GetString(10);
                commerce.code_insee = reader.IsDBNull(11) ? "Non renseigné" : reader.GetString(11);

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

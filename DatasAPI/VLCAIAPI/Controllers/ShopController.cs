using Azure;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
using Npgsql;
using System.Numerics;
using VLCAIAPI.Models;

namespace VLCAIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {

        //string _connectionString = "Server=.,9595;Database=VLCAI;user=sa;Password=Password123456789;TrustServerCertificate=true";
        string _connectionString = "Host=192.168.30.7;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword;SslMode=Prefer;TrustServerCertificate=true";
        NpgsqlConnection _connection;

        public ShopController()
        {
            _connection = new NpgsqlConnection(_connectionString);
        }

        //GET: api/<ValuesController>
        [HttpGet]
        public List<Commerces> Get()
        {
            _connection.Open();

            // Définir la requête
            string queryString = "SELECT * FROM Commerces";

            // Exécuter la requête
            NpgsqlCommand command = new(queryString, _connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            List<Commerces> listeCommerces = new List<Commerces>();
            while (reader.Read())
            {
                Commerces commerce = new Commerces();

                commerce.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                commerce.X = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                commerce.Y = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                commerce.osm_id = reader.IsDBNull(3) ? 0 : reader.GetInt64(3);
                commerce.type = reader.IsDBNull(4) ? "Non renseigné" : reader.GetString(4);
                commerce.name = reader.IsDBNull(5) ? "Non renseigné" : reader.GetString(5);
                commerce.wheelchair = reader.IsDBNull(6) ? "Non renseigné" : reader.GetString(6);
                commerce.opening_hours = reader.IsDBNull(7) ? "Non renseigné" : reader.GetString(7);
                commerce.website = reader.IsDBNull(8) ? "Non renseigné" : reader.GetString(8);
                commerce.phone = reader.IsDBNull(9) ? "Non renseigné" : reader.GetString(9);
                commerce.email = reader.IsDBNull(10) ? "Non renseigné" : reader.GetString(10);
                commerce.address = reader.IsDBNull(11) ? "Non renseigné" : reader.GetString(11);
                commerce.code_insee = reader.IsDBNull(12) ? "Non renseigné" : reader.GetString(12);

                listeCommerces.Add(commerce);
            }

            reader.Close();
            _connection.Close();

            return listeCommerces;
        }

        // GET api/<ValuesController>/5
        [HttpGet("search")]
        public List<Commerces> Get(string name)
        {
            _connection.Open();

            // Définir la requête
            string queryString = "SELECT * FROM Commerces WHERE name LIKE '%" + name + "%'";

            // Exécuter la requête
            NpgsqlCommand command = new(queryString, _connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            List<Commerces> listeCommerces = new List<Commerces>();
            while (reader.Read())
            {
                Commerces commerce = new Commerces();

                commerce.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                commerce.X = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                commerce.Y = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                commerce.osm_id = reader.IsDBNull(3) ? 0 : reader.GetInt64(3);
                commerce.type = reader.IsDBNull(4) ? "Non renseigné" : reader.GetString(4);
                commerce.name = reader.IsDBNull(5) ? "Non renseigné" : reader.GetString(5);
                commerce.wheelchair = reader.IsDBNull(6) ? "Non renseigné" : reader.GetString(6);
                commerce.opening_hours = reader.IsDBNull(7) ? "Non renseigné" : reader.GetString(7);
                commerce.website = reader.IsDBNull(8) ? "Non renseigné" : reader.GetString(8);
                commerce.phone = reader.IsDBNull(9) ? "Non renseigné" : reader.GetString(9);
                commerce.email = reader.IsDBNull(10) ? "Non renseigné" : reader.GetString(10);
                commerce.address = reader.IsDBNull(11) ? "Non renseigné" : reader.GetString(11);
                commerce.code_insee = reader.IsDBNull(12) ? "Non renseigné" : reader.GetString(12);

                listeCommerces.Add(commerce);
            }

            reader.Close();
            _connection.Close();

            return listeCommerces;
        }

        // POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(BigInteger id, decimal x, decimal y)
        {
            _connection.Open();

            string queryString = "UPDATE Commerces SET x = @x, y = @y WHERE osm_id = @id";

            using (NpgsqlCommand command = new(queryString, _connection))
                {
                command.Parameters.AddWithValue("@x", x);
                command.Parameters.AddWithValue("@y", y);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                _connection.Close();
            }
        }


        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

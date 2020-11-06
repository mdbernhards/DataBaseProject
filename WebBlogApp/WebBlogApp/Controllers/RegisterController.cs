using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace WebBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private DBConnect connection;

        public RegisterController(DBConnect _connection)
        {
            connection = _connection;
        }

        [HttpPost]
        public void Register(string name, string surname, string password, string email, string phoneNr)
        {
            if (name != default && surname != default && password != default && email != default && phoneNr != default)
            {
                try
                {
                    string queryString = "INSERT INTO User (name, surname, password, email, phoneNr) VALUES (@name, @surname, @password, @email, @phoneNr";

                    SqlCommand command = new SqlCommand(queryString, connection.Connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phoneNr", phoneNr);

                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Clear();
                }
                catch(Exception ex)
                {
                    Content(ex.Message);
                    connection.Connection.Close();
                    //fail
                }
            }
            else
            {
               //registration Failed
            }
        }

        [HttpGet]
        public bool CheckIfUserExists()
        {
            return true;
        }
    }
}
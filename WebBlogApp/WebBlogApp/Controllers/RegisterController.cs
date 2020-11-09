using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebBlogApp.Interface;

namespace WebBlogApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IDBConnect connection;

        public RegisterController(IDBConnect _connection)
        {
            connection = _connection;
        }

        [HttpPost]
        public void Register(string name, string surname, string password, string email, string phoneNr)
        {
            if (CheckIfUserExists(name, surname, password, email, phoneNr))
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
        public bool CheckIfUserExists(string name, string surname, string password, string email, string phoneNr)
        {
            return true;
        }
    }
}
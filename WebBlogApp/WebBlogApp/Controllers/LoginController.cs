using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebBlogApp.Models;

namespace WebBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private DBConnect connection;

        public LoginController(DBConnect _connection)
        {
            connection = _connection;
        }

        [HttpGet]
        public User Login(User user)
        {
            string queryString = "SELECT * FROM dbo.Users Where Username = @username AND password = @password";

            SqlCommand command = new SqlCommand(queryString, connection.Connection);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);

            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if(reader.HasRows)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
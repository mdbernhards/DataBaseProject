﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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
        public void Login(string email, string password)
        {
            string queryString = "SELECT * FROM dbo.Users Where email = @email AND password = @password";

            SqlCommand command = new SqlCommand(queryString, connection.Connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if(reader.HasRows)
                {
                    //logged in
                }
                else
                {
                    //username or password invalid
                }

            }
            catch 
            {
                
            }
        }
    }
}
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebBlogApp.Interface;
using WebBlogApp.Models;

namespace WebBlogApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDBConnect connection;

        public LoginController(IDBConnect _connection)
        {
            connection = _connection;
        }

        public User Login(string username, string password)
        {
            
            string queryString = "SELECT * FROM [User] Where Username = @Username AND Password = @Password";

            SqlCommand command = new SqlCommand(queryString, connection.Connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    User user = new User(reader.GetInt32(reader.GetOrdinal("ID")), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());

                    reader.Close();
                    return user;
                }
                else
                {
                    reader.Close();
                    return new User(69, "69", "69", "69", "69", "69", "69");
                }
            }
            catch (SqlException e)
            {
                return new User(69, "69", "69", "69", "69", "69", "69");
            }
        }
    }
}
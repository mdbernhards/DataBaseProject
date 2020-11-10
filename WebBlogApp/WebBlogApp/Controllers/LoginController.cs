using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebBlogApp.Interface;
using WebBlogApp.Models;

namespace WebBlogApp.Controllers
{
    /// <summary>
    /// Class for all the methods that control the login proccess
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDBConnect connection;

        /// <summary>
        /// Class for all the methods that control the login proccess, injects the database
        /// </summary>
        public LoginController(IDBConnect _connection)
        {
            connection = _connection;
        }

        /// <summary>
        /// Checks if a user with the given username and password exists, returns the user if it does and null if doesn't
        /// </summary>
        public User Login(string username, string password)
        {
            string queryString = "SELECT * FROM [User] Where Username = @Username AND Password = @Password";

            try
            {
                SqlCommand command = new SqlCommand(queryString, connection.Connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

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
                    return null;
                }
            }
            catch (SqlException e)
            {
                Content(e.Message);
                return null;
            }
        }
    }
}
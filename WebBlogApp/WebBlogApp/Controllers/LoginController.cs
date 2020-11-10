using Microsoft.AspNetCore.Mvc;
using WebBlogApp.DatabaseQueries;
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
        private readonly LoginQueries loginQueries;

        /// <summary>
        /// Class for all the methods that control the login proccess, injects the database
        /// </summary>
        public LoginController(IDBConnect _connection)
        {
            loginQueries = new LoginQueries(_connection);
        }

        /// <summary>
        /// Checks if a user with the given username and password exists, returns the user if it does and null if doesn't
        /// </summary>
        public User Login(string username, string password)
        {
            return loginQueries.LoginQuery(username, password);
        }
    }
}
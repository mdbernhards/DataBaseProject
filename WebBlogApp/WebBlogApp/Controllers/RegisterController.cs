using Microsoft.AspNetCore.Mvc;
using WebBlogApp.DatabaseQueries;
using WebBlogApp.Interface;

namespace WebBlogApp.Controllers
{
    /// <summary>
    /// Class for all the methods that control the registering proccess
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterQueries registerQueries;

        /// <summary>
        /// Class for all the methods that control the registering proccess, injects the database
        /// </summary>
        public RegisterController(IDBConnect _connection)
        {
            registerQueries = new RegisterQueries(_connection);
        }

        /// <summary>
        /// Method that calls a method that checks if user exists already, if it doesn't tries to create it
        /// </summary>
        [HttpPost]
        public void Register(string name, string surname, string email, string phoneNr, string username, string password)
        {
            if (username != null && name != null && surname != null && password != null && email != null && phoneNr != null)
            {
                if (CheckIfUsernameExists(username))
                {
                    registerQueries.RegisterQuery(name, surname, email, phoneNr, username, password);
                }
            }
        }

        /// <summary>
        /// Checks if user with a given username already exists returns true if it does
        /// </summary>
        [HttpGet]
        private bool CheckIfUsernameExists(string username)
        {
            return registerQueries.GetUsertQuery(username);
        }
    }
}
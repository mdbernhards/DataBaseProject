using WebBlogApp.Interface;

namespace WebBlogApp.DatabaseQueries
{
    /// <summary>
    /// Class that executes database queries for the Register Controller
    /// </summary>
    public class RegisterQueries
    {
        private readonly IDBConnect connection;

        /// <summary>
        /// Class that executes database queries for the Login Controller, injects the database
        /// </summary>
        public RegisterQueries(IDBConnect _connection)
        {
            connection = _connection;
        }
        public void RegisterQuery()
        {

        }

        public void GetUsertQuery()
        {

        }
    }
}
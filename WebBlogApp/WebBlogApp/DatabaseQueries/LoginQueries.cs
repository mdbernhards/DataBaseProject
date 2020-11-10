using WebBlogApp.Interface;

namespace WebBlogApp.DatabaseQueries
{
    /// <summary>
    /// Class that executes database queries for the Login Controller
    /// </summary>
    public class LoginQueries
    {
        private readonly IDBConnect connection;

        /// <summary>
        /// Class that executes database queries for the Login Controller, injects the database
        /// </summary>
        public LoginQueries(IDBConnect _connection)
        {
            connection = _connection;
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoginQuery()
        {

        }
    }
}
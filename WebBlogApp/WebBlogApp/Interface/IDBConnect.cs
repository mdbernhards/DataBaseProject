using System.Data.SqlClient;

namespace WebBlogApp.Interface
{
    /// <summary>
    /// Class for creating a connection to the database
    /// </summary>
    public interface IDBConnect
    {
        /// <summary>
        /// Object that can be used to execute actions with the database
        /// </summary>
        public SqlConnection Connection { get; set; }
    }
}
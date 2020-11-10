using System;
using System.Data.SqlClient;
using WebBlogApp.Interface;

namespace WebBlogApp
{
    /// <summary>
    /// Class for creating a connection to the database
    /// </summary>
    public class DBConnect : IDBConnect
    {
        /// <summary>
        /// Object that can be used to execute actions with the database
        /// </summary>
        public SqlConnection Connection { get; set; }

        private readonly string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BlogDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Constructor for class that creates a connection with the database
        /// </summary>
        public DBConnect()
        {
            try
            {
                Connection = new SqlConnection(connectionString);
                Connection.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
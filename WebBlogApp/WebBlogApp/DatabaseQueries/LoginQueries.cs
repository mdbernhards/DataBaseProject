using System;
using System.Data.SqlClient;
using WebBlogApp.Interface;
using WebBlogApp.Models;

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
        /// Method that executes a query that checks if the given user information exists, if it does returns a user
        /// </summary>
        public User LoginQuery(string username, string password)
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
            catch (SqlException ex)
            {
                return null;
            }

        }
    }
}
using System;
using System.Data.SqlClient;
using WebBlogApp.Interface;

namespace WebBlogApp.DatabaseQueries
{
    /// <summary>
    /// Class that executes database queries for the Blog Post Controller
    /// </summary>
    public class BlogPostQueries
    {
        private readonly IDBConnect connection;

        /// <summary>
        /// Class that executes database queries for the Blog Post Controller, injects the database
        /// </summary>
        public BlogPostQueries(IDBConnect _connection)
        {
            connection = _connection;
        }

        /// <summary>
        /// Method that executes a query that Creates a post in the database
        /// </summary>
        public void PostQuery(string postText, string userID)
        {
            string queryString = "INSERT INTO Post (UserID, PostText, CreationDate) VALUES (@UserID, @PostText, @CreationDate";

            try
            {
                SqlCommand command = new SqlCommand(queryString, connection.Connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@PostText", postText);
                command.Parameters.AddWithValue("@CreationDate", "55/55/2077");
                SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
            }
            catch
            {
                connection.Connection.Close();
            }
        }

        /// <summary>
        /// Method that executes a query that Deletes a post from the table
        /// </summary>
        public void DeleteQuery(string postID)
        {
            try
            {
                string queryString = "Drop FROM table Post ...";

                SqlCommand command = new SqlCommand(queryString, connection.Connection);
                SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
            }
            catch
            {
                connection.Connection.Close();
            }
        }

        /// <summary>
        /// Method that executes a query that Gets all posts a user has made
        /// </summary>
        public void GetPostsQuery()
        {

        }

        /// <summary>
        /// Method that executes a query that Gets a select post if it exists returns true
        /// </summary>
        public bool CheckIfPostExistsQuery(string postText, string userID)
        {
            try
            {
                string queryString = "Select * FROM Post where PostText=@PostText AND UserID=@UserID";

                SqlCommand command = new SqlCommand(queryString, connection.Connection);
                command.Parameters.AddWithValue("@PostText", postText);
                command.Parameters.AddWithValue("@UserID", userID);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                connection.Connection.Close();
                return false;
            }
        }

        /// <summary>
        /// Method that executes a query that Repleces text in a select Tables Post row
        /// </summary>
        public void EditPostQuery()
        {

        }
    }
}
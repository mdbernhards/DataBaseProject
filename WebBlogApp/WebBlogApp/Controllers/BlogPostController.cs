using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebBlogApp.Interface;

namespace WebBlogApp.Controllers
{
    /// <summary>
    /// Class for all the methods that control the Blogging proccess
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IDBConnect connection;
        
        /// <summary>
        /// Class for all the methods that control the Blogging proccess, injects the database
        /// </summary>
        public BlogPostController(IDBConnect _connection)
        {
            connection = _connection;
        }

        /// <summary>
        /// Creates a post in database if it doesn't exist already
        /// </summary>
        [HttpPost]
        public void Post(string postText, string userID)
        {
            if (postText != default && userID != default && CheckIfPostExists(postText, userID))
            {
                try
                {
                    string queryString = "INSERT INTO Post (UserID, PostText, CreationDate) VALUES (@UserID, @PostText, @CreationDate";

                    SqlCommand command = new SqlCommand(queryString, connection.Connection);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@PostText", postText);
                    command.Parameters.AddWithValue("@CreationDate", "55/55/2077");
                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Content(ex.Message);
                    connection.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Deletes the post by it's ID if it exists
        /// </summary>
        [HttpDelete]
        public void DeletePost(string postID)
        {
            if (postID != default)
            {
                try
                {
                    string queryString = "";

                    SqlCommand command = new SqlCommand(queryString, connection.Connection);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Content(ex.Message);
                    connection.Connection.Close();
                    //Post Failed
                }
            }
            else
            {
                //fail
            }
        }

        /// <summary>
        /// Gets all posts of the user with the given ID
        /// </summary>
        [HttpGet]
        public void GetPosts(string userID)
        {
        }

        /// <summary>
        /// Checks if a post exists, returns true if it does
        /// </summary>
        [HttpGet]
        public bool CheckIfPostExists(string postText, string userID)
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
            catch (SqlException e)
            {
                Content(e.Message);
                connection.Connection.Close();
                return false;
            }
        }

        /// <summary>
        /// Edits post by replacing an existing posts text
        /// </summary>
        public void EditPost(string userID)
        {

        }
    }
}
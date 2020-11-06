using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace WebBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private DBConnect connection;

        public BlogPostController(DBConnect _connection)
        {
            connection = _connection;
        }

        [HttpPost]
        public void Post(string postText, string userID)
        {
            if (postText != default && userID != default)
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
                    //Post Failed
                }
            }
            else
            {
                //Post Failed
            }
        }

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
    }
}
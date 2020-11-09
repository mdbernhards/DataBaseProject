using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebBlogApp.Interface;

namespace WebBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IDBConnect connection;

        public BlogPostController(IDBConnect _connection)
        {
            connection = _connection;
        }

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

        [HttpGet]
        public void GetPosts(string UserID)
        {

        }

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

        public void EditPost(string UserID)
        {

        }
    }
}
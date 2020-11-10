using Microsoft.AspNetCore.Mvc;
using WebBlogApp.DatabaseQueries;
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
        private readonly BlogPostQueries blogPostQueries;

        /// <summary>
        /// Class for all the methods that control the Blogging proccess, injects the database
        /// </summary>
        public BlogPostController(IDBConnect _connection)
        {
            blogPostQueries = new BlogPostQueries(_connection);
        }

        /// <summary>
        /// Creates a post in database if it doesn't exist already
        /// </summary>
        [HttpPost]
        public void Post(string postText, string userID)
        {
            if (postText != default && userID != default && !CheckIfPostExists(postText, userID))
            {
                blogPostQueries.PostQuery(postText, userID);
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
                blogPostQueries.DeleteQuery(postID);
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
            return blogPostQueries.CheckIfPostExistsQuery(postText, userID);
        }

        /// <summary>
        /// Edits post by replacing an existing posts text
        /// </summary>
        public void EditPost(string userID)
        {

        }
    }
}
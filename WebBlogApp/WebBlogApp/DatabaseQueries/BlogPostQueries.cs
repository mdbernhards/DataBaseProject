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
        /// 
        /// </summary>
        public void PostQuery()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteQuery()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void GetPostsQuery()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void GetPostQuery()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void EditPostQuery()
        {

        }
    }
}
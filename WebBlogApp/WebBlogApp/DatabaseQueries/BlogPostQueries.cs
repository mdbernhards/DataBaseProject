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

        public void PostQuery()
        {

        }

        public void DeleteQuery()
        {

        }

        public void GetPostsQuery()
        {

        }

        public void GetPostQuery()
        {

        }

        public void EditPostQuery()
        {

        }
    }
}
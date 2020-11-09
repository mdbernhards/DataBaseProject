using System.Data.SqlClient;

namespace WebBlogApp.Interface
{
    public interface IDBConnect
    {
        public SqlConnection Connection { get; set; }
    }
}
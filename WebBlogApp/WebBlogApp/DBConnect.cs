using System.Data.SqlClient;
using WebBlogApp.Interface;

namespace WebBlogApp
{
    public class DBConnect : IDBConnect
    {
        private readonly string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BlogDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlConnection Connection { get; set; }
        public DBConnect()
        {
            try
            {
                Connection = new SqlConnection(connectionString);
                Connection.Open();
            }
            catch{ }
        }
    }
}
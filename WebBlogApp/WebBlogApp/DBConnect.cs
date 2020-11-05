using System;
using System.Data.SqlClient;

namespace WebBlogApp
{
    public class DBConnect
    {
        private string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BlogDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlConnection Connection;
        public DBConnect()
        {

            try
            {
                Console.Write("Connecting to SQL Server ... ");
                using (Connection = new SqlConnection(connectionString))
                {
                    Connection.Open();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey(true);
        }
    }
}
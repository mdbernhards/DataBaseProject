using System;
using System.Data.SqlClient;

namespace WebBlogApp
{
    public class DBConnect
    {
        public void ConnectToDB()
        {
            try
            {
                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();
                    Console.WriteLine("Done.");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);
        }
    }
}
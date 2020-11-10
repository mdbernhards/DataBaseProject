using System.Data.SqlClient;
using WebBlogApp.Interface;

namespace WebBlogApp.DatabaseQueries
{
    /// <summary>
    /// Class that executes database queries for the Register Controller
    /// </summary>
    public class RegisterQueries
    {
        private readonly IDBConnect connection;

        /// <summary>
        /// Class that executes database queries for the Login Controller, injects the database
        /// </summary>
        public RegisterQueries(IDBConnect _connection)
        {
            connection = _connection;
        }

        /// <summary>
        /// Method that executes a query that creates a user in the database
        /// </summary>
        public void RegisterQuery(string name, string surname, string email, string phoneNr, string username, string password)
        {
            string queryString = "INSERT INTO User (Name, Surname, Email, Phone, Username, Password) VALUES (@Name, @Surname, @Email, @Phone, @Username, @Password";

            try
            {
                SqlCommand command = new SqlCommand(queryString, connection.Connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phoneNr);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
            }
            catch
            {
                connection.Connection.Close();
            }
        }

        /// <summary>
        /// Method that executes a query that checks if user with given username exists, if he does returns true
        /// </summary>
        public bool GetUsertQuery(string username)
        {
            string queryString = "Select * FROM User where Username=@username";

            try
            {
                SqlCommand command = new SqlCommand(queryString, connection.Connection);
                command.Parameters.AddWithValue("@Username", username);

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
            catch
            {
                connection.Connection.Close();
                return false;
            }
        }
    }
}
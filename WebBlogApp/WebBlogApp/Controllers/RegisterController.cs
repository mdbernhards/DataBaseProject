using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebBlogApp.Interface;

namespace WebBlogApp.Controllers
{
    /// <summary>
    /// Class for all the methods that control the registering proccess
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IDBConnect connection;

        /// <summary>
        /// Class for all the methods that control the registering proccess, injects the database
        /// </summary>
        public RegisterController(IDBConnect _connection)
        {
            connection = _connection;
        }

        /// <summary>
        /// Method that calls a method that checks if user exists already, if it doesn't tries to create it
        /// </summary>
        [HttpPost]
        public void Register(string name, string surname, string email, string phoneNr, string username, string password)
        {
            if (username != null && name != null && surname != null && password != null && email != null && phoneNr != null)
            {
                if (CheckIfUsernameExists(username))
                {
                    try
                    {
                        string queryString = "INSERT INTO User (Name, Surname, Email, Phone, Username, Password) VALUES (@Name, @Surname, @Email, @Phone, @Username, @Password";

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
                    catch (Exception ex)
                    {
                        Content(ex.Message);
                        connection.Connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Checks if user with a given username already exists returns true if it does
        /// </summary>
        [HttpGet]
        private bool CheckIfUsernameExists(string username)
        {
            try
            {
                string queryString = "Select * FROM User where Username=@username";

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
            catch (SqlException e)
            {
                Content(e.Message);
                connection.Connection.Close();
                return false;
            }
        }
    }
}
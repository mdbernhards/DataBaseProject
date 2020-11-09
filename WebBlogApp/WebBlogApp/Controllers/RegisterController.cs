using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebBlogApp.Interface;
using WebBlogApp.Models;

namespace WebBlogApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IDBConnect connection;

        public RegisterController(IDBConnect _connection)
        {
            connection = _connection;
        }

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
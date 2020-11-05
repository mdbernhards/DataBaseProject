using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public void Login(string email, string password)
        {
            DBConnect connection = new DBConnect();
            string queryString = "SELECT * FROM dbo.Users Where email = @email AND password = @password";

            SqlCommand command = new SqlCommand(queryString, connection.Connection);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if(reader.HasRows)
                {
                    //logged in
                }
                else
                {
                    //username or password invalid
                }

            }
        }
    }
}
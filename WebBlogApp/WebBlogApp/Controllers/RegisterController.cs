using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        public void Register(string name, string surname, string password, string email, string phoneNr)
        {
            if (name != default && surname != default && password != default && email != default && phoneNr != default)
            {

            }
            else
            {
               //registration Failed
            }
        }

        public bool CheckIfUserExists()
        {
            return true;
        }
    }
}

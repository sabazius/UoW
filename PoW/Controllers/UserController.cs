using Microsoft.AspNetCore.Mvc;
using PoW.Models.Users;

namespace PoW.Controllers.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        public UserController()
        {

        }

        [HttpGet]
        public User GetUser()
        {
            return new User()
            {

                Id = 1,
                FacultylID = 123,
                Name = "Boris",
                Email = "boris@pow.com",
                TeamID = 12
            };
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using UoW.Models.Users;

namespace UoW.Controllers.Controllers
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
                Email = "boris@UoW.com",
                TeamID = 12
            };
        }

    }
}

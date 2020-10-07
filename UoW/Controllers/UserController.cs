using Microsoft.AspNetCore.Mvc;
using UoW.Models.User;

namespace TroubleT.Controllers
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
                PersonalNumber = 1,
                Name = "Boris",
                TeamId = 12
            };
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using UoW.Models.User;

namespace TroubleT.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        [HttpGet]
        public Users GetUser()
        {
            return new Users()
            {
                Id = 7,
                Name = "Alex",
                TeamId = 13,
                FacultyID=1702811024,
                Email="alexlomski@abv.bg"
            };
        }

    }
}

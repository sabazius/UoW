using Microsoft.AspNetCore.Mvc;
using System;
using UoW.Models.Tasks;
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
        public Story GetUser()
        {
            return new Story()
                { 
            ID = 154,
            Description = "description",
            Name = "Ivan",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(5),
            ProjectID = 12
        };
        }

    }
}

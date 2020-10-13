using Microsoft.AspNetCore.Mvc;
using System;
using UoW.Models.Task;
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
        public UserTask GetUser()
        {
            return new UserTask()
            {
                Name = "Boris",
                ID = 12,
                Describtion = "IKI",
                OwnerID = 10,
                AssignedToUserID = 15,
                DateAndTime = DateTime.Now.AddSeconds(10),
                EndTime = DateTime.Now.AddDays(5),
                StoryID = 14,
                TimeSpend = DateTime.Now.AddDays(12),
                TaskType = 18

            };
        }

    }
}

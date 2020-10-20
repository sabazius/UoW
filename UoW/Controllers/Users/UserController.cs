using Microsoft.AspNetCore.Mvc;
using System;
using UoW.BL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.Controllers.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        IUserService UserService;
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
          
    
    }
}


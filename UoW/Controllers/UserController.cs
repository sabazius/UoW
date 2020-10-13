﻿using Microsoft.AspNetCore.Mvc;
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
        public Lectors GetUser()
        {
            return new Lectors()
            {
                ID = 43,
                FirstName = "Dimitri",
                LastName = "Sovnyov",
                DateAndTime = new System.DateTime()

            };
        }

    }
}

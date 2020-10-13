using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UoW.Models.Tasks;

namespace UoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorsController : ControllerBase
    {
        public LectorsController()
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

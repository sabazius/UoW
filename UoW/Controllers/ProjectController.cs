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
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public Project GetProject()
        {
            return new Project()
            {
                Description = "hello",
                ID = 5,
                Name = "Stoyan",
                ProductOwnerID = 3,
            

            };
        }
    }
}

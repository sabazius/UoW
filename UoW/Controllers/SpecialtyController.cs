using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UoW.Models.User;

namespace UoW.Controllers
{
    [Route("specialty")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        public SpecialtyController()
        {

        }

        [HttpGet]
        public Specialty GetSpecialty()
        {
            return new Specialty()
            {
                FacultyID = 1,
                ID = 12,
                LectorID = 123,
                Name = "vasil",
                ShortName = "vas"
            };
        }
    }
}

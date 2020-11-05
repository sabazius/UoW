using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Services.Users;
using UoW.Models.Users;

namespace UoW.Controllers.Users
{
    [Route("lector")]
    [ApiController]
    public class LectorsController : ControllerBase
    {
        public LectorService _lectorController;
        public IMapper _mapper;
        public LectorsController(LectorService lectorController, IMapper mapper)
        {
            _lectorController = lectorController;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLectorById(int lectorid)
        {
            var result = _lectorController.GetLectorId(lectorid);
            if (result == null) return NotFound();

            var lector = _mapper.Map<Lector>(result);

            return Ok(lector);

        }

    }
}

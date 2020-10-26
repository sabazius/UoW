using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UoW.BL.Interfaces.Tasks;
using UoW.Models.Tasks;

namespace UoW.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        ISprintService _sprintService;
        public SprintController(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        [HttpGet]
        public Sprint GetSprintById(int sprintId)
        {
            return _sprintService.GetSprintById(sprintId);
        }

        [HttpPost]
        public Sprint GetSprint(int sprintId, int teamId)
        {
            return _sprintService.GetSprint(sprintId, teamId);
        }

    }

}

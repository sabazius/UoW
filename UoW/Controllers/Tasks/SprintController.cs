using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UoW.BL.Interfaces.Tasks;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Tasks;

namespace UoW.Controllers.Tasks
{
    [Route("[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private ISprintService _sprintService;
        private IMapper _mapper;

        public SprintController(ISprintService sprintService, IMapper mapper)
        {
            _sprintService = sprintService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSprintById(int sprintId)
        {
            var result = _sprintService.GetSprintById(sprintId);

            if (result == null)
                return NotFound();

            var response = _mapper.Map<SprintResponse>(result);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateSprint([FromBody] SprintRequest request)
        {
            if (request == null)
                return BadRequest();

            var sprint = _mapper.Map<Sprint>(request); 

            var result = _sprintService.Create(sprint);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteSprint(int sprintId)
        {
            if (sprintId <= 0)
                return BadRequest();

            var sprint = _sprintService.GetSprintById(sprintId);

            if (sprint == null)
            {
                return NotFound();
            }

            _sprintService.Delete(sprintId);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSprint([FromBody] SprintRequest request)
        {
            if (request == null)
                return BadRequest();

            var sprint = _mapper.Map<Sprint>(request);

            var result = _sprintService.Update(sprint);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}

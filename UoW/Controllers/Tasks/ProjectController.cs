using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Tasks;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Tasks;

namespace UoW.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectService _projectService;
        private IMapper _mapper;
        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            var result = await _projectService.GetById(projectId);
            if (result == null) return NotFound("Project not found");

            var project = _mapper.Map<Project>(result);

            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _projectService.GetAll();

            if (result == null) return NotFound("Collection is empty!");

            var response = _mapper.Map<IEnumerable<ProjectResponse>>(result);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectRequest request)
        {
            if (request == null) return NotFound();

            var project = _mapper.Map<Project>(request);

            var result = _projectService.Create(project);

            if (result == null) return NotFound();

            return Ok(project);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (id <= 0) return BadRequest();

            var project = await _projectService.GetById(id);
            if (project == null) return NotFound();

            await _projectService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject([FromBody] Project request)
        {
            if (request == null) return NotFound();

            var project = _mapper.Map<Project>(request);

            var result = await _projectService.Update(project);
            if (result == null) return NotFound("not found");

            return Ok(_mapper.Map<ProjectResponse>(result));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using UoW.BL.Interfaces.Tasks;
using UoW.Models.Tasks;

namespace UoW.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public Project GetProjectById(int projectId)
        {
            return _projectService.GetProjectById(projectId);
        }
    }
}

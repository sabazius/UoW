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
    public class ProjectController : ControllerBase
    {
        IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public Project GetProjectById(int projectId)
        {
            return _projectService.GetProjectById(projectId);
        }
    }
}

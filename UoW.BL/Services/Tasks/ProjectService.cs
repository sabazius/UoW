using System;
using System.Collections.Generic;
using System.Text;
using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.DL.Repositories;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
    public class ProjectService : IProjectService
    {
        IProjectRepository _projectRepository;
        public ProjectService(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

      
        Project IProjectService.GetProjectById(int id)
        {
            return _projectRepository.GetById(id);
        }
    }
}

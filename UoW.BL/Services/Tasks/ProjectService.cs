using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
    public class ProjectService : IProjectService
    {
        IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        Project IProjectService.GetProjectById(int id)
        {
            return _projectRepository.GetById(id);
        }
    }
}

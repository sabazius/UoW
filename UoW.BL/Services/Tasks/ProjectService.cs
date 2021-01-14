using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
    public class ProjectService : IProjectService
    {
        IProjectRepository _projectRepository;
        ITeamRepository _teamRepository;
        IUserRepository _userRepository;
        public ProjectService(IProjectRepository projectRepository, ITeamRepository teamRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _userRepository = userRepository;
        }

        public async Task<Project> Create(Project project)
        {
            return await _projectRepository.Create(project);
        }

        public async Task Delete(int projectId)
        {
            await _projectRepository.Delete(projectId);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projectRepository.GetAll();
        }


        public async Task<Project> GetById(int projectId)
        {
            return await _projectRepository.GetById(projectId);
        }

        public async Task<Project> Update(Project project)
        {
            return await _projectRepository.Update(project);
        }

        public async Task<Project> UpdateProject(int projectId, int ownerId, int teamId, string description)
        {
            var project = await _projectRepository.GetById(projectId);
            var validOwmerId = await _userRepository.GetById(ownerId) != null;
            var validTeamId = _teamRepository.GetById(teamId) != null;

            if (project == null) return null;

            if (validOwmerId) project.OwnerId = ownerId;

            if (validTeamId) project.TeamId = teamId;

            if (description != null) project.Description = description;

            var result = await _projectRepository.Update(project);

            return result;
        }
    }
}

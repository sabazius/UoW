using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public interface IProjectService
    {
        Task<Project> Create(Project project);
        Task Delete(int projectId);
        Task<Project> Update(Project project);
        Task<Project> GetById(int projectId);
        Task<Project> UpdateProject(int projectId, int ownerId, int teamId, string description);
        Task<IEnumerable<Project>> GetAll();
    }
}

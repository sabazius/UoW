using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
    public interface IProjectRepository
    {
        Task<Project> Create(Project project);
        Task Delete(int projectId);
        Task<Project> Update(Project project);
        Task<Project> GetById(int projectId);
        Task<Project> GetByName(string name);
        Task<IEnumerable<Project>> GetAll();
    }
}

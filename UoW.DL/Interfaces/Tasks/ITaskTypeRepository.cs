using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
    public interface ITaskTypeRepository
    {
    	Task<TaskType> Create(TaskType user);
        Task Delete(int userId);
        Task<TaskType> Update(TaskType user);
        Task<TaskType> GetById(int userId);
        Task<IEnumerable<TaskType>> GetAll();
    }
}

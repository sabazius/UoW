using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public  interface ITaskTypeService
    {
        Task<TaskType> GetTaskTypeById(int id);
        Task<TaskType> Create(TaskType taskType);
        void Delete(int taskTypeId);
        Task<TaskType> Update(TaskType taskType);
        Task<IEnumerable<TaskType>> GetAll();
        Task<TaskType> UpdateDescription(string description,int taskTypeId);
    }
}

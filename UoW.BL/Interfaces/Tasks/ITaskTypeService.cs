using System.Collections.Generic;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public  interface ITaskTypeService
    {
        TaskType GetTaskTypeById(int id);
        TaskType Create(TaskType taskType);
        void Delete(int taskTypeId);
        TaskType Update(TaskType taskType);
        IEnumerable<TaskType> GetAll();
        TaskType UpdateDescription(int description);
    }
}

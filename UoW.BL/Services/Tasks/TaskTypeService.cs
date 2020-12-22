using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
    public class TaskTypeService : ITaskTypeService
    {
        private readonly ITaskTypeRepository _taskTypeRepository;

        public TaskTypeService(ITaskTypeRepository taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<TaskType> Create(TaskType taskType)
        {
            return await _taskTypeRepository.Create(taskType);
        }

        public void Delete(int taskTypeId)
        {
            _taskTypeRepository.Delete(taskTypeId);
        }

        public async Task<IEnumerable<TaskType>> GetAll()
        {
            return await _taskTypeRepository.GetAll();
        }

        public async Task<TaskType> GetTaskTypeById(int id)
        {
            return await _taskTypeRepository.GetById(id);
        }

        public async Task<TaskType> Update(TaskType taskType)
        {
            return await _taskTypeRepository.Update(taskType);
        }

        public async Task<TaskType> UpdateDescription(string description, int taskTypeId)
        {
            var taskType = await _taskTypeRepository.GetById(taskTypeId);

            if (taskType == null)
                return null;

            taskType.Description = description;

            var result = await _taskTypeRepository.Update(taskType);

            return result;
        }
    }
}

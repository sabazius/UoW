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

        public TaskType UpdateDescription(int description, int lectorId)
        {
            var description = _taskTypeRepository.GetById(lectorId);

            if (description == null)
                return null;

            var faculty = await _facultyRepository.GetById(description);

            if (faculty == null)
                return null;

            description.FacultyId = facultyId;

            var result = await _lectorRepository.Update(lector);

            return result;
        }
    }
}

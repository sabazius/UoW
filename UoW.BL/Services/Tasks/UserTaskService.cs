using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
    public class UserTaskService : IUserTaskService
    {
        IUserTaskRepository _userTaskRepository;
        ITaskTypeRepository _taskTypeRepository;
        IUserRepository _userRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository, ITaskTypeRepository taskTypeRepository, IUserRepository userRepository)
        {
            _userTaskRepository = userTaskRepository;
            _taskTypeRepository = taskTypeRepository;
            _userRepository = userRepository;
        }

        public async Task<UserTask> Create(UserTask userTask)
        {
            return await _userTaskRepository.Create(userTask);
        }

        public async Task Delete(int userTaskId)
        {
            await _userTaskRepository.Delete(userTaskId);
        }
        public async Task<UserTask> GetById(int userTaskId)
        {
            return await _userTaskRepository.GetById(userTaskId);
        }

        public async Task<UserTask> Update(UserTask userTask)
        {
            return await _userTaskRepository.Update(userTask);
        }

        public async Task<UserTask> UpdateUserTask(int userTaskId, int assignedToUserId, DateTime startDate, DateTime EndDate, int taskType, string description, string name, TimeSpan timeSpend)
        {
            var userTask = await _userTaskRepository.GetById(userTaskId);
            var taskTypeIsValid = await _taskTypeRepository.GetById(taskType) != null;
            var validUser = await _userRepository.GetById(assignedToUserId) != null;

            if (userTask == null)
            {
                return null;
            }

            if(validUser)
            {
                userTask.AssignedToUserID = assignedToUserId;
            }

            if(taskTypeIsValid)
            {
                userTask.TaskType = taskType;
            }

            if (name != userTask.Name)
            {
                var validName = await _userTaskRepository.GetByName(name) == null;

                if (!validName)
                {
                    return null;
                }
                userTask.Name = name;
            }


            userTask.StartDate = startDate;
            userTask.EndDate = EndDate;
            userTask.Description = description;
            userTask.TimeSpend = timeSpend;

            var result = await _userTaskRepository.Update(userTask);

            return result;
        }
    }
}

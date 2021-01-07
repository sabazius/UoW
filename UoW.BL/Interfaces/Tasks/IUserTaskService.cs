using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UoW.Models.Contracts.Requests;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public interface IUserTaskService
    {
        Task<UserTask> Create(UserTask userTask);
        Task Delete(int userTaskId);
        Task<UserTask> Update(UserTask userTask);
        Task<UserTask> GetById(int userTaskId);
        Task<UserTask> UpdateUserTask(UpdateTaskRequest updateTaskRequest);
		Task<IEnumerable<UserTask>> GetAll();
	}
}

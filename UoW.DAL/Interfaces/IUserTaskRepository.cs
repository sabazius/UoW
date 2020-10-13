using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Task;

namespace UoW.DAL.Interfaces
{
    public interface IUserTaskRepository
    {
        void InsertUserTask(UserTask userTask);
        void UpdateUserTask(UserTask userTask);
        void DeleteUserTask(int id );
        List<UserTask> GetAllUserTasks();
    }
}

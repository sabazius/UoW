using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models;
using UoW.Models.Tasks;

namespace UoW.DAL.Interfaces
{
    public interface IUserTaskRepository
    {
        void InsertUserTask(TaskTypes userTask);
        void UpdateUserTask(TaskTypes userTask);
        void DeleteUserTask(int id);
        List<TaskTypes> GetAllUserTasks();               
    }
}

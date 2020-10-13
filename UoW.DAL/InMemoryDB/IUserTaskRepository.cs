using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models;
using UoW.Models.Tasks;

namespace UoW.DAL.Interfaces
{
   public interface IUserTaskRepository
    {
        void InsertUserTask(Story userTask);
        void UpdateUserTask(Story userTask);
        void DeleteUserTask(int id);
        List<Story> GetAllUserTasks();
    }
}

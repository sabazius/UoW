using System.Collections.Generic;
using UoW.Models.Tasks;

namespace UoW.DAL.Interfaces
{
    public interface IUserTaskRepository
    {
        void InsertUserTask(Project userTask);
        void UpdateUserTask(Project userTask);
        void DeleteUserTask(int id);
        List<Project> GetAllUserTasks();
    }
}


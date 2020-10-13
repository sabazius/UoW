using System;
using System.Collections.Generic;
using System.Text;
using UoW.DAL.InMemoryDB;
using UoW.DAL.Interfaces;
using UoW.Models.Task;

namespace UoW.DAL.Tasks
{
    public class UserTaskRepository : IUserTaskRepository
    {
        public void DeleteUserTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserTask> GetAllUserTasks()
        {
            return InMemoryDB.InMemoryDB.userTasks;
        }

        public void InsertUserTask(UserTask userTask)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserTask(UserTask userTask)
        {
            throw new NotImplementedException();
        }
    }
}

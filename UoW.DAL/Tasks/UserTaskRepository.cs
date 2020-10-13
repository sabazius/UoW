using System;
using System.Collections.Generic;
using System.Text;
using UoW.DAL.InMemoryDB;
using UoW.DAL.Interfaces;
using UoW.Models;
using UoW.Models.Tasks;

namespace UoW.DAL.Tasks
{
    public class UserTaskRepository : IUserTaskRepository
    {
        public void DeleteUserTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskTypes> GetAllUserTasks()
        {
            return InMemoryDB.InMemoryDB.TaskTypess;
        }

        public void InsertUserTask(TaskTypes userTask)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserTask(TaskTypes userTask)
        {
            throw new NotImplementedException();
        }
    }
}

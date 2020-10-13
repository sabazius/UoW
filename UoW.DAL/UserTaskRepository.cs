using System;
using System.Collections.Generic;
using System.Text;
using UoW.DAL.Interfaces;
using UoW.Models;
using UoW.Models.Tasks;

namespace UoW.DAL
{
    public class UserTaskRepository : IUserTaskRepository

    {
        public void DeleteUserTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<Story> GetAllUserTasks()
        {
            return InMemoryDB.InMemoryDB.Stories;
        }

        public void InsertUserTask(Story userTask)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserTask(Story userTask)
        {
            throw new NotImplementedException();
        }
    }
}

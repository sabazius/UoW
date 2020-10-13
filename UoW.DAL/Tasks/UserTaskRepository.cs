using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using UoW.DAL.Interfaces;
using UoW.Models.Tasks;

namespace UoW.DAL.Tasks
{
    public class UserTaskRepository : IUserTaskRepository
    {
        public void InsertUserTask(Project userTask)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserTask(Project userTask)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllUserTasks()
        {
            return InMemoryDB.InMemoryDB.Projects;

        }

    }
}

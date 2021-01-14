﻿using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace UoW.DL.Repositories.Tasks
{
    public class UserTaskRepository 
    {
        private static List<UserTask> dbTable;

        public UserTaskRepository()
        {
            dbTable = InMemoryDb.UserTasks;
        }

        public void Create(UserTask userTask)
        {
            dbTable.Add(userTask);
        }

        public void Delete(int userTaskId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userTaskId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public UserTask GetById(int userTaskId)
        {
            return dbTable.FirstOrDefault(x => x.Id == userTaskId);
        }

        public void Update(UserTask userTask)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userTask.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(userTask);
            }
        }
    }
}

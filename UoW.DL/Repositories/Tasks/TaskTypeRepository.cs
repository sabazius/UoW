using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace UoW.DL.Repositories.Tasks
{
    public class TaskTypeRepository 
    {
        private static List<TaskType> dbTable;

        public TaskTypeRepository()
        {
            dbTable = InMemoryDb.TaskTypes;
        }

        public void Create(TaskType story)
        {
            dbTable.Add(story);
        }

        public void Delete(int taskTypeId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == taskTypeId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public TaskType GetById(int taskTypeId)
        {
            return dbTable.FirstOrDefault(x => x.Id == taskTypeId);
        }

        public void Update(TaskType taskType)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == taskType.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(taskType);
            }
        }
    }
}

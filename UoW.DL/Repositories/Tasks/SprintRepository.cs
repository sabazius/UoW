using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace UoW.DL.Repositories.Tasks
{
    public class SprintRepository : ISprintRepository
    {
        private static List<Sprint> dbTable;

        public SprintRepository()
        {
            dbTable = InMemoryDb.Sprints;
        }

        public void Create(Sprint sprint)
        {
            dbTable.Add(sprint);
        }

        public void Delete(int sprintId)
        {
            var sprint = dbTable.FirstOrDefault(x => x.Id == sprintId);
            if (sprint != null)
            {
                dbTable.Remove(sprint);
            }
        }

        public IEnumerable<Sprint> GetAll() =>
            dbTable.AsEnumerable();

		public Sprint GetById(int sprintId)
        {
            return dbTable.FirstOrDefault(x => x.Id == sprintId);
        }

        public void Update(Sprint sprint)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == sprint.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(sprint);
            }
        }
    }
}

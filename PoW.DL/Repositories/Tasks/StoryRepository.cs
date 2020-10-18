using PoW.DL.InMemoryDB;
using PoW.DL.Interfaces.Users;
using PoW.Models.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace PoW.DL.Repositories.Tasks
{
    public class StoryRepository : IStoryRepository
    {
        private static List<Story> dbTable;

        public StoryRepository()
        {
            dbTable = InMemoryDb.Stories;
        }

        public void Create(Story story)
        {
            dbTable.Add(story);
        }

        public void Delete(int storyId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == storyId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public Story GetById(int sprintId)
        {
            return dbTable.FirstOrDefault(x => x.Id == sprintId);
        }

        public void Update(Story Story)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == Story.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(Story);
            }
        }
    }
}

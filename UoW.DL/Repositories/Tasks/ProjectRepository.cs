using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace UoW.DL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private static List<Project> dbTable;

        public ProjectRepository()
        {
            dbTable = InMemoryDb.Projects;
        }

        public void Create(Project user)
        {
            dbTable.Add(user);
        }

        public void Delete(int userId)
        {
            var project = dbTable.FirstOrDefault(x => x.Id == userId);
            if (project != null) {
                dbTable.Remove(project);
            }
        }

        public Project GetById(int projectId)
        {
            return dbTable.FirstOrDefault(x => x.Id == projectId);
        }

        public void Update(Project project)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == project.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(project);
            }
        }
    }
}

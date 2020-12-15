using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.DL.Repositories.Users
{
    public class FacultyRepository : IFacultyRepository
    {
        private static List<Faculty> dbTable;

        public FacultyRepository()
        {
            dbTable = InMemoryDb.Faculties;
        }

        public Task<Faculty> Create(Faculty faculty)
        {
            dbTable.Add(faculty);

            return Task.FromResult(faculty);
        }

        public Task Delete(int facultyId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == facultyId);
            if (result != null)
            {
                dbTable.Remove(result);
            }

            return Task.CompletedTask;
        }

        public Task<Faculty> GetById(int facultyId)
        {
            return Task.FromResult(dbTable.FirstOrDefault(x => x.Id == facultyId));
        }

        public Task<Faculty> Update(Faculty faculty)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == faculty.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(faculty);
            }

            return Task.FromResult(faculty);
        }
    }
}

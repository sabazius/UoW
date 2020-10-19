using System.Collections.Generic;
using System.Linq;
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

        public void Create(Faculty faculty)
        {
            dbTable.Add(faculty);
        }

        public void Delete(int facultyId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == facultyId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public Faculty GetById(int facultyId)
        {
            return dbTable.FirstOrDefault(x => x.Id == facultyId);
        }

        public void Update(Faculty faculty)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == faculty.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(faculty);
            }
        }
    }
}

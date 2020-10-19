using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace UoW.DL.Repositories.Users
{
    public class LectorRepository : ILectorRepository
    {
        private static List<Lector> dbTable;

        public LectorRepository()
        {
            dbTable = InMemoryDb.Lectors;
        }

        public void Create(Lector lector)
        {
            dbTable.Add(lector);
        }

        public void Delete(int lectorId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == lectorId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public Lector GetById(int lectorId)
        {
            return dbTable.FirstOrDefault(x => x.Id == lectorId);
        }

        public void Update(Lector lector)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == lector.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(lector);
            }
        }
    }
}

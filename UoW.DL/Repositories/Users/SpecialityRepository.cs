using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UoW.DL.Repositories.Users
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private static List<Speciality> dbTable;

        public SpecialityRepository()
        {
            dbTable = InMemoryDb.Specialties;
        }

        public void Create(Speciality speciality)
        {
            dbTable.Add(speciality);
        }

        public void Delete(int specialityId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == specialityId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public Speciality GetById(int specialityId)
        {
            return dbTable.FirstOrDefault(x => x.Id == specialityId);
        }

        public void Update(Speciality speciality)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == speciality.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(speciality);
            }
        }

        public List<Speciality> GetAll()
        {
            return dbTable;
        }
    }
}

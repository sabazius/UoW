using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace UoW.DL.Repositories.Users
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private static List<Specialty> dbTable;

        public SpecialityRepository()
        {
            dbTable = InMemoryDb.Specialties;
        }

        public Task<Specialty> Create(Specialty speciality)
        {
            dbTable.Add(speciality);
            return Task.FromResult(speciality);
        }

        public Task Delete(int specialityId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == specialityId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
            return Task.CompletedTask;
        }

        public Task<Specialty> GetById(int specialityId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == specialityId);
            return Task.FromResult(result);
        }

        public Task<Specialty> GetByName(string name)
        {
            return Task.FromResult(dbTable.FirstOrDefault(x => x.Name == name));
        }

        public Task<Specialty> Update(Specialty speciality)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == speciality.Id);

            if (result != null)
            {
                Delete(speciality.Id);
                Create(speciality);
               
            }
            return Task.FromResult(speciality);
        }

        public Task<IEnumerable<Specialty>> GetAll()
        {
            return Task.FromResult(dbTable.AsEnumerable());
        }
    }
}

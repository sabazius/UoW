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

        public Speciality Create(Speciality speciality)
        {
            dbTable.Add(speciality);
            return speciality;
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

        public Speciality GetByName(string name)
        {
            return dbTable.FirstOrDefault(x => x.Name == name);
        }

        public Speciality Update(Speciality speciality)
        {
            //get specialtyById and store it in temp variable then delete it and check if lectorId and facultyId exist and if name is not taken
            //if some of these verification fails delete the specialty and create it with the old data from temp variable
            var result = dbTable.FirstOrDefault(x => x.Id == speciality.Id);

            if (result != null)
            {
                Delete(speciality.Id);
                Create(speciality);
               
            }
            return speciality;
        }

        public List<Speciality> GetAll()
        {
            return dbTable;
        }
    }
}

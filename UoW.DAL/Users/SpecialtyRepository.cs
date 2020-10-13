using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UoW.DAL.InMemoryDb;
using UoW.Models.User;

namespace UoW.DAL.Users
{
    class SpecialtyRepository : ISpecialtyRepository
    {
        public void DeleteSpecialty(int id)
        {
            throw new NotImplementedException();
        }

        public List<Specialty> GetAllSpecialties()
        {
            //InMemoryDb.InMemoryDb.Init();
            return InMemoryDb.InMemoryDb.Specialties;
        }

        public void InsertSpecialty(Specialty specialty)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpecialty(Specialty specialty)
        {
            throw new NotImplementedException();
        }
    }
}

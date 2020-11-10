using System;
using System.Collections.Generic;
using System.Text;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;
using UoW.Models.Common;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace UoW.DL.Repositories.MongoDb.Users
{
    public class SpecialtyMongoRepository : ISpecialityRepository
    {
        private readonly IMongoCollection<Speciality> _specialties;
        public SpecialtyMongoRepository()
        {
            var client = new MongoClient("mongodb+srv://admin:tpaqMq6k0G9bpVWz@pu-net-core.52gte.mongodb.net/UoW?retryWrites=true&w=majority");
            var database = client.GetDatabase("UoW");
            _specialties = database.GetCollection<Speciality>("Specialty");
        }
        public Speciality Create(Speciality user)
        {
            _specialties.InsertOne(user);
            return user;
        }

        public void Delete(int userId)
        {
            _specialties.DeleteOne(p => p.Id == userId);
        }

        public List<Speciality> GetAll()
        {   var result = _specialties.Find(p => true).ToList();
            return result;
        }

        public Speciality GetById(int userId)
        {
            return _specialties.Find(p => p.Id == userId).FirstOrDefault();
        }

        public Speciality GetByName(string name)
        {
            return _specialties.Find(p => p.Name == name).FirstOrDefault();
        }

        public Speciality Update(Speciality spec)
        {
            _specialties.DeleteOne(p => p.Id == spec.Id);
            _specialties.InsertOne(spec);
            return spec;
        }
    }
}

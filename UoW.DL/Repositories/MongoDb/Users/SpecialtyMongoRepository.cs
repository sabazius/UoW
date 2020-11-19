using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.DL.Repositories.MongoDb.Users
{
	public class SpecialtyMongoRepository : ISpecialityRepository
    {
        private readonly IMongoCollection<Specialty> _specialties;
        public SpecialtyMongoRepository()
        {
            var client = new MongoClient("mongodb+srv://admin:tpaqMq6k0G9bpVWz@pu-net-core.52gte.mongodb.net/UoW?retryWrites=true&w=majority");
            var database = client.GetDatabase("UoW");
            _specialties = database.GetCollection<Specialty>("Specialty");
        }
        public async Task<Specialty> Create(Specialty user)
        {
            await _specialties.InsertOneAsync(user);
            return user;
        }

        public async Task Delete(int userId)
        {
            await _specialties.DeleteOneAsync(p => p.Id == userId);
        }

        public async Task<IEnumerable<Specialty>> GetAll()
        {
            var result = await _specialties.FindAsync(p => true);
            return result.ToEnumerable();
        }

        public async Task<Specialty> GetById(int userId)
        {
            var result = await _specialties.FindAsync(p => p.Id == userId);

            return result.FirstOrDefault();
        }

        public async Task<Specialty> GetByName(string name)
        {
            var result = await _specialties.FindAsync(p => p.Name == name);

            return result.FirstOrDefault();
        }

        public async Task<Specialty> Update(Specialty spec)
        {
            await _specialties.ReplaceOneAsync(p => p.Id == spec.Id, spec);

            return spec;
        }

	}
}

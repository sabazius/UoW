using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Users;

namespace UoW.DL.Repositories.MongoDb.Users
{
	class FacultyMongoRepository : IFacultyRepository
	{
		private readonly IMongoCollection<Faculty> _faculties;

		public FacultyMongoRepository(IOptions<MongoDbConfiguration> config)
		{
			var client = new MongoClient(config.Value.ConnectionString);
			var database = client.GetDatabase(config.Value.DatabaseName);

			_faculties = database.GetCollection<Faculty>("Faculty");
		}

		public async Task<Faculty> Create(Faculty Faculty)
		{
			await _faculties.InsertOneAsync(Faculty);
			return Faculty;
		}

		public async Task Delete(int FacultyId)
		{
			await _faculties.DeleteOneAsync(p => p.Id == FacultyId);
		}

		public async Task<IEnumerable<Faculty>> GetAll()
		{
			var result = await _faculties.FindAsync(p => true);

			return result.ToEnumerable();
		}

		public async Task<Faculty> GetById(int FacultyId)
		{
			var result = await _faculties.FindAsync(p => p.Id == FacultyId);

			return result.FirstOrDefault();
		}

		public async Task<Faculty> Update(Faculty Faculty)
		{
			await _faculties.ReplaceOneAsync(p => p.Id == Faculty.Id, Faculty);

			return Faculty;
		}
	}
}

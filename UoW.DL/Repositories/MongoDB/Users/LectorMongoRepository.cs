using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Users;

namespace UoW.DL.Repositories.MongoDB.Users
{
	public class LectorMongoRepository : ILectorRepository
	{
		private readonly IMongoCollection<Lector> _lectors;

		public LectorMongoRepository(IOptions<MongoDbConfiguration> config)
		{
			var client = new MongoClient(config.Value.ConnectionString);
			var database = client.GetDatabase(config.Value.DatabaseName);

			_lectors = database.GetCollection<Lector>("Lector");
		}

		public async Task<Lector> Create(Lector lector)
		{
			try
			{
				await _lectors.InsertOneAsync(lector);
			}
			catch (Exception e)
			{

			}
			return lector;
		}

		public async Task Delete(int LectorId)
		{
			await _lectors.DeleteOneAsync(p => p.Id == LectorId);
		}

		public async Task<IEnumerable<Lector>> GetAll()
		{
			var result = await _lectors.FindAsync(p => true);

			return result.ToEnumerable();
		}

		public async Task<Lector> GetById(int userPositionId)
		{
			var result = await _lectors.FindAsync(p => p.Id == userPositionId);

			return result.FirstOrDefault();
		}

		public async Task<Lector> Update(Lector lector)
		{
			await _lectors.ReplaceOneAsync(p => p.Id == lector.Id, lector);

			return lector;
		}
	}
}

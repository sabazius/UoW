using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Repositories.MongoDb.Users
{
	public class TaskTypeMongoRepository : ITaskTypeRepository
	{
		private readonly IMongoCollection<TaskType> _userPositions;

		public TaskTypeMongoRepository(IOptions<MongoDbConfiguration> config)
		{
			var client = new MongoClient(config.Value.ConnectionString);
			var database = client.GetDatabase(config.Value.DatabaseName);

			_userPositions = database.GetCollection<TaskType>("TaskType");
		}

		public async Task<TaskType> Create(TaskType userPosition)
		{
			await _userPositions.InsertOneAsync(userPosition);
			return userPosition;
		}

		public async Task Delete(int userPositionId)
		{
			await _userPositions.DeleteOneAsync(p => p.Id == userPositionId);
		}

		public async Task<IEnumerable<TaskType>> GetAll()
		{
			var result = await _userPositions.FindAsync(p => true);

			return result.ToEnumerable();
		}

		public async Task<TaskType> GetById(int userPositionId)
		{
			var result = await _userPositions.FindAsync(p => p.Id == userPositionId);

			return result.FirstOrDefault();
		}

		public async Task<TaskType> Update(TaskType userPosition)
		{
			await _userPositions.ReplaceOneAsync(p => p.Id == userPosition.Id, userPosition);

			return userPosition;
		}
	}
}

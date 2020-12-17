using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Tasks;

namespace UoW.DL.Repositories.MongoDB.Users
{
	public class UserTaskMongoRepository : IUserTaskRepository
	{
		private readonly IMongoCollection<UserTask> _userTask;

		public UserTaskMongoRepository(IOptions<MongoDbConfiguration> config)
		{
			var client = new MongoClient(config.Value.ConnectionString);
			var database = client.GetDatabase(config.Value.DatabaseName);

			_userTask = database.GetCollection<UserTask>("UserTask");
		}

		public async Task<UserTask> Create(UserTask userTask)
		{
			await _userTask.InsertOneAsync(userTask);
			return userTask;
		}

		public async Task Delete(int userTaskId)
		{
			await _userTask.DeleteOneAsync(p => p.Id == userTaskId);
		}

		public async Task<IEnumerable<UserTask>> GetAll()
		{
			var result = await _userTask.FindAsync(p => true);

			return result.ToEnumerable();
		}

		public async Task<UserTask> GetById(int userTaskId)
		{
			var result = await _userTask.FindAsync(p => p.Id == userTaskId);

			return result.FirstOrDefault();
		}

		public async Task<UserTask> Update(UserTask userPosition)
		{
			await _userTask.ReplaceOneAsync(p => p.Id == userPosition.Id, userPosition);

			return userPosition;
		}
	}
}

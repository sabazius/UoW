using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Tasks;

namespace UoW.DL.Repositories.MongoDB.Tasks
{
    public class UserTaskMongoRepository : IUserTaskRepository
    {
        private readonly IMongoCollection<UserTask> _userTasks;
        private readonly MongoClient client;


        public UserTaskMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _userTasks = database.GetCollection<UserTask>("UserTask");
        }

        public async Task<UserTask> Create(UserTask userTask)
        {
            await _userTasks.InsertOneAsync(userTask);
            return userTask;
        }

        public async Task Delete(int userTaskId)
        {
            await _userTasks.DeleteOneAsync(p => p.Id == userTaskId);
        }

        public async Task<UserTask> GetById(int userTaskId)
        {
            var result = await _userTasks.FindAsync(p => p.Id == userTaskId);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<UserTask>> GetAll()
        {
            var result = await _userTasks.FindAsync(p => true);

            return result.ToEnumerable();
        }
        public async Task<UserTask> GetByName(string name)
        {
            var result = await _userTasks.FindAsync(p => p.Name == name);

            return result.FirstOrDefault();
        }

        public async Task<UserTask> Update(UserTask usetTask)
        {
            await _userTasks.ReplaceOneAsync(p => p.Id == usetTask.Id, usetTask);

            return usetTask;
        }

		public MongoClient GetClient()
		{
            return client;
		}
	}
}
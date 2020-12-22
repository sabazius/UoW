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
    public class UserMongoRepository : IUserRepository
    {
		private readonly IMongoCollection<User> _users;

		public UserMongoRepository(IOptions<MongoDbConfiguration> config)
		{
			var client = new MongoClient(config.Value.ConnectionString);
			var database = client.GetDatabase(config.Value.DatabaseName);

			_users = database.GetCollection<User>("User");
		}

		public async Task<User> Create(User user)
		{
			await _users.InsertOneAsync(user);
			return user;
		}

		public async Task Delete(int userId)
		{
			await _users.DeleteOneAsync(p => p.Id == userId);
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			var result = await _users.FindAsync(p => true);

			return result.ToEnumerable();
		}

		public async Task<User> GetById(int userId)
		{
			var result = await _users.FindAsync(p => p.Id == userId);

			return result.FirstOrDefault();
		}

		public async Task<User> GetByEmail(string name)
		{
			var result = await _users.FindAsync(p => p.Email == name);

			return result.FirstOrDefault();
		}

		public async Task<User> Update(User user)
		{
			await _users.ReplaceOneAsync(p => p.Id == user.Id, user);

			return user;
		}
	}
}

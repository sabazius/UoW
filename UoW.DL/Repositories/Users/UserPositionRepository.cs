using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.DL.Repositories.Users
{
    public class UserPositionRepository : IUserPositionRepository
    {
        private static List<UserPosition> dbTable;

        public UserPositionRepository()
        {
            dbTable = InMemoryDb.UserPositions;
        }

        public Task<UserPosition> Create(UserPosition userPosition)
        {
            dbTable.Add(userPosition);
            return Task.FromResult(userPosition);
        }

        public Task Delete(int userPositionId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userPositionId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
            return Task.CompletedTask;
        }

		public async Task<IEnumerable<UserPosition>> GetAll()
		{
            return await Task.FromResult(dbTable);
		}

		public async Task<UserPosition> GetById(int userPositionId)
		{
            return await Task.FromResult(dbTable.FirstOrDefault(x => x.Id == userPositionId));
        }

		public async Task<UserPosition> Update(UserPosition userPosition)
		{
            var result = dbTable.FirstOrDefault(x => x.Id == userPosition.Id);
            if (result != null)
            {
                await Delete(result.Id);
                return await Create(userPosition);
            }

            return null;
        }
	}
}

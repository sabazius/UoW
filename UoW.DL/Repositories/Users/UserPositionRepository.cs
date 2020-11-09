using System.Collections.Generic;
using System.Linq;
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

        public UserPosition Create(UserPosition userPosition)
        {
            dbTable.Add(userPosition);
            return userPosition;
        }

        public void Delete(int userPositionId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userPositionId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

		public IEnumerable<UserPosition> GetAll()
		{
            return dbTable;
		}

		public UserPosition GetById(int userPositionId)
        {
            return dbTable.FirstOrDefault(x => x.Id == userPositionId);
        }

        public UserPosition Update(UserPosition userPosition)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userPosition.Id);
            if (result != null)
            {
                Delete(result.Id);
                return Create(userPosition);
            }

            return null;
        }
    }
}

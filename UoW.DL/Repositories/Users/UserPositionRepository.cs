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

        public void Create(UserPosition user)
        {
            dbTable.Add(user);
        }

        public void Delete(int userPositionId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userPositionId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public UserPosition GetById(int userPositionId)
        {
            return dbTable.FirstOrDefault(x => x.Id == userPositionId);
        }

        public void Update(UserPosition userPosition)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userPosition.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(userPosition);
            }
        }
    }
}

using PoW.DL.InMemoryDB;
using PoW.DL.Interfaces.Users;
using PoW.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace PoW.DL.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private static List<User> dbTable;

        public UserRepository()
        {
            dbTable = InMemoryDb.Users;
        }

        public void Create(User user)
        {
            dbTable.Add(user);
        }

        public void Delete(int userId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == userId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public User GetById(int userId)
        {
            return dbTable.FirstOrDefault(x => x.Id == userId);
        }

        public void Update(User user)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == user.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(user);
            }
        }
    }
}

using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace UoW.DL.Repositories.Users
{
    public class UserRepository 
    {
        private static List<User> dbTable;

        public UserRepository()
        {
            dbTable = InMemoryDb.Users;
        }

        public User Create(User user)
        {
            dbTable.Add(user);
            return user;
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

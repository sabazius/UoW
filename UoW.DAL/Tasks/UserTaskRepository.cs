using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.User;

namespace UoW.DAL.Tasks
{
    public class UserTaskRepository : IUsersRepository
    {
        public void DeleteUserTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsers()
        {
            return InMemoryDB.Users;
        }

        public void InsertUserTask(Users user)
        {
            throw new NotImplementedException();
        }

        public void UpdatetUserTask(Users user)
        {
            throw new NotImplementedException();
        }
    }
}

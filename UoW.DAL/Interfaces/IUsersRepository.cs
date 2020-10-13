using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.User;

namespace UoW.DAL
{
    interface IUsersRepository
    {


        void InsertUserTask(Users user);
        void UpdatetUserTask(Users user);
        void DeleteUserTask(int id);
        List<Users> GetUsers();

    }
}




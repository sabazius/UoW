using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.User;

namespace UoW.DAL
{
    public static class InMemoryDB
    {
        public static List<Users> Users { get; set; } = new List<Users>();
        public static void Init()
        {
            Users.Add(new Users
            {
                Id = 7,
                Name = "Test Name",
                TeamId = 13,
                FacultyID = 1702811024,
                Email = "alexlomski@abv.bg",
            }

           );
            }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.DALL.InMemoryDB
{
    public class InMemoryDb
    {
        public static List<Lectors> Users { get; set; } = new List<Lectors>();

        public static void Init()
        {
            Users.Add(new Lectors
            {
                ID = 26,
                FirstName = "Georgi",
                LastName = "Dimitrov",
                DateAndTime = new System.DateTime()
            });
            Users.Add(new Lectors
            {
                ID = 37,
                FirstName = "Mihail",
                LastName ="Chilev",
                DateAndTime = new System.DateTime()
            });
            Users.Add(new Lectors
            {
                ID = 55,
                FirstName = "Momchil",
                LastName = "Ivanov",
                DateAndTime = new System.DateTime()
            });
        }
    }
}

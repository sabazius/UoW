using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.User;

namespace UoW.DAL.InMemoryDB
{
   public static class InMemoryDB
    {
        public static List<Specialty> Specialties { get; set; } = new List<Specialty>();
        public static void Init()
        {
            Specialties.Add(new Specialty
            {
                FacultyID = 1,
                ID = 123,
                LectorID = 456,
                Name = "ivan",
                ShortName = "iv"
            });
        }
    }
}

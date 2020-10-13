using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.User;

namespace UoW.DAL.InMemoryDb
{
   public static class InMemoryDb
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
            Specialties.Add(new Specialty
            {
                FacultyID = 2,
                ID = 321,
                LectorID = 654,
                Name = "vasil",
                ShortName = "vas"
            });
        }
    }
}

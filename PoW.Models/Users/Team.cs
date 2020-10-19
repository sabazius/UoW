using System;

namespace UoW.Models.Users
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int FacultyID { get; set; }
    }
}

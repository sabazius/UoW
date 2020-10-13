using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.DAL.InMemoryDB
{
    public static class InMemoryDB
    {
        public static List<Project> Projects { get; set; } = new List<Project>();

        public static void Init()
        {
            Projects.Add(new Project
            {
                Name = "Project",
                Description = "1",
                ID = 3,
                ProductOwnerID = 5,
            });
        }
    }

}



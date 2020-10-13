using System.Collections.Generic;
using UoW.Models.Tasks;

namespace UoW.DAL.InMemoryDB
{
    public static class InMemoryDB
    {
        public static List<TaskTypes> TaskTypess { get; set; } = new List<TaskTypes>();
        public static void Init()
        {
            TaskTypess.Add(new TaskTypes
            {
                Name = "Test Name",
                ID = 1234,
                Description = "A",

            });
            {
                TaskTypess.Add(new TaskTypes
                {
                    Name = "New Name",
                    ID = 1122,
                    Description = "B",
                }
                
                );
            }

        }
    }
}


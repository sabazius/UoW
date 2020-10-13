using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using UoW.DAL.Interfaces;
using UoW.Models.Task;

namespace UoW.DAL.InMemoryDB
{
    public static class InMemoryDB
    {
        public static List<UserTask> userTasks { get; set; } = new List<UserTask>();
        public static void Init()
        {
            {
                userTasks.Add(new UserTask
                {
                    ID = 12,
                    Name = "Test Name",
                    OwnerID = 10
                }

                );
            }
        }
    }
}

    


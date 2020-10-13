using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UoW.DALL.InMemoryDB;
using UoW.DALL.Interface;
using UoW.Models.Tasks;

namespace UoW.DALL.Task
{
    public class LectorsTaskRepository : ILectorsRepository
    {
        public void DeleteLectors(Lectors userTask)
        {
            throw new NotImplementedException();
        }

        public List<Lectors> GetAllUserTasks()
        {
            return InMemoryDb.Users;
        }

        public void InsertLectors(Lectors userTask)
        {
            throw new NotImplementedException();
        }

        public void UpdateLectors(Lectors userTask)
        {
            throw new NotImplementedException();
        }
    }
}

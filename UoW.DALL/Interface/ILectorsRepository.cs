using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.DALL.Interface
{
    public interface ILectorsRepository
    {
        void InsertLectors(Lectors userTask);
        void UpdateLectors(Lectors userTask);
        void DeleteLectors(Lectors userTask);
        List<Lectors> GetAllUserTasks();
    }
}

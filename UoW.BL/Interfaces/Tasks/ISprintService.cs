using System.Collections.Generic;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public interface ISprintService
    {
        Sprint GetSprintById(int id);
        Sprint Create(Sprint sprint);
        void Delete(int sprintId);
        Sprint Update(Sprint sprint);
        IEnumerable<Sprint> GetAll();
    }
}

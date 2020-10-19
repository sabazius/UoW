using UoW.Models.Tasks;

namespace UoW.BL.Interface.Tasks
{
    public interface ISprintService
    {
       Sprint GetSprintById(int id);
    }
}

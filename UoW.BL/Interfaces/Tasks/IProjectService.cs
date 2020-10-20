using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public interface IProjectService
    {
        Project GetProjectById(int id);
    }
}

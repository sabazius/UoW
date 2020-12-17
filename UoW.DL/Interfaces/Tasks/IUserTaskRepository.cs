using System.Threading.Tasks;
using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
    public interface IUserTaskRepository
    {
    	Task<UserTask> Create(UserTask user);
        Task Delete(int userId);
        Task<UserTask> Update(UserTask user);
        Task<UserTask> GetById(int userId);
    }
}

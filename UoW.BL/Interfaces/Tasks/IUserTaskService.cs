using System.Threading.Tasks;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
	public interface IUserTaskService
	{
		Task<UserTask> Create(UserTask user);
		Task Delete(int userId);
		Task<UserTask> Update(UserTask user);
		Task<UserTask> GetById(int userId);
	}
}

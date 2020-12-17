using System.Threading.Tasks;
using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
	public class UserTaskService : IUserTaskService
	{
		IUserTaskRepository _userTaskRepository;

		public UserTaskService(IUserTaskRepository userTaskRepository)
		{
			_userTaskRepository = userTaskRepository;
		}

		async Task<UserTask> IUserTaskService.Create(UserTask user)
		{
			return await _userTaskRepository.Create(user);
		}

		async Task IUserTaskService.Delete(int userTaskId)
		{
			await _userTaskRepository.Delete(userTaskId);
		}

		async Task<UserTask> IUserTaskService.GetById(int userTaskId)
		{
			return await _userTaskRepository.GetById(userTaskId);
		}

		async Task<UserTask> IUserTaskService.Update(UserTask user)
		{
			return await _userTaskRepository.Update(user);
		}
	}
}

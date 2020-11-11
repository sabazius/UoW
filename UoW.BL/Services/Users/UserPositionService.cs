using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.BL.Services.Users
{
	public class UserPositionService : IUserPositionService
	{
		private IUserPositionRepository _userPositionRepository;
		private ILectorRepository _lectorRepository;

		public UserPositionService(IUserPositionRepository userPositionRepository, ILectorRepository lectorRepository)
		{
			_userPositionRepository = userPositionRepository;
			_lectorRepository = lectorRepository;
		}

		public async Task DeleteUserPosition(int userPositionId)
		{
			await _userPositionRepository.Delete(userPositionId);
		}

		public async Task<IEnumerable<UserPosition>> GetAll()
		{
			return await _userPositionRepository.GetAll();
		}

		public async Task<UserPosition> GetUserPosition(int userPositionId)
		{
			return await _userPositionRepository.GetById(userPositionId);
		}

		public async Task<UserPosition> SaveUserPosition(UserPosition userPosition)
		{
			return await _userPositionRepository.Update(userPosition);
		}
	}
}

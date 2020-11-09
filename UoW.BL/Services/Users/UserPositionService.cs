using System.Collections.Generic;
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

		public void DeleteUserPosition(int userPositionId)
		{
			_userPositionRepository.Delete(userPositionId);
		}

		public IEnumerable<UserPosition> GetAll()
		{
			return _userPositionRepository.GetAll();
		}

		public UserPosition GetUserPosition(int userPositionId)
		{
			return _userPositionRepository.GetById(userPositionId);
		}

		public UserPosition SaveUserPosition(UserPosition userPosition)
		{
			var result = _userPositionRepository.GetById(userPosition.Id);

			if (result != null)
			{
				return _userPositionRepository.Update(userPosition);
			}
			else
			{
				return _userPositionRepository.Create(userPosition);
			}
		}
	}
}

using System.Collections.Generic;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
	public interface IUserPositionService
	{
		UserPosition GetUserPosition(int userPositionId);

		UserPosition SaveUserPosition(UserPosition userPosition);

		void DeleteUserPosition(int userPositionId);

		IEnumerable<UserPosition> GetAll();
	}
}

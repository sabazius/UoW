using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
	public interface IUserPositionService
	{
		Task<UserPosition> GetUserPosition(int userPositionId);

		Task<UserPosition> Update(UserPosition userPosition);

		Task<UserPosition> Create(UserPosition userPosition);

		Task DeleteUserPosition(int userPositionId);

		Task<IEnumerable<UserPosition>> GetAll();
	}
}

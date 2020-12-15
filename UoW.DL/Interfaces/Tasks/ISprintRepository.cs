using System.Collections.Generic;
using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
	public interface ISprintRepository
	{
		void Create(Sprint user);
		void Delete(int userId);
		void Update(Sprint user);
		Sprint GetById(int userId);
		IEnumerable<Sprint> GetAll();
	}
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> GetUserByid(int id);

        Task<User> Update(User user);

        Task<User> Create(User user);

        Task DeleteUser(int userId);

        Task<IEnumerable<User>> GetAll();
        Task<User> UpdateUser(int userId, int teamId, int facultyId, string email, int userPositionId);
    }
}

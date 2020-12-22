using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task Delete(int userId);
        Task<User> Update(User user);
        Task<User> GetById(int userId);
        Task<User> GetByEmail(string name);
        Task<IEnumerable<User>> GetAll();
    }
}

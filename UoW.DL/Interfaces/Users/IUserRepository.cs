using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface IUserRepository
    {
    	void Create(User user);
        void Delete(int userId);
        void Update(User user);
        User GetById(int userId);
    }
}

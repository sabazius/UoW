using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface IUserService
    {
        User GetUserByid(int id);
    }
}

using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;

namespace UoW.BL.Services.Users
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepositor)
        {
            _userRepository = userRepositor;
        }

        public Models.Users.User GetUserByid(int id)
        {
            return _userRepository.GetById(id);
        }

    }
}

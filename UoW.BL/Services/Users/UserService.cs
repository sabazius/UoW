using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;

namespace UoW.BL.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        readonly IFacultyRepository _facultyRepository;
        readonly IUserPositionRepository _userPositionRepository;

        public UserService(IUserRepository userRepositor, ITeamRepository teamRepository, IFacultyRepository facultyRepository, IUserPositionRepository userPositionRepository)
        {
            _userRepository = userRepositor;
            _teamRepository = teamRepository;
            _facultyRepository = facultyRepository;
            _userPositionRepository = userPositionRepository;
        }

        public async Task<Models.Users.User> Create(Models.Users.User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.Delete(userId);
        }

        public async Task<IEnumerable<Models.Users.User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<Models.Users.User> GetUserByid(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<Models.Users.User> Update(Models.Users.User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<Models.Users.User> UpdateUser(int userId, int teamId, int facultyId, string email, int userPositionId)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                return null;
            }

            if (email != user.Email)
            {
                var validEmail = await _userRepository.GetByEmail(email) == null;

                if (!validEmail)
                {
                    return null;
                }
                user.Email = email;
            }

            var validTeam = _teamRepository.GetById(teamId) != null;
            if(validTeam)
            {
                user.TeamID = teamId;
            }

            var validFaculty = await _facultyRepository.GetById(facultyId) != null;
            if(validFaculty)
            {
                user.FacultylID = facultyId;
            }

            var validUserPosition = await _userPositionRepository.GetById(userPositionId) != null;
            if(validUserPosition)
            {
                user.UserPositionId = userPositionId;
            }

            var result = await _userRepository.Update(user);

            return result;
        }
    }
}

using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.BL.Services.Users
{
    public class UserPositionService : IUserPositionService
    {
        private IUserPositionRepository _userPositionRepository;

        public UserPositionService(IUserPositionRepository userPositionRepository)
        {
            _userPositionRepository = userPositionRepository;
        }

        public void DeleteUserPosition(int userPositionId)
        {
            _userPositionRepository.Delete(userPositionId);
        }

        public UserPosition GetUserPosition(int userPositionId)
        {
            return _userPositionRepository.GetById(userPositionId);
        }

        public void SaveUserPosition(UserPosition userPosition)
        {
            var result = _userPositionRepository.GetById(userPosition.Id);
            if (result != null)
            {
                _userPositionRepository.Update(userPosition);
            }
            else
            {
                _userPositionRepository.Create(userPosition);
            }
        }
    }
}

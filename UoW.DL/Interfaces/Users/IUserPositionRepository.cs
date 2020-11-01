using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface IUserPositionRepository
    {
        void Create(UserPosition userPosition);
        void Delete(int userPositionId);
        void Update(UserPosition userPosition);
        UserPosition GetById(int userPositionId);
    }
}

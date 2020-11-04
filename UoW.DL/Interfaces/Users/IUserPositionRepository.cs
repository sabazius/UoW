using System.Collections;
using System.Collections.Generic;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface IUserPositionRepository
    {
        UserPosition Create(UserPosition userPosition);
        void Delete(int userPositionId);
        UserPosition Update(UserPosition userPosition);
        UserPosition GetById(int userPositionId);

        IEnumerable<UserPosition> GetAll();
    }
}

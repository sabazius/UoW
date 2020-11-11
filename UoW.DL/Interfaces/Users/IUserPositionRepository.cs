using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface IUserPositionRepository
    {
        Task<UserPosition> Create(UserPosition userPosition);
        void Delete(int userPositionId);
        Task<UserPosition> Update(UserPosition userPosition);
        Task<UserPosition> GetById(int userPositionId);
        Task<IEnumerable<UserPosition>> GetAll();
    }
}

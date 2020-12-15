using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ILectorRepository
    {
    	Task<Lector> Create(Lector user);
        Task Delete(int userId);
        Task<Lector> Update(Lector user);
        Task<Lector> GetById(int userId);
        Task<IEnumerable<Lector>> GetAll();
    }
}

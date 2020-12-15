using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface ILectorService
    {
        Task<Lector> Create(Lector lector);
        Task Delete(int lectorId);
        Task<Lector> Update(Lector lector);
        Task<Lector> GetById(int lectorId);
        Task<IEnumerable<Lector>> GetAll();
        Task<Lector> UpdateFaculty(int facultyId,int lectorId);
    }
}

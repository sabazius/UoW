using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface ISpecialtyService
    {
        Task<Speciality> GetSpecialtyById(int id);
        Task<Speciality> Create(Speciality speciality);
        Task<IEnumerable<Speciality>> GetAll();
        Task Delete(int id);
        Task<Speciality> Update(Speciality speciality);
        Task<Speciality> GetByName(string name);
    }
}

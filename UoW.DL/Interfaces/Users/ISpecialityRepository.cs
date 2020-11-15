using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ISpecialityRepository
    {
        Task<Speciality> Create(Speciality user);
        Task Delete(int userId);
        Task<Speciality> Update(Speciality user);
        Task<IEnumerable<Speciality>> GetAll();
        Task<Speciality> GetById(int userId);
        Task<Speciality> GetByName(string name);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ISpecialityRepository
    {
        Task<Specialty> Create(Specialty user);
        Task Delete(int userId);
        Task<Specialty> Update(Specialty user);
        Task<IEnumerable<Specialty>> GetAll();
        Task<Specialty> GetById(int userId);
        Task<Specialty> GetByName(string name);
    }
}

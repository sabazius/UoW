using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Contracts.Requests;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface ISpecialtyService
    {
        Task<Specialty> GetSpecialtyById(int id);
        Task<Specialty> Create(Specialty speciality);
        Task<IEnumerable<Specialty>> GetAll();
        Task Delete(int id);
        Task<Specialty> Update(Specialty speciality);
        Task<Specialty> GetByName(string name);
        Task<Specialty> UpdateSpecialty(int specialtyId, int lectorId, string name, string shortName);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ISpecialityRepository
    {
        Speciality Create(Speciality user);
        void Delete(int userId);
        Speciality Update(Speciality user);
        List<Speciality> GetAll();
        Speciality GetById(int userId);
        Speciality GetByName(string name);
    }
}

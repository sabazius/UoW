using System.Collections.Generic;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface ISpecialtyService
    {
        Speciality GetSpecialtyById(int id);
        Speciality Create(Speciality speciality);
        List<Speciality> GetAll();
        void Delete(int id);
        Speciality Update(Speciality speciality);
        Speciality GetByName(string name);
        bool checkExistance(Speciality specialty);
        bool checkUniquenes(Speciality speciality);
    }
}

using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface ISpecialtyService
    {
        Speciality GetSpecialtyById(int id);
        Speciality Create(Speciality speciality);
        void Delete(int id);
        Speciality Update(Speciality speciality);
    }
}

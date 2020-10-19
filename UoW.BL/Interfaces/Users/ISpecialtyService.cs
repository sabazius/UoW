using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface ISpecialtyService
    {
        Speciality GetSpecialtyById(int id);
    }
}

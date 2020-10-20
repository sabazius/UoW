using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface IFacultyService
    {
        Faculty GetFacultyById(int id);
    }
}

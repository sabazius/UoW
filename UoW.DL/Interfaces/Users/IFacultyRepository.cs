using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface IFacultyRepository
    {
    	void Create(Faculty user);
        void Delete(int userId);
        void Update(Faculty user);
        Faculty GetById(int userId);
    }
}

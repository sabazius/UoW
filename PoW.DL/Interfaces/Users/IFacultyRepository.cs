using PoW.Models.Users;

namespace PoW.DL.Interfaces.Users
{
    public interface IFacultyRepository
    {
    	void Create(Faculty user);
        void Delete(int userId);
        void Update(Faculty user);
        Faculty GetById(int userId);
    }
}

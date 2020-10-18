using PoW.Models.Users;

namespace PoW.DL.Interfaces.Users
{
    public interface ISpecialityRepository
    {
    	void Create(Speciality user);
        void Delete(int userId);
        void Update(Speciality user);
        Speciality GetById(int userId);
    }
}

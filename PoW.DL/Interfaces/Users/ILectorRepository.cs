using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ILectorRepository
    {
    	void Create(Lector user);
        void Delete(int userId);
        void Update(Lector user);
        Lector GetById(int userId);
    }
}

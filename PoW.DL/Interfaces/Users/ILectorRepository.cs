using PoW.Models.Users;

namespace PoW.DL.Interfaces.Users
{
    public interface ILectorRepository
    {
    	void Create(Lector user);
        void Delete(int userId);
        void Update(Lector user);
        Lector GetById(int userId);
    }
}

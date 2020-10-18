using PoW.Models.Users;

namespace PoW.DL.Interfaces.Users
{
    public interface ITeamRepository
    {
    	void Create(Team user);
        void Delete(int userId);
        void Update(Team user);
        Team GetById(int userId);
    }
}

using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ITeamRepository
    {
    	void Create(Team user);
        void Delete(int userId);
        void Update(Team user);
        Team GetById(int userId);
    }
}

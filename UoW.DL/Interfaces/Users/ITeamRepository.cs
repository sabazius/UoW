using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ITeamRepository
    {
    	Task<Team> Create(Team user);
        void Delete(int userId);
        Task<Team> Update(Team user);
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(int userId);
    }
}

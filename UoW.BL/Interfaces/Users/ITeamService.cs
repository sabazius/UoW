using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.BL.Interface.User
{
    public interface ITeamService 
    {
        Task<Team> GetTeamById(int id);
        Task<Team> Create(Team team);
        Task Delete(int id);
        Task<Team> Update(Team team);
        Task<IEnumerable<Team>> GetAll();
        Task<Team> UpdateName(string name, int teamId);
        Task<Team> UpdateFacultyID(int facultyId, int teamId);
    }
}

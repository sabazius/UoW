using UoW.Models.Users;

namespace UoW.BL.Interface.User
{
    public interface ITeamService
    {
        Team GetTeamById(int id);
    }
}

using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface IFacultyRepository
    {
    	Task<Faculty> Create(Faculty user);
        Task Delete(int userId);
        Task<Faculty> Update(Faculty user);
        Task<Faculty> GetById(int userId);
    }
}

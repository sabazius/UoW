using System.Threading.Tasks;
using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface IFacultyService
    {
        Task<Faculty> Create(Faculty user);
        Task Delete(int userId);
        Task<Faculty> Update(Faculty user);
        Task<Faculty> GetById(int userId);
        Task<Faculty> UpdateFaculty(int facultyId, string name, string shortName, string description);
    }
}

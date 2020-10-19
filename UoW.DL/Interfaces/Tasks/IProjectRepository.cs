using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
    public interface IProjectRepository
    {
    	void Create(Project user);
        void Delete(int userId);
        void Update(Project user);
        Project GetById(int userId);
    }
}

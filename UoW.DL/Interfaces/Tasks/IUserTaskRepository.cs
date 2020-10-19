using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
    public interface IUserTaskRepository
    {
    	void Create(UserTask user);
        void Delete(int userId);
        void Update(UserTask user);
        UserTask GetById(int userId);
    }
}

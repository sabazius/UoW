using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
    public interface ITaskTypeRepository
    {
    	void Create(TaskType user);
        void Delete(int userId);
        void Update(TaskType user);
        TaskType GetById(int userId);
    }
}

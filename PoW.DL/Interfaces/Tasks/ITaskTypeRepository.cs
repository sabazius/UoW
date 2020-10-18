using PoW.Models.Tasks;

namespace PoW.DL.Interfaces.Users
{
    public interface ITaskTypeRepository
    {
    	void Create(TaskType user);
        void Delete(int userId);
        void Update(TaskType user);
        TaskType GetById(int userId);
    }
}

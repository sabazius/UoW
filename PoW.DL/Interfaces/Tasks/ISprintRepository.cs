using PoW.Models.Tasks;

namespace PoW.DL.Interfaces.Users
{
    public interface ISprintRepository
    {
    	void Create(Sprint user);
        void Delete(int userId);
        void Update(Sprint user);
        Sprint GetById(int userId);
    }
}

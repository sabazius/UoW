using PoW.Models.Tasks;

namespace PoW.DL.Interfaces.Users
{
    public interface IStoryRepository
    {
    	void Create(Story user);
        void Delete(int userId);
        void Update(Story user);
        Story GetById(int userId);
    }
}

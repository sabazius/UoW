using UoW.Models.Tasks;

namespace UoW.DL.Interfaces.Users
{
    public interface IStoryRepository
    {
    	void Create(Story user);
        void Delete(int userId);
        void Update(Story user);
        Story GetById(int userId);
    }
}

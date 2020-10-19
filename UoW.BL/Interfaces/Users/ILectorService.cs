using UoW.Models.Users;

namespace UoW.BL.Interfaces.Users
{
    public interface ILectorService
    {
        Lector GetLectorId(int Id);
    }
}

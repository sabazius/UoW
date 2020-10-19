using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.BL.Services.Users
{
    public class LectorService : ILectorService
    {
        ILectorRepository _lectorRepository;

        public LectorService(ILectorRepository lectorRepository)
        {
            _lectorRepository = lectorRepository;
        }
        public Lector GetLectorId(int Id)
        {
            return _lectorRepository.GetById(Id);
        }
    }
}

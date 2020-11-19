using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Lector> Create(Lector lector)
        {
            return await _lectorRepository.Create(lector);
        }

        public async Task Delete(int lectorId)
        {
            await _lectorRepository.Delete(lectorId);
        }

        public async Task<IEnumerable<Lector>> GetAll()
        {
            return await _lectorRepository.GetAll();
        }

        public async Task<Lector> GetById(int lectorId)
        {
            return await _lectorRepository.GetById(lectorId);
        }

        public async Task<Lector> Update(Lector lector)
        {
            return await _lectorRepository.Update(lector);
        }
    }
}

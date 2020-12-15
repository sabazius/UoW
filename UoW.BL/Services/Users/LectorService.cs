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
        IFacultyRepository _facultyRepository;

        public LectorService(ILectorRepository lectorRepository,IFacultyRepository facultyRepository)
        {
            _lectorRepository = lectorRepository;
            _facultyRepository = facultyRepository;
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

        public async Task<Lector> UpdateFaculty(int facultyId,int lectorId)
        {
           var lector = await _lectorRepository.GetById(lectorId);

            if (lector == null)
                return null;

            var faculty = await _facultyRepository.GetById(facultyId);

            if (faculty == null)
                return null;

            lector.FacultyId = facultyId;

            var result = await _lectorRepository.Update(lector);

            return result;
        }

    }
}

using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.BL.Services.Users
{
    public class SpecialtyService : ISpecialtyService
    {
        private ISpecialityRepository _specialtyRepository;
        public SpecialtyService(ISpecialityRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }
        public Speciality GetSpecialtyById(int id)
        {
           return _specialtyRepository.GetById(id);
        }
    }
}

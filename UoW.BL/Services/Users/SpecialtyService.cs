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

        Speciality ISpecialtyService.Create(Speciality speciality)
        {
             _specialtyRepository.Create(speciality);

            return _specialtyRepository.GetById(speciality.Id);
        }

        void ISpecialtyService.Delete(int id)
        {
            _specialtyRepository.Delete(id);
        }

        Speciality ISpecialtyService.Update(Speciality speciality)
        {
            _specialtyRepository.Update(speciality);
            return _specialtyRepository.GetById(speciality.Id);
        }
    }
}
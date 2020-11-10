using System.Collections.Generic;
using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.BL.Services.Users
{
    public class SpecialtyService : ISpecialtyService
    {
        private ISpecialityRepository _specialtyRepository;
        private IFacultyRepository _facultyRepository;
        private ILectorRepository _lectorRepository;
        public SpecialtyService(ISpecialityRepository specialtyRepository, IFacultyRepository facultyRepository, ILectorRepository lectorRepository)
        {
            _specialtyRepository = specialtyRepository;
            _facultyRepository = facultyRepository;
            _lectorRepository = lectorRepository;
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

        List<Speciality> ISpecialtyService.GetAll()
        {
            return _specialtyRepository.GetAll();
        }

        Speciality ISpecialtyService.Update(Speciality speciality)
        {
            _specialtyRepository.Update(speciality);
            return _specialtyRepository.GetById(speciality.Id);
        }

        Speciality ISpecialtyService.GetByName(string name)
        {
            return _specialtyRepository.GetByName(name);
        }

        bool ISpecialtyService.checkExistance(Speciality specialty)
        {
            var facultyIdExists = _facultyRepository.GetById(specialty.FacultyId) != null;
            var lectorIdExists = _lectorRepository.GetById(specialty.LectorId) != null;
            if (facultyIdExists && lectorIdExists) return true;

            return false;
        }

        bool ISpecialtyService.checkUniquenes(Speciality speciality)
        {
            var uniqueId = _specialtyRepository.GetById(speciality.Id) == null;
            var uniqueName = _specialtyRepository.GetByName(speciality.Name) == null;
            if (uniqueId && uniqueName) return true;

            return false;
        }
    }
}
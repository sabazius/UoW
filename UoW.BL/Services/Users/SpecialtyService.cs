using System;
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
            var facultyIdExists = _facultyRepository.GetById(speciality.FacultyId) != null;
            var lectorIdExists = _lectorRepository.GetById(speciality.LectorId) != null;
            var uniqueId = _specialtyRepository.GetById(speciality.Id) == null;
            var uniqueName = _specialtyRepository.GetByName(speciality.Name) == null;
            if (facultyIdExists && lectorIdExists && uniqueId && uniqueName)
            {
                return _specialtyRepository.Create(speciality);
            }
            else
            {
                throw new Exception();
            }
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
            var facultyIdExists = _facultyRepository.GetById(speciality.FacultyId) != null;
            var lectorIdExists = _lectorRepository.GetById(speciality.LectorId) != null;
            var idExists = _specialtyRepository.GetById(speciality.Id) != null;
            var uniqueName = _specialtyRepository.GetByName(speciality.Name) == null;
            if(facultyIdExists && lectorIdExists && idExists && uniqueName)
            {
                return _specialtyRepository.Update(speciality);
            }
            else
            {
                throw new Exception();
            }
        }

        Speciality ISpecialtyService.GetByName(string name)
        {
            return _specialtyRepository.GetByName(name);
        }
    }
}
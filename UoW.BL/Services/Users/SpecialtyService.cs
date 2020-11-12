using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<Speciality> GetSpecialtyById(int id)
        {
           return await _specialtyRepository.GetById(id);
        }

        public async Task<Speciality> Create(Speciality speciality)
        {
            var facultyIdExists = _facultyRepository.GetById(speciality.FacultyId) != null;
            var lectorIdExists = _lectorRepository.GetById(speciality.LectorId) != null;
            var uniqueId = _specialtyRepository.GetById(speciality.Id) == null;
            var uniqueName = _specialtyRepository.GetByName(speciality.Name) == null;
            if (facultyIdExists && lectorIdExists && uniqueId && uniqueName)
            {
                return await _specialtyRepository.Create(speciality);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Delete(int id)
        {
           await _specialtyRepository.Delete(id);        }

        public async Task<List<Speciality>> GetAll()
        {
            return await _specialtyRepository.GetAll();
        }

        public async Task<Speciality> Update(Speciality speciality)
        {
            var facultyIdExists = _facultyRepository.GetById(speciality.FacultyId) != null;
            var lectorIdExists = _lectorRepository.GetById(speciality.LectorId) != null;
            var idExists = _specialtyRepository.GetById(speciality.Id) != null;
            var uniqueName = _specialtyRepository.GetByName(speciality.Name) == null;
            if(facultyIdExists && lectorIdExists && idExists && uniqueName)
            {
                return await _specialtyRepository.Update(speciality);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<Speciality> GetByName(string name)
        {
            return await _specialtyRepository.GetByName(name);
        }
    }
}
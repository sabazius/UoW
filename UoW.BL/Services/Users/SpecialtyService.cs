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
        public async Task<Specialty> GetSpecialtyById(int id)
        {
           return await _specialtyRepository.GetById(id);
        }

        public async Task<Specialty> Create(Specialty speciality)
        {
            List<Task> tasks = new List<Task>();

            var facultyIdExists = _facultyRepository.GetById(speciality.FacultyId);
            tasks.Add(facultyIdExists);
            var uniqueId = _specialtyRepository.GetById(speciality.Id);
            tasks.Add(uniqueId);
            var uniqueName = _specialtyRepository.GetByName(speciality.Name);
            tasks.Add(uniqueName);

            await Task.WhenAll(tasks);

            var lectorIdExists = _lectorRepository.GetById(speciality.LectorId) != null;
            if (facultyIdExists.Result != null && lectorIdExists && uniqueId.Result == null && uniqueName.Result == null)
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
            await _specialtyRepository.Delete(id);
        }

        public async Task<IEnumerable<Specialty>> GetAll()
        {
            return await _specialtyRepository.GetAll();
        }

        public async Task<Specialty> Update(Specialty speciality)
        {
            List<Task> tasks = new List<Task>();

            var facultyIdExists = _facultyRepository.GetById(speciality.FacultyId);
            tasks.Add(facultyIdExists);
            var idExists = _specialtyRepository.GetById(speciality.Id);
            tasks.Add(idExists);
            var uniqueName = _specialtyRepository.GetByName(speciality.Name);
            tasks.Add(uniqueName);

            var lectorIdExists = _lectorRepository.GetById(speciality.LectorId) != null;

            await Task.WhenAll(tasks);

            if(facultyIdExists.Result != null && lectorIdExists && idExists.Result != null && uniqueName.Result == null)
            {
                return await _specialtyRepository.Update(speciality);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<Specialty> GetByName(string name)
        {
            return await _specialtyRepository.GetByName(name);
        }

        public async Task<Specialty> UpdateSpecialty(int specialtyId, int lectorId, string name, string shortName)
        {
            var specialty = await _specialtyRepository.GetById(specialtyId);

            if (specialty == null)
            {
                return null;
            }

            if(name != specialty.Name)
            {
                var validName = await _specialtyRepository.GetByName(name) == null;

                if (!validName)
                {
                    return null;
                }
                specialty.Name = name;
            }


            var lector = await _lectorRepository.GetById(lectorId);

            if (lector == null)
            {
                return null;
            }

            specialty.LectorId = lectorId;
            specialty.ShortName = shortName;

            var result = await _specialtyRepository.Update(specialty);

            return result;
        }
    }
}
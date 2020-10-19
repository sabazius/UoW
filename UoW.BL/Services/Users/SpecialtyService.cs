using PoW.DL.Interfaces.Users;
using PoW.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using UoW.BL.Interfaces.Users;

namespace UoW.BL.Services.Users
{
    public class SpecialtyService : ISpecialtyService
    {
        private ISpecialityRepository _specialtyRepository;
        public SpecialtyService(ISpecialityRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }
        Speciality ISpecialtyService.GetSpecialtyById(int id)
        {
           return _specialtyRepository.GetById(id);
        }
    }
}

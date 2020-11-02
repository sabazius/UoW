using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml;
using UoW.BL.Interfaces.Users;
using UoW.Models.Contracts.Requests;
using UoW.Models.Users;

namespace UoW.Controllers
{
    [Route("specialties")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private ISpecialtyService _specialtyService;
        private IMapper _mapper;

        public SpecialtyController(ISpecialtyService specialtyService, IMapper mapper)
        {
            _specialtyService = specialtyService;
            _mapper = mapper;
        }
        [HttpGet("id")]
        public IActionResult GetSpecialtyById(int specialtyId)
        {
            var result = _specialtyService.GetSpecialtyById(specialtyId);
            if (result == null) return NotFound();

            var specialty = _mapper.Map<Speciality>(result);

            return Ok(specialty);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Speciality> specialties = new List<Speciality>();
            var result = _specialtyService.GetAll();

            if (result == null || result.Count == 0)
            {
                return NotFound();
            }

            result.ForEach(delegate (Speciality specialty)
            {
                var mappedSpecialty = _mapper.Map<Speciality>(specialty);
                specialties.Add(mappedSpecialty);
            });

            return Ok(specialties);
        }



        [HttpPost]
        public IActionResult CreateSpecialty([FromBody] SpecialtyRequest request)
        {
            if (request == null) return NotFound();

            var specialty = _mapper.Map<Speciality>(request);

            List<Speciality> specialtiesList = _specialtyService.GetAll();
            //List<Faculty> faculties = _facultyService.GetAll();  GetAll function not implemented
            //List<Lector> lectors = _lectorService.GetAll();  GetAll function not implemented
            var uniqueId = true;
            var uniqueName = true;
            var facultuIdExists = false;
            var lectorIdExists = false;

            specialtiesList.ForEach(delegate (Speciality spec)
            {
                if (spec.Id == specialty.Id) uniqueId = false;
                if(spec.Name == specialty.Name) uniqueName = false;
                //faculties.ForEach(delegate (Faculty fac)  GetAll function not implemented
                //{
                //    if(fac.Id === specialty.facultyId) {facultuIdExists = true; return;} 
                //})
                //lectors.ForEach(delegate (Lector lec)  GetAll function not implemented
                //{
                //    if(lec.Id === specialty.lectorId) {lectorIdExists = true; return;} 
                //})
            });

            if(!uniqueId || !uniqueName)
            {
                return Conflict("Dublicate key");
            }

            //if (!facultuIdExists) return NotFound();  
            //if (!lectorIdExists) return NotFound();

            var result = _specialtyService.Create(specialty);

            if (result == null) return NotFound();

            return Ok(specialty);

        }

        [HttpDelete]
        public IActionResult DeleteSpecialty(int id)
        {
            if (id <= 0) return BadRequest();

            var specialty = _specialtyService.GetSpecialtyById(id);
            _specialtyService.Delete(id);

            if (specialty == null) return NotFound();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSpecialty([FromBody] SpecialtyRequest request)
        {
            if (request == null) return NotFound();

            var specialty = _mapper.Map<Speciality>(request);
            var result = _specialtyService.Update(specialty);

            if (result == null) return NotFound();

            return Ok(specialty);
        }
        
       
    }
}
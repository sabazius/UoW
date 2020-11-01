using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult GetSpecialtyById(int specialtyId)
        {
            var result = _specialtyService.GetSpecialtyById(specialtyId);
            if (result == null) return NotFound();

            var specialty = _mapper.Map<Speciality>(result);

            return Ok(specialty);
        }

        [HttpPost]
        public IActionResult CreateSpecialty([FromBody] SpecialtyRequest request)
        {
            if (request == null) return NotFound();

            var specialty = _mapper.Map<Speciality>(request);
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
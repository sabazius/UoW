using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
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
        public async Task<IActionResult> GetSpecialtyById(int specialtyId) 
        {
            var result = await _specialtyService.GetSpecialtyById(specialtyId);
            if (result == null) return NotFound("Specialty not found");

            var specialty = _mapper.Map<Specialty>(result);

            return Ok(specialty);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _specialtyService.GetAll();

            if (result == null) return NotFound("Collection is empty!");

            var response = _mapper.Map<IEnumerable<SpecialtyResponse>>(result);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateSpecialty([FromBody] SpecialtyRequest request)
        {
            if (request == null) return NotFound();

            var specialty = _mapper.Map<Specialty>(request);

            var result = _specialtyService.Create(specialty);

            if (result == null) return NotFound();

            return Ok(specialty);
        }

        [HttpDelete]
        public async  Task<IActionResult> DeleteSpecialty(int id)
        {
            if (id <= 0) return BadRequest();

            var specialty = await _specialtyService.GetSpecialtyById(id);
            if (specialty == null) return NotFound();

             await _specialtyService.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialty([FromBody] Specialty request)
        {
            if (request == null) return NotFound();

            var specialty = _mapper.Map<Specialty>(request);

            var result = await _specialtyService.Update(specialty);
            if (result == null) return NotFound("not found");

            return Ok(_mapper.Map<SpecialtyResponse>(result));
        }
    }
}
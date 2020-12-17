using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Contracts.Responses;

namespace UoW.Controllers
{
	public class UserOperations : ControllerBase
	{
		private readonly ISpecialtyService _specialtyService;
        private readonly ILectorService _lectorService;
		private readonly IMapper _mapper;
		public UserOperations(ISpecialtyService specialtyService, ILectorService lectorService, IMapper mapper)
		{
			_specialtyService = specialtyService;
			_mapper = mapper;
            _lectorService = lectorService;
		}

		[HttpPost("SpecialtyUpdate")]
		public async Task<IActionResult> SpecialtyUpdate(int specialtyId, string name, int lectorId, string shortName)
		{
			var result = await _specialtyService.UpdateSpecialty(specialtyId, lectorId, name, shortName);

			if (result == null) return NotFound();

			var specialty = _mapper.Map<SpecialtyResponse>(result);

			return Ok(specialty);
		}

        [HttpPost("LectorUpdateFacultyId")]
        public async Task<IActionResult> LectorUpdateFacultyId( int facultyId,int lectorId)
        {
            var result = await _lectorService.UpdateFaculty(facultyId,lectorId);

            if (result == null) return NotFound();

            var lector = _mapper.Map<LectorResponse>(result);

            return Ok(lector);
        }
    }
}

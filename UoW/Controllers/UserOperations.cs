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
		private readonly IMapper _mapper;
		public UserOperations(ISpecialtyService specialtyService, IMapper mapper)
		{
			_specialtyService = specialtyService;
			_mapper = mapper;
		}

		[HttpPost("SpecialtyUpdate")]
		public async Task<IActionResult> SpecialtyUpdate(int specialtyId, string name, int lectorId, string shortName)
        {
			var result = await _specialtyService.UpdateSpecialty(specialtyId, lectorId, name, shortName);

			if (result == null) return NotFound();

			var specialty = _mapper.Map<SpecialtyResponse>(result);

			return Ok(specialty);
		}


	}
}

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
        private readonly IUserService _userService;
        private readonly ILectorService _lectorService;
        private readonly IFacultyService _facultyService;
		private readonly IMapper _mapper;
		public UserOperations(ISpecialtyService specialtyService, IUserService userService, ILectorService lectorService, IMapper mapper, IFacultyService facultyService)
		{
            _specialtyService = specialtyService;
            _userService = userService;
			_mapper = mapper;
            _lectorService = lectorService;
            _facultyService = facultyService;
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
        public async Task<IActionResult> LectorUpdateFacultyId(int facultyId, int lectorId)
        {
            var result = await _lectorService.UpdateFaculty(facultyId, lectorId);

            if (result == null) return NotFound();

            var lector = _mapper.Map<LectorResponse>(result);

            return Ok(lector);
        }

        [HttpPost("FacultyUpdate")]
        public async Task<IActionResult> FacultyUpdate(int facultyId, string name, string shortName, string description)
        {
            var result = await _facultyService.UpdateFaculty(facultyId, name, shortName, description);

            if (result == null) return NotFound();

            var faculty = _mapper.Map<FacultyResponse>(result);

            return Ok(faculty);
        }

        [HttpPost("UserUpdate")]
        public async Task<IActionResult> UserUpdate(int userId, int teamId, int facultyId, string email, int userPositionId)
        {
            var result = await _userService.UpdateUser(userId, teamId, facultyId, email, userPositionId);

            if (result == null) return NotFound();

            var user = _mapper.Map<UserResponse>(result);

            return Ok(user);
        }
    }
}

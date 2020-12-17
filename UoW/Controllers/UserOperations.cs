using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Contracts.Responses;

namespace UoW.Controllers
{
	public class UserOperations : ControllerBase
	{
        private readonly ILectorService _lectorService;

        private readonly IMapper _mapper;

		public UserOperations(ILectorService lectorService, IMapper mapper)
		{
            _lectorService = lectorService;
            _mapper = mapper;
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

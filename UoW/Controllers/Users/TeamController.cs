using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interface.User;
using UoW.Models.Contracts.Responses;

namespace UoW.Controllers.Users
{
	[Route("[controller]")]
	[ApiController]
	public class TeamController : ControllerBase
	{
		private ITeamService _teamService;
		private IMapper _mapper;

		public TeamController(ITeamService teamService, IMapper mapper)
		{
			_teamService = teamService;
			_mapper = mapper;
		}

		[HttpGet("GetById")]
		public async Task<IActionResult> GetUserPosition(int teamId)
		{
			var team = await _teamService.GetTeamById(teamId);

			if (team == null) return NotFound($"Position with Id {teamId}");

			var response = _mapper.Map<TeamResponse>(team);

			return Ok(response);
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _teamService.GetAll();

			if (result == null) return NotFound("Collection is empty!");

			var response = _mapper.Map<IEnumerable<TeamResponse>>(result);

			return Ok(response);
		}
	}
}

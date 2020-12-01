using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Users;

namespace UoW.Controllers.Users
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("[controller]")]
	[ApiController]
	public class UserPositionController : ControllerBase
	{
		private IUserPositionService _userPositionService;
		private IMapper _mapper;
		public UserPositionController(IUserPositionService userPositionService, IMapper mapper)
		{
			_userPositionService = userPositionService;
			_mapper = mapper;
		}

		[HttpGet("GetUserPosition")]
		public async Task<IActionResult> GetUserPosition(int positionId)
		{
			var position = await _userPositionService.GetUserPosition(positionId);

			if (position == null) return NotFound($"Position with Id {positionId}");

			var response = _mapper.Map<UserPositionResponse>(position);

			return Ok(response);
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _userPositionService.GetAll();

			if (result == null) return NotFound("Collection is empty!");

			var response = _mapper.Map<IEnumerable<UserPositionResponse>>(result);

			return Ok(response);
		}

		[HttpPost("update")]
		public async Task<IActionResult> Update(UserPositionRequest request)
		{
			if (request == null) return NotFound(request);

			var position = _mapper.Map<UserPosition>(request);

			var result = await _userPositionService.Update(position);

			var response = _mapper.Map<UserPositionResponse>(result);

			return Ok(response);
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(UserPositionRequest request)
		{
			if (request == null) return BadRequest(request);

			var position = _mapper.Map<UserPosition>(request);

			var result = await _userPositionService.Create(position);

			var response = _mapper.Map<UserPositionResponse>(result);

			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteUserPosition(int positioId)
		{
			var userPos = await _userPositionService.GetUserPosition(positioId);

			if (userPos == null) return NotFound(positioId);

			await _userPositionService.DeleteUserPosition(positioId);

			return Ok(positioId);
		}

	}
}

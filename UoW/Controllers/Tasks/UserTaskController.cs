using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Tasks;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Tasks;

namespace UoW.Controllers.Tasks
{
	[Route("[controller]")]
	[ApiController]
	public class UserTaskController : ControllerBase
	{
		private IUserTaskService _userTaskService;
		private IMapper _mapper;
		public UserTaskController(IUserTaskService userTaskService, IMapper mapper)
		{
			_userTaskService = userTaskService;
			_mapper = mapper;
		}

		[HttpGet("GetUserTask")]
		public async Task<IActionResult> GetUserTaskById(int taskId)
		{
			var position = await _userTaskService.GetById(taskId);

			if (position == null) return NotFound($"Task with Id {taskId}");

			var response = _mapper.Map<UserTaskResponse>(position);

			return Ok(response);
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _userTaskService.GetAll();

			if (result == null) return NotFound("Collection is empty!");

			//var response = _mapper.Map<IEnumerable<UserTaskResponse>>(result);

			return Ok(result);
		}

		[HttpPost("update")]
		public async Task<IActionResult> Update(UserTaskRequest request)
		{
			if (request == null) return NotFound(request);

			var position = _mapper.Map<UserTask>(request);

			var result = await _userTaskService.Update(position);

			var response = _mapper.Map<UserTaskResponse>(result);

			return Ok(response);
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(UserTaskRequest request)
		{
			if (request == null) return BadRequest(request);

			var position = _mapper.Map<UserTask>(request);

			var result = await _userTaskService.Create(position);

			var response = _mapper.Map<UserTaskResponse>(result);

			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteUserPosition(int positioId)
		{
			var userPos = await _userTaskService.GetById(positioId);

			if (userPos == null) return NotFound(positioId);

			await _userTaskService.Delete(positioId);

			return Ok(positioId);
		}

	}
}

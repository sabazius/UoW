using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UoW.Models.Contracts.Responses;
using UoW.BL.Interfaces.Tasks;
using System;

namespace UoW.Controllers
{
	public class TaskOperations : ControllerBase
	{
		
		private readonly ITaskTypeService _typeTaskServer;
		private readonly IUserTaskService _userTaskServer;
		private readonly IProjectService _projectServer;
		private readonly IMapper _mapper;

			public TaskOperations(ITaskTypeService typeTaskService,IMapper mapper, IUserTaskService userTaskServer, IProjectService projectServer)
		    {
				_typeTaskServer = typeTaskService;
				_userTaskServer = userTaskServer;
				_projectServer = projectServer;
				_mapper = mapper;
            }

		[HttpPost("TaskTypeUpdateDescription")]
		public async  Task<IActionResult> TaskTypeUpdateDescription(string description, int taskTypeId)
		{
			var result = await _typeTaskServer.UpdateDescription(description, taskTypeId);

			if (result == null) return NotFound();

			var lector = _mapper.Map<TaskTypeResponse>(result);
			return Ok(lector);
		}

		[HttpPost("UserTaskUpdate")]
		public async Task<IActionResult> UserTaskUpdate(int userTaskId, int assignedToUserId, DateTime startDate, DateTime EndDate, int taskType, string description, string name, TimeSpan timeSpend)
		{
			var result = await _userTaskServer.UpdateUserTask(userTaskId, assignedToUserId, startDate, EndDate, taskType, description, name, timeSpend);

			if (result == null) return NotFound();

			var userTask = _mapper.Map<UserTaskResponse>(result);

			return Ok(userTask);
		}

		[HttpPost("ProjectUpdate")]
		public async Task<IActionResult> ProjectUpdate(int projectId, int ownerId, int teamId, string description)
		{
			var result = await _projectServer.UpdateProject(projectId, ownerId, teamId, description);

			if (result == null) return NotFound();

			var project = _mapper.Map<ProjectResponse>(result);

			return Ok(project);
		}
	}
}

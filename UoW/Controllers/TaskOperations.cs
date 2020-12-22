using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UoW.Models.Contracts.Responses;
using UoW.BL.Interfaces.Tasks;

namespace UoW.Controllers
{
	public class TaskOperations : ControllerBase
	{
		
		private readonly ITaskTypeService _typeTaskServer;
		private readonly IMapper _mapper;

			public TaskOperations(ITaskTypeService typeTaskService,IMapper mapper)
		    {
				_typeTaskServer = typeTaskService;
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
	}
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
		public IActionResult TaskTypeUpdateDescription(int description, int lectorId)
		{
			var result = _typeTaskService.UpdateFaculty(description, lectorId);

			if (result == null) return NotFound();

			var lector = _mapper.Map<TypeTaskResponse>(result);

			return Ok(lector);
		}
	}
}

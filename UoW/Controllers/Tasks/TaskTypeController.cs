using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UoW.BL.Interfaces.Tasks;
using UoW.Models.Contracts.Requests;
using UoW.Models.Tasks;

namespace UoW.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTypeController : Controller
    {
        private readonly ITaskTypeService _taskTypeService;
        private readonly IMapper _mapper;

        public TaskTypeController(ITaskTypeService taskTypeService,IMapper mapper)
        {
            _taskTypeService = taskTypeService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _taskTypeService.GetAll();

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("AddTaskType")]

        public async Task<IActionResult> AddTaskType([FromBody]TaskTypeRequest taskTypeRequest)
        {
            var taskType = _mapper.Map<TaskType>(taskTypeRequest);

            var result = await _taskTypeService.Create(taskType);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

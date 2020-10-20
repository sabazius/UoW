using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UoW.BL.Interfaces.Tasks;
using UoW.Models.Tasks;

namespace UoW.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        public IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }
        
        [HttpGet]
        public Story GetStoryById(int storyId)
        {
            return _storyService.GetStoryById(storyId);
        }
    }
}

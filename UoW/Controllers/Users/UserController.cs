using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Users;

namespace UoW.Controllers.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await _userService.GetUserByid(userId);
            if (result == null) return NotFound("User not found");

            var user = _mapper.Map<User>(result);

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();

            if (result == null) return NotFound("Collection is empty!");

            var response = _mapper.Map<IEnumerable<UserResponse>>(result);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest request)
        {
            if (request == null) return NotFound();

            var user = _mapper.Map<User>(request);

            var result = _userService.Create(user);

            if (result == null) return NotFound();

            return Ok(user);
        }
    }
}


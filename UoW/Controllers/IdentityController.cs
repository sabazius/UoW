using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UoW.BL.Interfaces;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Identity;

namespace UoW.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IdentityController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		private IIdentityService _identityService;

		public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IIdentityService identityService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_identityService = identityService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
		{
			var authResult = await _identityService.RegisterAsync(request.UserName, request.Password);

			if (!authResult.IsSuccess)
			{
				return BadRequest(new AuthFailedResponse
				{
					Errors = authResult.Errors
				});
			}

			return Ok(new AuthSuccessResponse
			{
				Token = authResult.Token
			});
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
		{
			var loginResponse = await _identityService.LoginAsync(request.Username, request.Password);

			if (!loginResponse.IsSuccess)
			{
				return BadRequest(new AuthFailedResponse
				{
					Errors = loginResponse.Errors
				});
			}


			return Ok(new AuthSuccessResponse
			{
				Token = loginResponse.Token
			});
		}

		[HttpPost]
		public async Task<IActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();

			return Ok();
		}

		[HttpGet("GetCurrentUser")]
		public async Task<IActionResult> GetCurrentUser()
		{
			var result = await _userManager.GetUserAsync(HttpContext.User);

			return Ok(result);
		}
	}
}

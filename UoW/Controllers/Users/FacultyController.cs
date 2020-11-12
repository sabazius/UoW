using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        IFacultyService _facultyService;
        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetFacultyById(int id)
        {
            var result = await _facultyService.GetById(id);

            return Ok(result);
        }
    }
}

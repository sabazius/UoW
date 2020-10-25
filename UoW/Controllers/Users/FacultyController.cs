using Microsoft.AspNetCore.Mvc;
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
        public Faculty GetFacultyById(int id)
        {
            return _facultyService.GetFacultyById(id);
        }
    }
}
